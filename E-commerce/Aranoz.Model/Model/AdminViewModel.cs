using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aranoz.Model.Model;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Aranoz.Model.Model
{
    public class AdminViewModel
    {
        public ProductModel Product { get; set; }
        public List<ProductModel> ProductList { get; set; }
        public List<ProductModel> ProductSearchList { get; set; }
        public CategoryModel Category { get; set; }
        public RoleModel role { get; set; }
        public List<RoleModel> rolelist { get; set; }
        public List<CategoryModel> CategoryList { get; set; }
        [Required(ErrorMessage = "Please Upload a Image")]
        public HttpPostedFileBase File { get; set; }
        public UserModel User { get; set; }
        public List<CustomerInformation> customerlist { get; set; }
        public  CustomerInformation Customer { get; set; }
        public int TotalProduct { get; set; }
        public int TotalOrder { get; set; }
        public int TotalCustomer { get; set; }
    }
}
