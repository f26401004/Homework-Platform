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
            ViewBag.topic_id = id;
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Detail(string id)
        {
            ViewBag.upload_id = id;
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Upload(string id)
        {
            
            string currentUserId = User.Identity.GetUserId();
            if (currentUserId == null)
                return HttpNotFound();
            var database = new AccountDataBase();
            database.accessDataBase();
            System.Diagnostics.Debug.WriteLine(User.Identity.GetUserName());
            if (!database.checkAccount(User.Identity.GetUserName()))
                return HttpNotFound();
            
            ApplicationUser currentUser = database.find(User.Identity.GetUserName());
            //ApplicationUser currentUser = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(id);
            ViewBag.upload_id = id;
            ViewData.Add("User", currentUser);
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