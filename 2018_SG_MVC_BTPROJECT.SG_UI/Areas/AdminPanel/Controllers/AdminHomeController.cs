using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Controllers
{
    public class AdminHomeController : BaseController
    {
        // GET: AdminPanel/AdminHome
        public ActionResult Index()
        {
            return View();
        }
    }
}