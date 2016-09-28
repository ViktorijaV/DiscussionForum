using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionForum.Domain.DomainModel
{
    public class CommentReport
    {
        public CommentReport(int commentID, int reporterID, string reason, DateTime dateCreated)
        {
            CommentID = commentID;
            ReporterID = reporterID;
            Reason = reason;
            DateCreated = dateCreated;
        }

        public int ID { get; private set; }
        public int CommentID { get; private set; }
        public int ReporterID { get; private set; }
        public string Reason { get; private set; }
        public DateTime DateCreated { get; set; }
    }
}
