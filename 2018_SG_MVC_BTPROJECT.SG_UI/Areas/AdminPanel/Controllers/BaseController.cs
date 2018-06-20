using _2018_SG_MVC_BTPROJECT.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Controllers
{
    public class BaseController : Controller
    {
        public IUnitOfWork uow = null;

        public BaseController()
        {
            uow = new UnitOfWork();
        }
    }
}