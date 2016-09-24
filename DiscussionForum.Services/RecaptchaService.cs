using DiscussionForum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DiscussionForum.Services
{
    public class RecaptchaService : IRecaptchaService
    {
        private string _secretKey { get; set; }

        public RecaptchaService(string secretKey)
        {
            _secretKey = secretKey;
        }
        public bool validateRecaptcha(string response)
        {
            bool valid = false;
            //Request to Google Server
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create($" https://www.google.com/recaptcha/api/siteverify?secret={_secretKey}&response={response}");

            try
            {
                //Google recaptcha Responce 
                using (WebResponse wResponse = req.GetResponse())
                {
                    using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                    {
                        string jsonResponse = readStream.ReadToEnd();

                        JavaScriptSerializer js = new JavaScriptSerializer();
                        RecaptchaResponse data = js.Deserialize<RecaptchaResponse>(jsonResponse);// Deserialize Json 

                        valid = Convert.ToBoolean(data.success);
                    }
                }

                return valid;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }


        public class RecaptchaResponse
        {
            public string success { get; set; }
        }
    }
}
