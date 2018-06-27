using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeworkPlatform.Models;

namespace HomeworkPlatform.Controllers
{
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
    }
}