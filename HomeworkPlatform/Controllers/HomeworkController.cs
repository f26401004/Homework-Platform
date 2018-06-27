using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using HomeworkPlatform.Models;
using System.Web.Security;
using System.Net;

namespace HomeworkPlatform.Controllers
{
    [Authorize]
    public class HomeworkController : Controller
    {

        // GET: Homework
        public ActionResult Index()
        {
            return View();
        }

        
    }
}