using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Dapper;
using DiscussionForum.Domain.DomainModel;

namespace DiscussionForum.Services
{
    public class FormsAuthenticationService
    {
        private HttpContext _httpContext = HttpContext.Current;
        private readonly SqlConnection _connection;
        private TimeSpan _expirationTimeSpan;

        //private static AuthenticatedUser _cachedUser;

        public FormsAuthenticationService(HttpContext httpContext, SqlConnection connection)
        {
            _httpContext = httpContext;
            _expirationTimeSpan = FormsAuthentication.Timeout;
            _connection = connection;
        }

        public void SignIn(User user, bool extendExpirationDate, bool createPersistentCookie)
        {
            var now = DateTime.UtcNow.ToLocalTime();
            var authenticatedUser = new AuthenticatedUser(user.Fullname, user.Username, user.ID, user.Avatar, user.Role.ToString());

            if (extendExpirationDate)
            {
                int span = DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365;
                _expirationTimeSpan = new TimeSpan(span, 0, 0, 0);
            }
            else
                _expirationTimeSpan = FormsAuthentication.Timeout;

            var ticket = new FormsAuthenticationTicket(
                version: 1,
                name: user.Email,
                issueDate: now,
                expiration: now.Add(_expirationTimeSpan),
                isPersistent: createPersistentCookie,
                userData: JsonConvert.SerializeObject(authenticatedUser),
                cookiePath: FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }

            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            _httpContext.Response.Cookies.Add(cookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public AuthenticatedUser GetAuthenticatedUser()
        {
            if (_httpContext == null ||
                _httpContext.Request == null ||
                !_httpContext.Request.IsAuthenticated ||
                !(_httpContext.User.Identity is FormsIdentity))
            {
                return null;
            }

            var formsIdentity = (FormsIdentity)_httpContext.User.Identity;
            var authenticatedUser = GetAuthenticatedUserFromTicketAsync(formsIdentity.Ticket);

            return authenticatedUser;
        }

        protected AuthenticatedUser GetAuthenticatedUserFromTicketAsync(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));

            var email = ticket.Name;
            if (string.IsNullOrEmpty(email))
                return null;

            var user = _connection.Query<User>($"SELECT * FROM Users WHERE Email='{email}'").FirstOrDefault();
            var authenticatedUser = new AuthenticatedUser(user.Fullname, user.Username, user.ID, user.Avatar, user.Role.ToString());

            if (string.IsNullOrEmpty(user.Avatar))
                authenticatedUser.PhotoUrl = HttpContext.Current.Server.MapPath("");

            return authenticatedUser;
        }
    }
}