using _2018_SG_MVC_BTPROJECT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace _2018_SG_MVC_BTPROJECT.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> getMainCategories();
        List<Category> getAllSubCategories();
        Category getMainCategory(int id);
        //List<Category> getSubCategoriesById(int mainCatid);
        IEnumerable<SelectListItem> getDrpCategories();
        List<Category> getAllCategories();
        Category getCategoryDetail(int id);

        //Ozel Metodlar
        //AdminPanelde İndex
        //List<Category> getAllCategoriesWithMainCategoryName();
        Boolean GetByIdBool(int id);
        int CountOfActiveCategory();
    }
}
