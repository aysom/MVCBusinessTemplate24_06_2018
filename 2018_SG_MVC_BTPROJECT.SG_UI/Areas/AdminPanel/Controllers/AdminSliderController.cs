using _2018_SG_MVC_BTPROJECT.Business.Abstract;
using _2018_SG_MVC_BTPROJECT.Business.UnitOfWork;
using _2018_SG_MVC_BTPROJECT.Business.Upload;
using _2018_SG_MVC_BTPROJECT.Entities;
using _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Models.AdminDTO;
using _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Models.AdminDTO.PageDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Controllers
{
    public class AdminSliderController : Controller
    {
        private ISliderService _ISliderService;
        private IUnitOfWork _UnitOfWork; 

        public AdminSliderController(ISliderService sliderService,IUnitOfWork unitOfWork)
        {
            _ISliderService = sliderService;
            _UnitOfWork = unitOfWork; 
        }
        
        // GET: AdminPanel/AdminSlider
        public ActionResult Index()
        {  
            SliderListVM aslw = new SliderListVM();
            var model = _UnitOfWork.GetRepository<Slider>().GetAll();
            List<SliderVM> allSlides = model.Select(slider => new SliderVM
            {
                Id = slider.Id,
                Description = slider.Description,
                ImageUrl = slider.ImageUrl
            }).ToList();

            aslw.AllSliders = allSlides;
            return View(aslw);
        }

        public JsonResult DeleteSlider(int SliderId)
        {
            Slider gelenSlider = _ISliderService.getSliderDetail(SliderId);
            bool result = false;
            _UnitOfWork.GetRepository<Slider>().Delete(SliderId);
            _UnitOfWork.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SliderDetail(int id)
        {
            Slider gelenSlider = _ISliderService.getSliderDetail(id);
            SliderVM gosterilen = new SliderVM();
            gosterilen.Id = gelenSlider.Id;
            gosterilen.Description = gelenSlider.Description;
            gosterilen.ImageUrl = gelenSlider.ImageUrl;
            return View(gosterilen);
        }
        string OrgimagePath = "~/Upload/Slider/OrjPath";
        string SmallimagePath = "~/Upload/Slider/SmallPath";
        string LargeimagePath = "~/Upload/Slider/LargePath";

        [HttpPost]
        public ActionResult SliderDetail(SliderVM modelSlider, HttpPostedFileBase resim)
        {

            Slider gelenSlider = _UnitOfWork.GetRepository<Slider>().GetById(modelSlider.Id);
            gelenSlider.Id = modelSlider.Id;
            gelenSlider.Description = modelSlider.Description;
            if (resim == null && modelSlider.ImageUrl != "default.png")
                gelenSlider.ImageUrl = modelSlider.ImageUrl;
            else if (resim == null)
                gelenSlider.ImageUrl = "default.png";
            else
            {
                Image photoThumb = Image.FromStream(resim.InputStream, true, true);
                ImageUploadService svc = ImageUploadService.CreateService(resim);
                string uniqFileName = svc.CreateUniqName(resim.FileName, OrgimagePath);

                svc.Upload(OrgimagePath, SmallimagePath, LargeimagePath, uniqFileName);
                gelenSlider.ImageUrl = uniqFileName;
            } 
            _UnitOfWork.GetRepository<Slider>().Update(gelenSlider);
            _UnitOfWork.SaveChanges();
            return RedirectToAction("Index", "AdminSlider");

        }

        [HttpGet]
        public ActionResult InsertSlider()
        {
            SliderVM sl = new SliderVM();
            return View(sl);
        }

        [HttpPost]
        public ActionResult InsertSlider(SliderVM gelenSlider, HttpPostedFileBase resim)
        {

            string OrgimagePath = "~/Upload/Slider/OrjPath";
            string SmallimagePath = "~/Upload/Slider/SmallPath";
            string LargeimagePath = "~/Upload/Slider/LargePath";
            string uniqFileName = "";
            ImageUploadService svc = ImageUploadService.CreateService(resim);
            uniqFileName = svc.CreateUniqName(resim.FileName, OrgimagePath);

            SliderVM vmodel = new SliderVM(); 
            Slider eklenecek = new Slider();
          
            if (ModelState.IsValid)
            {
                if (resim != null)
                {
                    svc.Upload(OrgimagePath, SmallimagePath, LargeimagePath, uniqFileName);
                } 
                eklenecek.Description = gelenSlider.Description;
                eklenecek.ImageUrl = uniqFileName; 
                _UnitOfWork.GetRepository<Slider>().Insert(eklenecek);
                _UnitOfWork.SaveChanges();
                return RedirectToAction("Index", "AdminSlider");
            }
            else
            {
                return View(vmodel);
            }
            
        }


    }
}