using RazApp.Web.Models;
using System.Web.Security;
using WebMatrix.WebData;

namespace RazApp.Helpers
{
    public static class AuthenticationHelper
    {
        public static void CreateUserAccountWithRoleAndLogin(RegisterModel model,string Role)
        {
            //For creating account in db
            WebSecurity.CreateUserAndAccount(model.UserName, model.Password,
                        new
                        {                           
                            Email = model.Email,                                                    
                            IsActive = true
                        });

            //For login with created account
            WebSecurity.Login(model.UserName, model.Password);
           
            //For assigning role to new account
            if (!Roles.RoleExists(Role))
                Roles.CreateRole(Role);
            Roles.AddUserToRole(model.UserName, Role);
        }
    }
}
