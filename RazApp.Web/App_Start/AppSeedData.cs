using RazApp.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace RazApp.Web.App_Start
{
    public class DBChangeInitializer : CreateDatabaseIfNotExists<AppEntities>
    {

        protected override void Seed(AppEntities context)
        {
            base.Seed(context);
            // this.SeedMemberShip();
            this.ExecuteSQL(context);

        }

        private void SeedMemberShip()
        {
            WebSecurity.InitializeDatabaseConnection("AppEntities",
                "UserProfile", "UserId", "UserName", autoCreateTables: true);
            ////For creating account in db


            string userName = "admin";
            string password = "p@ssw0rd";
            WebSecurity.CreateUserAndAccount(userName, password,
                        new
                        {
                            MobileNumber = "000000",
                            Email = "appadmin@razapp.com",
                            Address = "Super admin with all access",
                            IsActive = true
                        });

            //For login with created account
            WebSecurity.Login(userName, password);
            string Role = "Super Admin";
            //For assigning role to new account
            if (!Roles.RoleExists(Role))
                Roles.CreateRole(Role);
            Roles.AddUserToRole(userName, Role);
        }

        private void ExecuteSQL(AppEntities context)
        {
            if (context.Database.Exists())
            {
                //code to read and execute sql file
                string SQLStatementsFilePath = System.Configuration.ConfigurationManager.AppSettings["SQLStatements"];
                SQLStatementsFilePath = System.Web.HttpContext.Current != null ?
                    SQLStatementsFilePath.Replace("[AppData]", System.Web.HttpContext.Current.Server.MapPath("/App_Data")) : SQLStatementsFilePath;

                FileInfo file = new FileInfo(SQLStatementsFilePath);
                string SQLScript = file.OpenText().ReadToEnd();

                string[] scripts = SQLScript.Split(new string[] { "GO" }, StringSplitOptions.None);
                if (scripts.Count() > 0)
                {
                    for (int index = 0; index < scripts.Count(); index++)
                    {
                        if (scripts[index] != "")
                        {
                            context.Database.ExecuteSqlCommand(scripts[index]);
                        }
                    }
                }
            }
        }


    }
}