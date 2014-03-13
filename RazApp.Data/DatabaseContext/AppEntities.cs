
using RazApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using WebMatrix.WebData;

namespace RazApp.Data.DatabaseContext
{
    public class AppEntities : DbContext
    {
        #region Constructors
        public AppEntities() : base() { }
        #endregion

        #region DB Entities
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }

        //For error logging
        public DbSet<ErrorLog> ErrorLogs { get; set; }

        #endregion

        #region Public methods
        public virtual void Commit()
        {
            base.SaveChanges();
        }


        #endregion

        #region For fluent API usage
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }
        #endregion


        #region Private Methods
        private void SeedMemberShip()
        {
            WebSecurity.InitializeDatabaseConnection("AppEntities",
                "UserProfile", "UserId", "UserName", autoCreateTables: true);
            //For creating account in db

            string userName = "Appadmin";
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
        #endregion
    }

   
}
