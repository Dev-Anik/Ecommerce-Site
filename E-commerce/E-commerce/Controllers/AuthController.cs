using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using System.Web.UI.WebControls;
using Aranoz.Model.Model;
using E_commerce.AuthControl;
using System.Configuration.Provider;

namespace E_commerce.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult AddNewRole()
        {
            AdminViewModel membership = new AdminViewModel();
            var roles = new AuthenticanProvider();
            membership.rolelist = roles.GetAllRoleList();
            membership.role = new RoleModel();
            return View(membership);
        }
        [HttpPost]
        public ActionResult AddNewRole(RoleModel role)
        {
            AdminViewModel membership = new AdminViewModel();
            var rolename = role.RoleName;
            var roles = new AuthenticanProvider();
            var id = roles.AddNewRole(rolename);
            membership.rolelist = roles.GetAllRoleList();
            return View(membership);
        }
        public ActionResult DeleteRole(string Id)
        {
            var deleterole = Roles.DeleteRole(Id);
            AdminViewModel memberships = new AdminViewModel();
            var member = new AuthenticanProvider();
            memberships.rolelist = member.GetAllRoleList();
            return View("AddNewRole", memberships);
        }
    }
}