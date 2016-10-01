using System;

namespace DiscussionForum.Domain.DomainModel
{
    public class CommentReport
    {
        public CommentReport(int commentID, int reporterID, string reason, DateTime dateCreated)
        {
            if (string.IsNullOrEmpty(reason))
                throw new Exception("The reason for reporting is required!");
            if (reason.Length > 300)
                throw new Exception("The reason should be less than 300 charachters!");
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
