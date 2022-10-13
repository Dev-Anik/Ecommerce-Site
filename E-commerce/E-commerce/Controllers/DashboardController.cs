using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayerAranoz;

namespace E_commerce.Controllers
{
    //[Authorize]
    public class DashboardController : Controller
    {
        //[Authorize]
        // GET: Dashboard
        public ActionResult AdminDashboard()
        {
            return View();
        }
    }
}