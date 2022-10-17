using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aranoz.Model.Model;
using BusinessLayerAranoz;
using Aranoz.Model;

namespace E_commerce.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult AddCategory()
        {
            AdminViewModel category = new AdminViewModel();
            category.Category = new CategoryModel();
            category.CategoryList = CategoryManager.GetAllCategory();
            return View(category);
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryModel category)
        {
            if (category.CategoryId > 0)
            {
                AdminViewModel categorys = new AdminViewModel();
                CategoryManager.UpdateCategory(category);
                categorys.CategoryList = CategoryManager.GetAllCategory();
                return View(categorys);
            }
            else
            {
                AdminViewModel categorys = new AdminViewModel();
                var categoryid= CategoryManager.AddNewCategory(category);
                categorys.CategoryList = CategoryManager.GetAllCategory();
                categorys.Category = new CategoryModel();
                if (categoryid > 0) 
                {
                   return View("AddCategory",categorys);
                }
            }
            return View();
        }
        public ActionResult GetSingleCategory(int Id)
        {
            AdminViewModel category = new AdminViewModel();
            category.Category = CategoryManager.GetSingleCategory(Id);
            category.CategoryList = CategoryManager.GetAllCategory();
            return View("AddCategory",category);
        }
        public ActionResult DeleteCategory(int Id)
        {
            AdminViewModel category = new AdminViewModel();
            var categorydelete = CategoryManager.DeleteCategory(Id);
            category.CategoryList = CategoryManager.GetAllCategory();
            return View("AddCategory",category);
        }
    }
}