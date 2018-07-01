using _2018_SG_MVC_BTPROJECT.Business.Abstract;
using _2018_SG_MVC_BTPROJECT.Business.UnitOfWork;
using _2018_SG_MVC_BTPROJECT.Business.Upload;
using _2018_SG_MVC_BTPROJECT.Entities;
using _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Models.AdminDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Controllers
{
    public class AdminSiteInfoController : Controller
    {
        private ISiteInfoService _SiteInfoCategoryService;
        private IUnitOfWork _UnitOfWork;

        public AdminSiteInfoController(ISiteInfoService siteInfoService, IUnitOfWork unitOfWork)
        {
            _SiteInfoCategoryService = siteInfoService;
            _UnitOfWork = unitOfWork;
        }
         
        
        // GET: AdminPanel/AdminSiteInfo
        public ActionResult Index()
        {
            var model = _UnitOfWork.GetRepository<SiteInfo>().Where(x => x.Id == 1);
             SiteInfoVM siteInfo = model.Select(si => new SiteInfoVM
            { 
                Id=si.Id,
                SiteUrl = si.SiteUrl,
                CompanyName = si.CompanyName,
                SiteName = si.SiteName,
                MetaTag = si.MetaTag,
                Description = si.Description,
                Address = si.Address,
                Phone1 = si.Phone1,
                Phone2 = si.Phone2,
                Phone3 = si.Phone3,
                Email1 = si.Email1,
                Email2 = si.Email2,
                Email3 = si.Email3,
                Facebook = si.Facebook,
                Twitter = si.Twitter,
                Instagram = si.Instagram,
                Youtube = si.Youtube,
                SiteDesignAgency = si.SiteDesignAgency,
                SiteMap = si.SiteMap,
                Logo = si.Logo,
                AboutText = si.AboutText,
                VisionText = si.VisionText,
                MissionText = si.MissionText,
                Service = si.Service
            }).FirstOrDefault();
            return View(siteInfo);
        }

        string OrgimagePath = "~/Upload/Logo/OrjPath";
        string SmallimagePath = "~/Upload/Logo/SmallPath";
        string LargeimagePath = "~/Upload/Logo/LargePath";





        [HttpGet]
        public ActionResult EditSiteInfo()
        {
            var model = _UnitOfWork.GetRepository<SiteInfo>().Where(x => x.Id == 1);
            SiteInfoVM siteInfo = model.Select(si => new SiteInfoVM
            {
                Id = si.Id,
                SiteUrl = si.SiteUrl,
                CompanyName = si.CompanyName,
                SiteName = si.SiteName,
                MetaTag = si.MetaTag,
                Description = si.Description,
                Address = si.Address,
                Phone1 = si.Phone1,
                Phone2 = si.Phone2,
                Phone3 = si.Phone3,
                Email1 = si.Email1,
                Email2 = si.Email2,
                Email3 = si.Email3,
                Facebook = si.Facebook,
                Twitter = si.Twitter,
                Instagram = si.Instagram,
                Youtube = si.Youtube,
                SiteDesignAgency = si.SiteDesignAgency,
                SiteMap = si.SiteMap,
                Logo = si.Logo,
                AboutText = si.AboutText,
                VisionText = si.VisionText,
                MissionText = si.MissionText,
                Service = si.Service
            }).FirstOrDefault();
            return View(siteInfo);
        }


        

        [HttpPost]
        public ActionResult EditSiteInfo(SiteInfoVM modelSiteInfo, HttpPostedFileBase resim)
        { 
            SiteInfo gelenSiteInfo = _UnitOfWork.GetRepository<SiteInfo>().GetById(modelSiteInfo.Id);
            gelenSiteInfo.Id = modelSiteInfo.Id;
            gelenSiteInfo.SiteUrl = modelSiteInfo.SiteUrl;
            gelenSiteInfo.CompanyName = modelSiteInfo.CompanyName;
            gelenSiteInfo.SiteName = modelSiteInfo.SiteName;
            gelenSiteInfo.MetaTag = modelSiteInfo.MetaTag;
            gelenSiteInfo.Description = modelSiteInfo.Description;
            gelenSiteInfo.Address = modelSiteInfo.Address;
            gelenSiteInfo.Phone1 = modelSiteInfo.Phone1;
            gelenSiteInfo.Phone2 = modelSiteInfo.Phone2;
            gelenSiteInfo.Phone3 = modelSiteInfo.Phone3;
            gelenSiteInfo.Email1 = modelSiteInfo.Email1;
            gelenSiteInfo.Email2 = modelSiteInfo.Email2;
            gelenSiteInfo.Email3 = modelSiteInfo.Email3;
            gelenSiteInfo.Facebook = modelSiteInfo.Facebook;
            gelenSiteInfo.Twitter = modelSiteInfo.Twitter;
            gelenSiteInfo.Instagram = modelSiteInfo.Instagram;
            gelenSiteInfo.Youtube = modelSiteInfo.Youtube;
            gelenSiteInfo.SiteDesignAgency = modelSiteInfo.SiteDesignAgency;
            gelenSiteInfo.SiteMap = modelSiteInfo.SiteMap;
            gelenSiteInfo.AboutText = modelSiteInfo.AboutText;
            gelenSiteInfo.VisionText = modelSiteInfo.VisionText;
            gelenSiteInfo.MissionText = modelSiteInfo.MissionText;
            gelenSiteInfo.Service = modelSiteInfo.Service;
            gelenSiteInfo.CompanyName = modelSiteInfo.CompanyName;
              
            if (resim == null && modelSiteInfo.Logo != "default.png")
                gelenSiteInfo.Logo = modelSiteInfo.Logo;
            else if (resim == null)
                gelenSiteInfo.Logo = "default.png";
            else
            {
                Image photoThumb = Image.FromStream(resim.InputStream, true, true);
                ImageUploadService svc = ImageUploadService.CreateService(resim);
                string uniqFileName = svc.CreateUniqName(resim.FileName, OrgimagePath);

                svc.Upload(OrgimagePath, SmallimagePath, LargeimagePath, uniqFileName);
                gelenSiteInfo.Logo = uniqFileName;
            }
            _UnitOfWork.GetRepository<SiteInfo>().Update(gelenSiteInfo);
            _UnitOfWork.SaveChanges();
            return RedirectToAction("Index", "AdminSiteInfo");

        }



    }
}