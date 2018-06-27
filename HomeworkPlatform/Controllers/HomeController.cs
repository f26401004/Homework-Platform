using HomeworkPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HomeworkPlatform.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(UpViewModels model,string returnURL)
        {
            if (ModelState.IsValid)
            {
                Boolean result = false;
                HomeworkDataBase home = new HomeworkDataBase(model);
                result = home.accessHomeworkDataBase();
                if (result)
                {
                    result = home.insertHomwork();
                    if (result)
                    {
                        //success
                    }
                }
            }
            ViewBag.ReturnURL = returnURL;
            return RedirectToAction("", "Home");

        }
    }
}