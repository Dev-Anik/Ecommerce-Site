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
        public int searchbyId { get; set; }
        public RoleModel role { get; set; }
        public List<RoleModel> rolelist { get; set; }
        public List<CategoryModel> CategoryList { get; set; }
        [Required(ErrorMessage = "Please Upload a Image")]
        public HttpPostedFileBase File { get; set; }
        [Required(ErrorMessage = "Please Upload a Image")]
        public HttpPostedFileBase[] Files { get; set; }
        public MembershipModel membership { get; set; }
        public UserModel User { get; set; }
        public CustomerInformation customer { get; set; }
    }
}
