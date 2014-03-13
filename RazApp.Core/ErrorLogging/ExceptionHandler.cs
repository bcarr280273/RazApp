using RazApp.Data.DatabaseContext;
using RazApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazApp.Core.ErrorLogging
{
    public static class ExceptionHandler
    {
        public static void LogException(Exception ex)
        {
            using (AppEntities entity = new AppEntities())
            {
                entity.ErrorLogs.Add(new ErrorLog
                {
                    HelpLink = ex.HelpLink,
                    InnerException = ex.InnerException.Message,
                    Message = ex.Message,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace,
                    TimeOccured = DateTime.Now
                });
            }
        }
    }
}
