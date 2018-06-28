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
    public class AdminCategoryController : Controller
    {
        
        private ICategoryService _CategoryService;
        private IUnitOfWork _UnitOfWork;

        public AdminCategoryController(ICategoryService categoryService,IUnitOfWork unitOfWork)
        {
            _CategoryService = categoryService;
            _UnitOfWork = unitOfWork;
        }
      
        // GET: AdminPanel/AdminCategory
        public ActionResult Index()
        {
            var model = _CategoryService.getAllCategories();
            List<CategoryVM> category = model.Select(cat => new CategoryVM
            {
                Id = cat.Id,
                Name = cat.Name,
                Description = cat.Description,
                TopCatId = cat.TopCatId,
                TopCatName = _CategoryService.GetByIdBool(cat.TopCatId) == true ? "ANAKATEGORİ" : _CategoryService.getCategoryDetail(cat.TopCatId).Name,
                ServiceDescription = cat.ServiceDescription,
                CatImage = cat.CatImage
            }).ToList();
            return View(category);

            //List<CategoryVM> lcvm = new List<CategoryVM>();
            //CategoryVM cvm = new CategoryVM();
            //foreach (var item in model)
            //{
            //    cvm.Name = item.Name;
            //    cvm.Description = cvm.Description;
            //    cvm.TopCatId = item.TopCatId;
            //    if (item.TopCatId!=0)
            //    {
            //        cvm.TopCatName = _CategoryService.getCategoryDetail(item.TopCatId).Name;
            //    }
            //    else
            //    {
            //        cvm.TopCatName = "ANA KATEGORİ";
            //    }
            //    cvm.ServiceDescription = item.ServiceDescription;
            //    cvm.CatImage = item.CatImage;
            //    lcvm.Add(cvm);
            //} 
            //return View();
        }


        [HttpGet]
        public ActionResult CategoryDetail(int id)
        { 
            Category gelenCat = _CategoryService.getCategoryDetail(id);
            CategoryVM gosterilen = new CategoryVM();
            gosterilen.Id = gelenCat.Id;
            gosterilen.Name = gelenCat.Name;
            gosterilen.ServiceDescription = gelenCat.ServiceDescription;
            gosterilen.drpcategories = _CategoryService.getAllCategories().Select(cat => new SelectListItem()
            {
                Text = cat.Name,
                Value = cat.Id.ToString()
            }).ToList();
            gosterilen.TopCatId = gelenCat.TopCatId;
            gosterilen.CatImage = gelenCat.CatImage;
            return View(gosterilen);
        }
        string OrgimagePath = "~/Upload/Category/OrjPath";
        string SmallimagePath = "~/Upload/Category/SmallPath";
        string LargeimagePath = "~/Upload/Category/LargePath";
         
        [HttpPost]
        public ActionResult CategoryDetail(CategoryVM modelCategory, HttpPostedFileBase resim)
        {
            //Category gelenCat = _CategoryService.getCategoryDetail(gelenCategory.Id);
            Category gelenCat = _UnitOfWork.GetRepository<Category>().GetById(modelCategory.Id);

            gelenCat.Id = gelenCat.Id;
            gelenCat.Name = modelCategory.Name;
            gelenCat.ServiceDescription = modelCategory.ServiceDescription;
            gelenCat.TopCatId = modelCategory.TopCatId;
             
            if (resim == null && modelCategory.CatImage != "default.png")
                gelenCat.CatImage = modelCategory.CatImage;
            else if (resim == null)
                gelenCat.CatImage = "default.png";
            else
            {
                Image photoThumb = Image.FromStream(resim.InputStream, true, true);
                ImageUploadService svc = ImageUploadService.CreateService(resim);
                string uniqFileName = svc.CreateUniqName(resim.FileName, OrgimagePath);

                svc.Upload(OrgimagePath, SmallimagePath, LargeimagePath, uniqFileName);
                gelenCat.CatImage = uniqFileName;
            }
             
            _UnitOfWork.GetRepository<Category>().Update(gelenCat);
            _UnitOfWork.SaveChanges();
            return RedirectToAction("Index", "AdminCategory");

        }


        public ActionResult InsertCategory()
        {
            CategoryVM model = new CategoryVM(); 
            model.drpcategories = _CategoryService.getDrpCategories();
            return View(model); 
        }

        [HttpPost]
        public ActionResult InsertCategory(CategoryVM gelenCategory, HttpPostedFileBase resim)
        {
            string OrgimagePath = "~/Upload/Category/OrjPath";
            string SmallimagePath = "~/Upload/Category/SmallPath";
            string LargeimagePath = "~/Upload/Category/LargePath";
            string uniqFileName = "";
            ImageUploadService svc = ImageUploadService.CreateService(resim);
            uniqFileName = svc.CreateUniqName(resim.FileName, OrgimagePath);
            
            CategoryVM vmodel = new CategoryVM(); 
            vmodel.drpcategories = _CategoryService.getDrpCategories(); 
            Category eklenecek = new Category(); 
            if (gelenCategory.TopCatId == 0)
            { 
                if (resim != null)
                { 
                    svc.Upload(OrgimagePath, SmallimagePath, LargeimagePath, uniqFileName);
                }
                eklenecek.Name = gelenCategory.Name;
                eklenecek.Description = gelenCategory.Description;
                eklenecek.CatImage = uniqFileName;
                eklenecek.ServiceDescription = gelenCategory.ServiceDescription;
                eklenecek.TopCatId = 0;
                _UnitOfWork.GetRepository<Category>().Insert(eklenecek);
                _UnitOfWork.SaveChanges();
                return RedirectToAction("Index", "AdminCategory"); 
            }
            else
            { 
                if (ModelState.IsValid)
                {
                    if (resim != null)
                    {
                        svc.Upload(OrgimagePath, SmallimagePath, LargeimagePath, uniqFileName);
                    }
                    eklenecek.Name = gelenCategory.Name;
                    eklenecek.Description = gelenCategory.Description;
                    eklenecek.CatImage = uniqFileName;
                    eklenecek.ServiceDescription = gelenCategory.ServiceDescription; 
                    eklenecek.TopCatId = gelenCategory.TopCatId; 
                    _UnitOfWork.GetRepository<Category>().Insert(eklenecek);
                    _UnitOfWork.SaveChanges();
                    return RedirectToAction("Index", "AdminCategory");
                }
                else
                {
                    return View(vmodel);
                }
            }

        }


        //[HttpPost]
        //public ActionResult DeleteCategory(int id)
        //{
        //    Category gelenCat = _CategoryService.getCategoryDetail(id);
        //    //CategoryVM gosterilen = new CategoryVM();
        //    //gosterilen.Id = gelenCat.Id;
        //    //gosterilen.Name = gelenCat.Name;
        //    //gosterilen.ServiceDescription = gelenCat.ServiceDescription;
        //    //gosterilen.drpcategories = _CategoryService.getAllCategories().Select(cat => new SelectListItem()
        //    //{
        //    //    Text = cat.Name,
        //    //    Value = cat.Id.ToString()
        //    //}).ToList();
        //    //gosterilen.TopCatId = gelenCat.TopCatId;
        //    //gosterilen.CatImage = gelenCat.CatImage;
        //    _UnitOfWork.GetRepository<Category>().Delete(gelenCat);
        //    _UnitOfWork.SaveChanges();
        //    return RedirectToAction("Index", "AdminCategory");
        //}


        public JsonResult DeleteCategory2(int CategoryId)
        {
            Category gelenCat = _CategoryService.getCategoryDetail(CategoryId);
            bool result = false; 
            _UnitOfWork.GetRepository<Category>().Delete(CategoryId);
            _UnitOfWork.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
          
        }



    }
}