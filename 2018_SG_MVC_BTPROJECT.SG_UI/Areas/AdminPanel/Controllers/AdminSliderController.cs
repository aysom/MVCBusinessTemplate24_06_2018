using _2018_SG_MVC_BTPROJECT.Business.Abstract;
using _2018_SG_MVC_BTPROJECT.Business.UnitOfWork;
using _2018_SG_MVC_BTPROJECT.Entities;
using _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Models.AdminDTO;
using _2018_SG_MVC_BTPROJECT.SG_UI.Areas.AdminPanel.Models.AdminDTO.PageDTO;
using System;
using System.Collections.Generic;
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



    }
}