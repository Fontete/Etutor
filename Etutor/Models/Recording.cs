using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Etutor.Models
{
    public class Content
    {
        public int Id { get; set; }
        public DateTime UploadTime { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        [ForeignKey("AssignId")]
        public virtual Assign Assign { get; set; }
    }
}