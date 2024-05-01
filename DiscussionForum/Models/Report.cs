using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.Models
{
    public class Report
    {
        public int ID { get; set; }
        public string Reson { get; set; }
     
        public DateTime TimeSpam { get; set; }

        //[ForeignKey("ReporterUser")]
        //public string ReporterUserID { get; set; }
        //public ApplicationUser ReporterUser { get; set; }

        [ForeignKey("ReportedUser")]
        public string ReportedUserID { get; set; }

        public ApplicationUser ReportedUser { get; set; }
    }
}
