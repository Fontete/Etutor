﻿using Etutor.DAL;
using Etutor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Etutor.Controllers
{
    [Authorize]
    public class TutorController : Controller
    {
        private EtutorContext db = new EtutorContext();
        //GET: Tutor
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                Session["TU_ID"] = id;
            }
            else { id = Convert.ToInt32(Session["TU_ID"]); }
            var list = db.Tutors.ToList();
            var found = db.Assigns.Where(m => m.Tutor.Id == id).ToList();
            //var found = db.Documents.Where(m => m.Assign.Tutor.Id == id).ToList();
            return View(found);
        }

        public ActionResult Detail(int? id)
        {
            //if (id != null)
            //{
            //    Session["TU_ID"] = id;
            //}
            //else { id = Convert.ToInt32(Session["TU_ID"]); }
            var found = db.Documents.Where(m => m.Assign.Tutor.Id == id).ToList();
            return View(found);
        }

        public FileResult Download(string download)
        {
            try
            {
                var file = download;
                return File(file, "application/force- download", Path.GetFileName(file));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            var tutid = Convert.ToInt32(Session["TU_ID"]);

            if (file?.ContentLength > 0)
            {
                try
                {
                    var fileTypes = new[] { ".pdf", ".doc", ".docx", ".jpeg", ".jpg", ".png", ".gif" };
                    var checkTypes = Path.GetExtension(file.FileName).ToLower();
                    string title = String.Concat(Path.GetFileNameWithoutExtension(file.FileName));
                    string filename = String.Concat(title, checkTypes);
                    string path = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(filename));
                    file.SaveAs(path);

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
                        Name = filename,
                        Assign = db.Assigns.Where(m => m.Id == tutid).SingleOrDefault()
                    };
                    db.Documents.Add(doc);
                    db.SaveChanges();

                    ViewBag.Message = "Uploaded successfully!";

                }
                catch (Exception e)
                {
                    ViewBag.Error = "Please try again " + e.Message;
                }
            }
            else
            {
                ViewBag.Error = "Please choose a file you want to upload";
            }

            if (ViewBag.Error != null)
            {
                TempData["MSG"] = ViewBag.Error;
                return RedirectToAction("Upload", "Tutor");
            }
            return RedirectToAction("Detail", "Tutor");
        }

        public ActionResult Chat()
        {
            return View();
        }

    }
}
