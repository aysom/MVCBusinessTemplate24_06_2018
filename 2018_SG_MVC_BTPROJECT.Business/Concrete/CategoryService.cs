using _2018_SG_MVC_BTPROJECT.Business.Abstract;
using _2018_SG_MVC_BTPROJECT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace _2018_SG_MVC_BTPROJECT.Business.Concrete
{
    public class CategoryService :ICategoryService
    {
        private _2018_SG_MVC_BTPROJECT.Business.UnitOfWork.UnitOfWork _uow = null;

        public CategoryService()
        {
            _uow = new _2018_SG_MVC_BTPROJECT.Business.UnitOfWork.UnitOfWork();
        }

        public List<Category> getAllCategories()
        {
            var a = _uow.GetRepository<Category>().GetAll().ToList();
            return a;
        }

       
        public List<Category> getAllSubCategories()
        {
            var a = _uow.GetRepository<Category>().Where(c => c.TopCatId == 0).ToList();
            return a;
        }

        public Category getCategoryDetail(int id)
        {
           return  _uow.GetRepository<Category>().GetAll().FirstOrDefault(x => x.Id == id);
            
        }

        public IEnumerable<SelectListItem> getDrpCategories()
        {
            IEnumerable<SelectListItem> drpcategories = _uow.GetRepository<Category>().GetAll().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            return drpcategories;
        }

        public List<Category> getMainCategories()
        {
            var a = _uow.GetRepository<Category>().Where(c => c.TopCatId == 0).ToList();
            return a;
        }

        public Category getMainCategory(int id)
        {
            throw new NotImplementedException();
        }

        public bool GetByIdBool(int id)
        {
            if (id == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int CountOfActiveCategory()
        {
            int a = _uow.GetRepository<Category>().Where(c => c.TopCatId == 0).Count;
            return a;
        }

        //public List<Category> getSubCategoriesById(int mainCatid)
        //{

        //}

        //public List<Category> getAllCategoriesWithMainCategoryName()
        //{
        //    var model = _uow.GetRepository<Category>().GetAll();
        //    var model2 = _uow.GetRepository<Category>();


        //}

    }
}
