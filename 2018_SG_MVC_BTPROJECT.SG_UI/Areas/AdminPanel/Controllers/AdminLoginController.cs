using _2018_SG_MVC_BTPROJECT.Business.Abstract;
using _2018_SG_MVC_BTPROJECT.Entities;
using _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Models.AdminDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Controllers
{
    public class AdminLoginController : BaseController
    {
        
         private ILoginService _loginService;

         public AdminLoginController(ILoginService loginService)
         {
            _loginService = loginService;
         }
          
        [HttpGet]
        public ActionResult Index()
        {
            
           

            return View();
        }
        [HttpPost]
        // GET: AdminPanel/AdminLogin
        public ActionResult Index(User user)
        {
            string a = user.Email;
            
            if (_loginService.LoginOlduMu(user))
            {
                return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}