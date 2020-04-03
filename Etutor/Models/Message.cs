using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Etutor.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int StdId { get; set; }
        public int TutId { get; set; }
        public virtual Assign Assign { get; set; }
    }
}