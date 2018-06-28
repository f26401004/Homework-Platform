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
using Microsoft.AspNet.Identity;
using System.Net;


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
        public ActionResult List(string id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            var database = new HomeworkDataBase();
            database.accessDataBase();

            ViewBag.topic_id = id;
            ViewBag.Title = "C# final project";

            return View(database.getHomeworkByTopicId(id));
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Detail(string id)
        {
            ViewBag.upload_id = id;
            var database = new HomeworkDataBase();
            database.accessDataBase();
            return View(database.getHomeworkById(id));
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Upload(string id)
        {
            string currentUserId = User.Identity.GetUserId();
            if (currentUserId == null)
                return HttpNotFound();
            var database = new AccountDataBase();
            database.accessDataBase();
            if (!database.checkAccount(User.Identity.GetUserName()))
                return HttpNotFound();
            ApplicationUser currentUser = database.find(User.Identity.GetUserName());
            ViewBag.upload_id = id;
            ViewData.Add("User", currentUser);
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HomeworkModel model, string returnUrl, string topic_id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                System.Diagnostics.Debug.WriteLine(model.TopicId);
                System.Diagnostics.Debug.WriteLine(model.Author);
                if (model.UploadFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(model.UploadFile.FileName);
                    string path = Path.Combine(Server.MapPath("~/Static/Homework/"), topic_id + "_"+ User.Identity.GetUserName() + "_" +  fileName);
                    model.UploadFile.SaveAs(path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                var database = new HomeworkDataBase();
                database.accessDataBase();
                database.insertHomwork(model, User.Identity.GetUserName(), topic_id, topic_id + "_" + User.Identity.GetUserName() + "_" + Path.GetFileName(model.UploadFile.FileName));
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