using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aranoz.Model.Model;
using BusinessLayerAranoz;
using Aranoz.Model;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult AddProduct()
        {
            AdminViewModel product = new AdminViewModel();
            product.Product = new ProductModel();
            product.CategoryList = CategoryManager.GetAllCategory();
            return View(product);
        }
        [HttpPost]
        public ActionResult AddProduct(ProductModel product, HttpPostedFileBase file)
        {
            if (product.ProdutID > 0)
            {
                ProductManager.UpdateProduct(product);
                AdminViewModel products = new AdminViewModel();
                products.ProductList = ProductManager.CheckProductDetails();
                return View("GetAllProduct", products);
            }
            else
            { 
                if (ModelState.IsValid && file.ContentLength>0)
                { 
                    string imagesave;
                    imagesave = Uploadimage(file);
                    product.ProductImage = imagesave; 
                    long id = ProductManager.AddNewProduct(product);
                    if (id > 0)
                    {
                        AdminViewModel products = new AdminViewModel();
                        products.ProductList = ProductManager.CheckProductDetails();
                        return View("GetAllProduct", products);
                    }
                }
            }
            return View();
        }
        public ActionResult GetSingleProduct(int id)
        {
            AdminViewModel product = new AdminViewModel();
            product.Product = ProductManager.GetSingleProduct(id);
            product.CategoryList = CategoryManager.GetAllCategory();
            return View("AddProduct", product);
        }
        public ActionResult DeleteProduct(int id)
        {
            AdminViewModel product = new AdminViewModel();
            var delete = ProductManager.DeleteProduct(id);
            product.ProductList = ProductManager.CheckProductDetails();
            product.CategoryList = CategoryManager.GetAllCategory();
            return View("GetAllProduct", product);
        }
        public ActionResult GetAllProduct()
        {
            AdminViewModel product = new AdminViewModel();
            product.ProductList = ProductManager.CheckProductDetails();
            product.CategoryList = CategoryManager.GetAllCategory();
            return View(product);
        }
        public string Uploadimage(HttpPostedFileBase productimage)
        {
            string image,imageurl,savepath,imagepath;
            var file = productimage;
            image = Path.GetFileName(Guid.NewGuid() + file.FileName);
            imagepath = Server.MapPath("~/Image/");
            imageurl = Path.Combine(imagepath, image);
            savepath = "/Image/" + image;
            productimage.SaveAs(imageurl);
            return savepath;
        }
        public ActionResult SearchProduct(int id)
        {
            AdminViewModel product = new AdminViewModel();
            product.ProductSearchList = ProductManager.SeachByCategoryProduct(id);
            product.CategoryList = CategoryManager.GetAllCategory();
            return View("GetAllProduct", product);
        }
    }
}