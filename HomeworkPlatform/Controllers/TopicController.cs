using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeworkPlatform.Models;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;

namespace HomeworkPlatform.Controllers
{
    public class ValidateFileAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }

            if (file.ContentLength > 10 * 1024 * 1024)
            {
                return false;
            }

            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    return img.RawFormat.Equals(ImageFormat.Png);
                }
            }
            catch { }
            return false;
        }
    }
    public class TopicController : Controller
    {
        public ActionResult Index()
        {
            var database = new TopicDataBase();
            database.accessDataBase();
            return View(database.getAllTopics());
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult List(int id)
        {
            ViewBag.topic_id = id;
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Detail(int id)
        {
            ViewBag.upload_id = id;
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Upload(int id)
        {
            ViewBag.upload_id = id;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HomeworkModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                
                if (model.UploadFile.ContentLength > 0)
                {
                    
                    string fileName = Path.GetFileName(model.UploadFile.FileName);
                    fileName = model.Author.StudentID + "_" + fileName;
                    string path = Path.Combine(Server.MapPath("~/App_Data/Homework/" + model.TopicId), fileName);
                    //string path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                    model.UploadFile.SaveAs(path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                var database = new HomeworkDataBase();
                database.accessDataBase();
                database.insertHomwork(model);
                return RedirectToAction("Index", "Topic");
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

    }
}