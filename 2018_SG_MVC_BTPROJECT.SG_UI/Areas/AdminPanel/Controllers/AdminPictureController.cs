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
    public class AdminPictureController : Controller
    {

        private IPictureService _PictureService;
        private IUnitOfWork _UnitOfWork;
        private ICategoryService _CategoryService;

        public AdminPictureController(IPictureService pictureService, IUnitOfWork unitOfWork, ICategoryService categoryService)
        {
            _PictureService = pictureService;
            _UnitOfWork = unitOfWork;
            _CategoryService = categoryService;
        } 
        // GET: AdminPanel/AdminPicture
        public ActionResult Index()
        { 
            var model = _UnitOfWork.GetRepository<Picture>().GetAll();
            var model2 = _UnitOfWork.GetRepository<Picture>();
            var modelAllMainCategories = _CategoryService.getMainCategories();
            List<PictureVM> pictureList = model.Select(pic => new PictureVM
            {
                Id = pic.Id,
                ImagePath = pic.ImagePath,
                catName = model2.GetById(pic.CatId).Category.Name,
                CatId = pic.CatId
            }).ToList();
            PictureListVM apl = new PictureListVM();
            apl.MainCategoryFilter = modelAllMainCategories;
            apl.AllPictures = pictureList.ToList();
            return View(apl);
        }
 
          
        
        public ActionResult PictureDetail(int id)
        {
            Picture gelenPicture = _PictureService.getPictureDetail(id);
            PictureVM gosterilen = new PictureVM();
            gosterilen.Id = gelenPicture.Id; 
            gosterilen.ImagePath = gelenPicture.ImagePath;
            gosterilen.drpcategories = _CategoryService.getAllCategories().Select(cat => new SelectListItem()
            {
                Text = cat.Name,
                Value = cat.Id.ToString()
            }).ToList();
            return View(gosterilen);
        }
        string OrgimagePath = "~/Upload/Slider/OrjPath";
        string SmallimagePath = "~/Upload/Slider/SmallPath";
        string LargeimagePath = "~/Upload/Slider/LargePath";

        [HttpPost]
        public ActionResult PictureDetail(PictureVM modelPicture, HttpPostedFileBase resim)
        {
            Picture gelenPicture= _UnitOfWork.GetRepository<Picture>().GetById(modelPicture.Id);
            gelenPicture.CatId = modelPicture.CatId;
            if (resim == null && modelPicture.ImagePath != "default.png")
                gelenPicture.ImagePath = modelPicture.ImagePath;
            else if (resim == null)
                gelenPicture.ImagePath = "default.png";
            else
            {
                Image photoThumb = Image.FromStream(resim.InputStream, true, true);
                ImageUploadService svc = ImageUploadService.CreateService(resim);
                string uniqFileName = svc.CreateUniqName(resim.FileName, OrgimagePath);

                svc.Upload(OrgimagePath, SmallimagePath, LargeimagePath, uniqFileName);
                gelenPicture.ImagePath = uniqFileName;
            }
            _UnitOfWork.GetRepository<Picture>().Update(gelenPicture);
            _UnitOfWork.SaveChanges();
            return RedirectToAction("Index", "AdminPicture");

        }


        [HttpGet]
        public ActionResult InsertPicture()
        {
            PictureVM picture = new PictureVM();
            picture.drpcategories = _CategoryService.getDrpCategories();
            picture.ImagePath ="default.png";
            return View(picture);
        }

        [HttpPost]
        public ActionResult InsertPicture(PictureVM gelenPicture, HttpPostedFileBase resim)
        {
            string OrgimagePath = "~/Upload/Picture/OrjPath";
            string SmallimagePath = "~/Upload/Picture/SmallPath";
            string LargeimagePath = "~/Upload/Picture/LargePath";
            string uniqFileName = "";
             
            ImageUploadService svc = ImageUploadService.CreateService(resim);
            uniqFileName = svc.CreateUniqName(resim.FileName, OrgimagePath);
            PictureVM vmodel = new PictureVM();
            
            Picture eklenecek = new Picture(); 
            if (ModelState.IsValid)
            {
                if (resim != null)
                {
                    svc.Upload(OrgimagePath, SmallimagePath, LargeimagePath, uniqFileName);
                }
                eklenecek.CatId = gelenPicture.CatId;
                eklenecek.ImagePath = uniqFileName;
                _UnitOfWork.GetRepository<Picture>().Insert(eklenecek);
                _UnitOfWork.SaveChanges();
                return RedirectToAction("Index", "AdminPicture");
            }
            else
            {
                return View(vmodel);
            }

        }


    }
}