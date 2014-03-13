using RazApp.Data.Infrastructure;
using RazApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazApp.Domain.Repository.IRepository
{
    public interface IUserRepository : IRepository<UserProfile>
    {

        //Add additional methods from Repository base
    }
}
