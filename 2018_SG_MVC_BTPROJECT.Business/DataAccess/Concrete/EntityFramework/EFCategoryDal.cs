
using _2018_SG_MVC_BTPROJECT.Business.DataAccess.Abstract;
using _2018_SG_MVC_BTPROJECT.Business.UnitOfWork;
using _2018_SG_MVC_BTPROJECT.Entities; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace _2018_SG_MVC_BTPROJECT.Business.DataAccess.Concrete.EntityFramework
{
    public class EFCategoryDal : ICategoryDal
    {
        private IUnitOfWork _unitOfWork = null;

        public EFCategoryDal()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<Category> getAllSubCategories()
        {
            return _unitOfWork.GetRepository<Category>().Where(c => c.TopCatId != 0).ToList();
        }

        public IEnumerable<SelectListItem> getDrpCategories()
        {
            IEnumerable<SelectListItem> drpcategories = _unitOfWork.GetRepository<Category>().GetAll().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            return drpcategories;
        }

        /// <summary>
        /// üst kategorisi 0 olanları getirir
        /// </summary>
        /// <returns></returns>
        public List<Category> getMainCategories()
        {
            var a = _unitOfWork.GetRepository<Category>().Where(c => c.TopCatId == 0).ToList();
            return a;
        }

        public Category getMainCategory(int id)
        {
            return getMainCategories().FirstOrDefault(cat => cat.TopCatId == id);
        }

        public List<Category> getSubCategoriesById(int mainCatid)
        {
            var s = _unitOfWork.GetRepository<Category>().GetAll().Where(cat => cat.TopCatId == mainCatid).ToList();
            return s;
        }
    }





}
