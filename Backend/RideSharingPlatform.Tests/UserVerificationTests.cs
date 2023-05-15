using AutoMapper;
using Moq;
using NUnit.Framework;
using RideSharingPlatform.Microservices.UserVerification.BLL;
using RideSharingPlatform.Microservices.UserVerification.DAL.Interfaces;
using RideSharingPlatform.Microservices.UserVerification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharingPlatform.Tests
{
    [TestFixture]
    internal class UserVerificationTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<ICompanyRepository> _companyRepositoryMock;
        private UserService _userService;
        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock= new Mock<IUserRepository>();
            _companyRepositoryMock= new Mock<ICompanyRepository>();
            _userService = new UserService(_userRepositoryMock.Object,_companyRepositoryMock.Object,mapper);
        }

        [Test]
        public void GetCompanies_ShouldReturnListOfCompanies()
        {
            var companies = new List<Company>
            {
                new Company
                {
                    Id = 1,
                    CompanyName = "Cognizant",
                    BuildingName = "Unitech",
                    SecurityInChargeName = "Amit Sau",
                    SecurityHelpDeskNumber = "92123456789"
                },
                new Company
                {
                    Id = 2,
                    CompanyName = "Accenture",
                    BuildingName = "B1",
                    SecurityInChargeName = "Ranjit Dey",
                    SecurityHelpDeskNumber = "92123456779"
                }

            };
            _companyRepositoryMock.Setup(x => x.GetAllCompanies()).Returns(companies);

            var result = _userService.GetAllCompanies();

            Assert.That(result, Is.EqualTo(companies));
        } 

    }
}
