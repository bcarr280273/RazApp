using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazApp.Domain.Model
{
    public class ErrorLog
    {
        [Key]
        public int LogId { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
        public string HelpLink { get; set; }
        public string StackTrace { get; set; }
        public DateTime TimeOccured { get; set; }
        
    }
}
