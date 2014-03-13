using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazApp.Domain.Model
{
    public class UserDetail
    {
        [Key]
        public int UserDetailId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Address { get; set; }
        public string Mobile { get; set; }
        public string PinCode { get; set; }
   
    
        public virtual UserProfile User { get; set; }
    }
}
