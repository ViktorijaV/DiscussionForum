using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionForum.Domain.DomainModel
{
    public class TopicReport
    {
        public TopicReport(int topicID, int reporterID, string reason, DateTime dateCreated)
        {
            TopicID = topicID;
            ReporterID = reporterID;
            Reason = reason;
            DateCreated = dateCreated;
        }

        public TopicReport(int topicID)
        {
            TopicID = topicID;
        }

        public TopicReport()
        {
            
        }

        public int ID { get; private set; }
        public int TopicID { get; private set; }
        public int ReporterID { get; private set; }
        public string Reason { get; private set; }
        public DateTime DateCreated { get; set; }
    }
}
