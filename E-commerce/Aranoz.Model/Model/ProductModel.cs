using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Aranoz.Model
{
    public class ProductModel
    {
        public int ProdutID { get; set; }
        [Required(ErrorMessage = "Product Name is Required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Category Required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Price Required")]
        public int ProductPrice { get; set; }
        public string ProductImage { get; set; }
        [Required(ErrorMessage = "Product Details is Required")]
        public string ProductDetails { get; set; }
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Product Details is Required")]
        public int TotalProduct { get; set; }
    }
}
