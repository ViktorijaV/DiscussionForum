using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DiscussionForum.Domain.DomainModel
{
    public class TimePeriod
    {
        public static string TimeDifference(DateTime date)
        {
            var dateNow = DateTime.Now;
            var difference = dateNow - date;
            if (difference.TotalSeconds < 60)
                return $"{(int)difference.TotalSeconds}s ago ";
            if (difference.TotalMinutes < 60)
                return $"{(int)difference.TotalMinutes}m ago ";
            if(difference.TotalHours < 24)
                return $"{(int)difference.TotalHours}h ago ";
            if(difference.TotalDays < 30)
                return $"{(int)difference.TotalDays}d ago ";
            if(difference.TotalDays < 365)
                return date.ToString("dd MMM", CultureInfo.CreateSpecificCulture("en-US"));

            return date.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"));

        }

        public static double TimeDifferencesInMiliseconds(DateTime date)
        {
            return (DateTime.Now - date).TotalMilliseconds;
        }

        public static int GetAge(DateTime birthDate)
        {
            var date = DateTime.Now; 
            int age = date.Year - birthDate.Year;

            if (date.Month < birthDate.Month || (date.Month == birthDate.Month && date.Day < birthDate.Day))
                age--;

            return age;
        }
    }
}