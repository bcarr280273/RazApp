using RazApp.Core.ErrorLogging;
using RazApp.Core.Validations;
using RazApp.Data.Infrastructure;
using RazApp.Domain.Model;
using RazApp.Domain.Repository.IRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazApp.Service.Services
{
    #region Contracts
    public interface IUserService
    {
        UserProfile GetUserByUserName(string userName);
        void CreateUserProfile(UserProfile user);
        IEnumerable<ValidationResult> CanAddUser(UserProfile user);

        void CommitChanges();
    }
    #endregion


    #region Contract Implementations
    public class UserService : IUserService
    {
        #region Dependency Injuction

        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUserRepository _userRepository, IUnitOfWork _unitOfWork)
        {
            this.userRepository = _userRepository;
            this.unitOfWork = _unitOfWork;
        }

        #endregion


        public Domain.Model.UserProfile GetUserByUserName(string userName)
        {
            return userRepository.Get(a => a.UserName.ToLower() == userName.ToLower());
        }

        public void CreateUserProfile(Domain.Model.UserProfile user)
        {
            try
            {
                userRepository.Add(user);
                CommitChanges();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
            }
        }


        public IEnumerable<ValidationResult> CanAddUser(Domain.Model.UserProfile user)
        {
            throw new NotImplementedException();
        }


        public void CommitChanges()
        {
            unitOfWork.Commit();
        }
    }

    #endregion
}
