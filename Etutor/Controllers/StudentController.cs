using Etutor.DAL;
using Etutor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Etutor.Controllers
{
    public class StudentController : Controller
    {
        private EtutorContext db = new EtutorContext();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            var stdid = Convert.ToInt32(Session["S_ID"]);

            if (file?.ContentLength > 0)
            {
                //try
                //{
                    var fileTypes = new[] { ".pdf", ".doc", ".docx", ".jpeg", ".jpg", ".png", ".gif" };
                    var checkTypes = Path.GetExtension(file.FileName).ToLower();

                    //if (!fileTypes.Contains(checkTypes))
                    //{
                    //    ViewBag.Error = "Invalid file type!";
                    //    return View();
                    //}

                    string title = String.Concat(Path.GetFileNameWithoutExtension(file.FileName));
                    string filename = String.Concat(title, checkTypes);
                    string path = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(filename));
                    file.SaveAs(path);

                    //System.IO.File.Copy(file.ToString(), path);

                    string type = "";
                    var docType = new[] { ".doc", ".docx", ".pdf" };
                    if (docType.Contains(checkTypes))
                    {
                        type = "Document";
                    }
                    else
                    {
                        type = "Image";
                    }

                    Document doc = new Document
                    {
                        UploadTime = DateTime.Now,
                        Type = type,
                        Url = path,
                        Assign = db.Assigns.Where(m => m.Id == stdid).SingleOrDefault()
                    };
                    db.Documents.Add(doc);
                    db.SaveChanges();

                    ViewBag.Message = "Uploaded successfully!";

                    //SendEmail(staffs.Email, s_id);
            //    }
            //    catch (Exception e)
            //    {
            //        ViewBag.Error = "Please try again " + e.Message;
            //    }
            }
            //else
            //{
            //    ViewBag.Error = "Please choose a file you want to upload";
            //}


            return RedirectToAction("Index", "Student");
        }


    }
}
