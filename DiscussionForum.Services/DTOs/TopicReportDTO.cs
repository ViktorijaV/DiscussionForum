using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionForum.Services.DTOs
{
    public class TopicReportDTO
    {
        public int ID { get; private set; }
        public int TopicID { get; private set; }
        public string TopicTitle { get; private set; }
        public int ReporterID { get; private set; }
        public string ReporterUsername { get; private set; }
        public string Reason { get; private set; }
        public DateTime DateCreated { get; set; }
    }
}
