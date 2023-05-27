using Microsoft.EntityFrameworkCore;
using RideSharingPlatform.Authentication.Models;
using RideSharingPlatform.Microservices.IncidentManagement.Models;
using RideSharingPlatform.Microservices.RideManagement.Models;
using RideSharingPlatform.Microservices.UserVerification.Models;
using RideSharingPlatform.Microservices.VehicleManagement.Models;

namespace RideSharingPlatform.Context
{
    public class RideDbContext : DbContext
    {
        public RideDbContext(DbContextOptions<RideDbContext> options) : base(options)
        {

        }

        //microservice-user verification
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }
        public DbSet<DrivingLicense> DrivingLicenses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AuthUser> AuthUser { get; set; }

        //microservice-vehicle management
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDetail> VehicleDetails { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }

        //microservice-ride management
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Distance> Distances { get; set; }
        public DbSet<RideSchedule> RideSchedules { get; set; }  

        // microservices-incident management
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentTypes> IncidentTypes { get; set; }

        public DbSet<InvestigationDetails> InvestigationDetails { get; set; }

        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Motorist"
                },
                new Role
                {
                    Id = 2,
                    Name = "Rider"
                },
                new Role
                {
                    Id = 3,
                    Name = "SecurityHead"
                });

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    CompanyName = "Cognizant",
                    BuildingName = "Unitech",
                    SecurityInChargeName = "Amit Sau",
                    SecurityHelpDeskNumber = "92123456789"
                }
                );

            modelBuilder.Entity<UserApplication>().HasData(
                new UserApplication
                {
                    UserId = 1,
                    Username = "Niladri",
                    OfficialEmail = "niladri@cts.com",
                    PhoneNumber = "9123456789",
                    Designation = "Intern",
                    RoleId = 1,
                    EmployeeeId = "345678",
                    AadharNumber = "786556784567",
                    ApplicationStatus = "New",
                    CompanyId = 1,
                    Password = "Niladri@123"
                });
            modelBuilder.Entity<DrivingLicense>().HasData(
                new DrivingLicense
                {
                    Id = 1,
                    LicenseNo = "FER6578HYU",
                    ExpirationDate = DateTime.Parse("2023-07-19"),
                    RTA = "Beltala",
                    AlowedVehicles = "Bike",
                    UserId = 1
                });

            modelBuilder.Entity<AuthUser>().HasData(
                new AuthUser
                {
                    Id = 1,
                    UserName = "Amit Sau",
                    Email = "amit@cts.com",
                    Phone = "92123456789",
                    Password = "Amit@123",
                    RoleId = 3
                });

            //microservice-vehicle management

            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType
                {
                    ID = 1,
                    Type = "SUV",
                    MaxPassengersAllowed = 7,
                    FarePerKM = 13
                },
                 new VehicleType
                 {
                     ID = 2,
                     Type = "Sedan",
                     MaxPassengersAllowed = 4,
                     FarePerKM = 12
                 },
                  new VehicleType
                  {
                      ID = 3,
                      Type = "2Wheeler",
                      MaxPassengersAllowed = 1,
                      FarePerKM = 9
                  }
                );

            //microservice-ride management

            modelBuilder.Entity<Distance>().HasData(
                new Distance
                {
                    ID=1,
                    From="Unitech",
                    To="Dunlop",
                    DistanceInKMS= 10,
                },
                new Distance
                {
                    ID = 2,
                    From = "Unitech",
                    To = "SlatLake",
                    DistanceInKMS = 5,
                }
                );
            //microservice-incident management

            modelBuilder.Entity<IncidentTypes>().HasData(
                
                new IncidentTypes
                {
                    Id = 1,
                    Types = "Accident",
                    ExpectedSLAInDays = 1
                },
                new IncidentTypes
                {
                    Id = 2,
                    Types = "Theft",
                    ExpectedSLAInDays = 2
                },
                new IncidentTypes
                {
                    Id = 3,
                    Types = "Driver Misbehave",
                    ExpectedSLAInDays = 1
                }
             
            );

        }
    }
}
