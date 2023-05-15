using AutoMapper;
using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.UserVerification.DAL;
using RideSharingPlatform.Microservices.UserVerification.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using RideSharingPlatform.Microservices.UserVerification.Models.DTOs;
using RideSharingPlatform.Microservices.UserVerification.BLL.Exceptions;
using RideSharingPlatform.Authentication.Models;
using RideSharingPlatform.Microservices.UserVerification.DAL.Interfaces;

namespace RideSharingPlatform.Microservices.UserVerification.BLL
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public RideDbContext context;
        public UserService(IUserRepository userRepository,ICompanyRepository companyRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        //For testing purpose-----------
        public UserService(IUserRepository userRepository,ICompanyRepository companyRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
        }
        //--------------------------

        public List<Company> GetAllCompanies()
        {
            return _companyRepository.GetAllCompanies();
        }

        public bool CreateNewApplication(NewApplicationDTO application)
        {

            if (application.RoleId == 1 && application.LicenseNo == null)
            {

                throw new InvalidMotoristRegistration("Invalid Motorist Registration : Driving License is required.");
            }

            if (application.RoleId == 1)
            {
                if (!IsValidDrivingLicense(application.LicenseNo, application.ExpirationDate))
                {
                    throw new InvalidDrivingLicense("Invalid Driving License");
                }
            }

            if (application.AadharNumber.Length != 12)
            {
                throw new InvalidAadharNumber("Invalid Aadhar Number");
            }
            if (application.PhoneNumber.Length != 10 || !application.PhoneNumber.StartsWith("9"))
            {
                throw new InvalidPhoneNumber("Invalid Phone Number");
            }

            UserApplication applicationUser = _mapper.Map<UserApplication>(application);
            DrivingLicense license = _mapper.Map<DrivingLicense>(application);


            if (_userRepository.InsertnewApplication(applicationUser, license) > 0)
            {

                return true;


            }

            return false;


        }

        private bool IsValidDrivingLicense(string licenseNo, DateTime? expirationDate)
        {
            Regex regex = new Regex("^[A-Z]{3}[0-9]{4}[A-Z]{3}$");
            if (!regex.IsMatch(licenseNo))
            {
                return false;
            }
            if (expirationDate < DateTime.Today)
            {
                return false;
            }
            return true;
        }

        public List<showapplicationDTO> GetAllPendingApplications()
        {
            List<showapplicationDTO> pendingapplications = new List<showapplicationDTO>();

            var userapplications = _userRepository.GetPendingApplications();

            foreach (var application in userapplications)
            {
                showapplicationDTO app = _mapper.Map<showapplicationDTO>(application);
                var license = _userRepository.GetDrivingLicense(application.UserId);
                //_mapper.Map<Application>(license);
                if (license!=null)
                {
                    app.LicenseNo = license.LicenseNo;
                    app.ExpirationDate = license.ExpirationDate;
                    app.RTA = license.RTA;
                    app.AlowedVehicles = license.AlowedVehicles;
                }
                
                //app.role = application.Role.Name;
                pendingapplications.Add(app);
            }

            return pendingapplications;
        }
        public showapplicationDTO GetPendingApplicationById(int userId)
        {
            var application = _userRepository.GetPendingApplicationByUserId(userId);

            showapplicationDTO app = _mapper.Map<showapplicationDTO>(application);
            var license = _userRepository.GetDrivingLicense(application.UserId);
            //_mapper.Map<Application>(license);
            app.LicenseNo = license.LicenseNo;
            app.ExpirationDate = license.ExpirationDate;
            app.RTA = license.RTA;
            app.AlowedVehicles = license.AlowedVehicles;

            return app;
        }
        public bool UpdateApplication(UpdateApplicationDTO application)
        {
            UserApplication app = _userRepository.GetPendingApplicationByUserId(application.UserId);
            if (application.ApplicationStatus == "Rejected")
            {
                app.ApplicationStatus = "Rejected";
                var r = _userRepository.RejectApplication(app);
                if (r > 0)
                {
                    return true;
                }
                return false;
            }
            AuthUser user = _mapper.Map<AuthUser>(app);
            user.Email = app.OfficialEmail;
            user.Password = app.Password;
            user.Phone = app.PhoneNumber;
            app.ApplicationStatus = "Approved";
            int f = _userRepository.ApproveApplication(app, user);
            if (f > 0)
            {
                return true;
            }
            return false;

        }
    }
}
