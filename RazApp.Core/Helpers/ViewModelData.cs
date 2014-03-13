using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazApp.Core.Helpers
{

    public class ViewModelData<T> where T : class
    {
        public IEnumerable<T> ListData { get; set; }
        public T SigleData { get; set; }
        public string ReturnMessage { get; set; }
      
    }

}