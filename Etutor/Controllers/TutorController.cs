using Etutor.DAL;
using Etutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Etutor.Controllers
{
    [Authorize]
    public class TutorController : Controller
    {
        private EtutorContext db = new EtutorContext();
        // GET: Tutor
        //public ActionResult Index(int? id)
        //{
        //    if (id != null)
        //    {
        //        Session["TU_ID"] = id;
        //    }
        //    else { id = Convert.ToInt32(Session["TU_ID"]); }
        //    var found = db.Documents.Where(m => m.Assign.TutorId == id).ToList();
        //    return View();
        //}

        public ActionResult Chat()
        {
            return View();
        }
    }
}
