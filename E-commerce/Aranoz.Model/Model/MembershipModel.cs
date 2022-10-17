using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aranoz.Model.Model
{
    public class CustomerInformation
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Full Name is Required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression("[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,3}$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        public string CustomerImage { get; set; }
        public MembershipModel Membership { get; set; }
    }
    public class MembershipModel
    {
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "password is Required")]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}", ErrorMessage = "Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters")]
        public string password { get; set; }
        [Required(ErrorMessage = "Confirm password is Required")]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}", ErrorMessage = "Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters")]
        public string Confirmpassword { get; set; }
        public string Email { get; set; }
    }
}
