using System;
using NUnit.Framework;
using Moq;
using RazApp.Domain.Repository.IRepository;
using RazApp.Service.Services;
using RazApp.Data.Infrastructure;
using RazApp.Web.Mailers;
using RazApp.Web.Controllers;
using System.Web.Mvc;

namespace RazApp.Web.Test.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        #region Mock Items
        //Repository
        Mock<IUserRepository> mockUserRepository;

        //Service
        IUserService mockUserService;

        //Infrastructure
        Mock<IUnitOfWork> mockUnitOfWork;



        #endregion

        #region Mock SetUp
        [SetUp]
        public void SetUp()
        {
            //Infrastructure
            mockUnitOfWork = new Mock<IUnitOfWork>();

            //Repository
            mockUserRepository = new Mock<IUserRepository>();

            //Service
            mockUserService = new UserService(mockUserRepository.Object, mockUnitOfWork.Object);

        }

        [TearDown]
        public void TearDown()
        {

        }
        #endregion

        #region Test Methods

        [Test]
        public void Index_Returns_Null()
        {
            HomeController controller = new HomeController(mockUserService);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
        #endregion

    }
}
