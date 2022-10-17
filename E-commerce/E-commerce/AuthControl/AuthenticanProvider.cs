using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using Aranoz.Model;
using Aranoz.Model.Model;
using Aranoz.Utility;


namespace E_commerce.AuthControl
{
    public class AuthenticanProvider
    {
        public bool AddNewRole(string role)
        {
            bool added = true;
            try
            {
                if (!Roles.RoleExists(role))
                {
                    Roles.CreateRole(role);
                }
            }
            catch (Exception ex)
            {
                added = false;
                throw new Exception("Message" + ex);
            }

            return added;
        }

        public bool AddNewMembershipUser(MembershipModel membershipmodel)
        {
            bool added = true;
            var check = Roles.IsUserInRole(membershipmodel.UserName, "Customer");
            try
            {

                if (membershipmodel != null && check == false)
                {
                    var membershipitem = Membership.CreateUser(membershipmodel.UserName, membershipmodel.password,
                        membershipmodel.Email);
                }
                else
                {
                    added = false;
                    return added;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Message" + ex);
            }

            return added;
        }

        public List<RoleModel> GetAllRoleList()
        {
            var roleitem = Roles.GetAllRoles();
            List<RoleModel> rolelist = new List<RoleModel>();
            foreach (var item in roleitem)
            {
                RoleModel role = new RoleModel();
                role.RoleName = item;
                rolelist.Add(role);
            }

            return rolelist;
        }
    }
}