using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeworkPlatform.Controllers
{
    public class TopicController : Controller
    {
        public ActionResult Index()
        {
            return View();
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