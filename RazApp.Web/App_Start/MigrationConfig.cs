using RazApp.Data.DatabaseContext;
using RazApp.Data.Migrations;
using RazApp.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace RazApp.Web
{
    public static class MigrationConfig
    {
        public static void MigrateOrSeed()
        {
            Database.SetInitializer(new DBChangeInitializer());
            if (Database.Exists("AppEntities"))
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppEntities, Configuration>());
            }
            new AppEntities().Database.Initialize(true);  
        }
    }
}