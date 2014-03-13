using RazApp.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RazApp.Web.API
{
    public class UserController : ApiController
    {
        #region Dependency Injection

        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            this.userService = _userService;
        }
        #endregion

        // GET api/default1
        public Domain.Model.UserProfile Get(string username)
        {
            var user = userService.GetUserByUserName(username);
            return user;
        }

     
    }
}
