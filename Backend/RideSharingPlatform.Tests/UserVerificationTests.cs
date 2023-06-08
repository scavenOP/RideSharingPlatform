using AutoMapper;
using Moq;
using NUnit.Framework;
using RideSharingPlatform.Microservices.UserVerification.BLL;
using RideSharingPlatform.Microservices.UserVerification.BLL.Exceptions;
using RideSharingPlatform.Microservices.UserVerification.DAL.Interfaces;
using RideSharingPlatform.Microservices.UserVerification.Models;
using RideSharingPlatform.Microservices.UserVerification.Models.DTOs;
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

        [Test]
        public void CreateNewApplication_Motoristnotgivinglicense_ShouldthrowException()
        {
            var application = new NewApplicationDTO
            {
                Username = "Niladri",
                Password = "password",
                OfficialEmail = "abc@gmail.com",
                PhoneNumber = "19876543212",
                Designation = "Employee",
                RoleId = 1,
                EmployeeeId = "23234",
                AadharNumber = "345478765674",
                ApplicationStatus = "New",
                CompanyId = 1,


            };

            Assert.Throws<InvalidMotoristRegistration>(() => _userService.CreateNewApplication(application));

        }

        [Test]
        public void CreateNewApplication_Motoristgivinginvalidlicense_ShouldthrowException()
        {
            var application = new NewApplicationDTO
            {
                Username = "Niladri",
                Password = "password",
                OfficialEmail = "abc@gmail.com",
                PhoneNumber = "19876543212",
                Designation = "Employee",
                RoleId = 1,
                EmployeeeId = "23234",
                AadharNumber = "345478765674",
                ApplicationStatus = "New",
                CompanyId = 1,
                LicenseNo="2342244"


            };

            Assert.Throws<InvalidDrivingLicense>(() => _userService.CreateNewApplication(application));

        }

        [Test]
        public void CreateNewApplication_Motoristgivinginvalidaadhar_ShouldthrowException()
        {
            var application = new NewApplicationDTO
            {
                Username = "Niladri",
                Password = "password",
                OfficialEmail = "abc@gmail.com",
                PhoneNumber = "19876543212",
                Designation = "Employee",
                RoleId = 1,
                EmployeeeId = "23234",
                AadharNumber = "3454787674",
                ApplicationStatus = "New",
                CompanyId = 1,
                LicenseNo = "LHN7876GTY",
                ExpirationDate=DateTime.Parse( "08/08/2023")


            };

            Assert.Throws<InvalidAadharNumber>(() => _userService.CreateNewApplication(application));

        }

        [Test]
        public void CreateNewApplication_OnWrongPhoneNumber_ShouldthrowException()
        {
            var application = new NewApplicationDTO
            {
                Username = "Niladri",
                Password = "password",
                OfficialEmail = "abc@gmail.com",
                PhoneNumber = "12345",
                Designation = "Employee",
                RoleId = 2,
                EmployeeeId = "23234",
                AadharNumber = "345478765674",
                ApplicationStatus = "New",
                CompanyId = 1,


            };

            Assert.Throws<InvalidPhoneNumber>(() => _userService.CreateNewApplication(application));

        }

    }
}
