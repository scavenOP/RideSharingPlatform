using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideSharingPlatform.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityInChargeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityHelpDeskNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Types = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedSLAInDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDetails",
                columns: table => new
                {
                    RegistrationNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RTOName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RCDocURL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InsuranceCompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsuranceNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    InsurancedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceCertificateDOCURL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PUCCertificateNo = table.Column<int>(type: "int", nullable: false),
                    PUCIssuedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PUCValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PUCDOCURL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetails", x => x.RegistrationNo);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaxPassengersAllowed = table.Column<int>(type: "int", nullable: false),
                    FarePerKM = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IncidentReportedByUserId = table.Column<int>(type: "int", nullable: false),
                    ResolutionETA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvestigatedByUserId = table.Column<int>(type: "int", nullable: false),
                    IncidentSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncidentDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncidentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentID);
                    table.ForeignKey(
                        name: "FK_Incidents_IncidentTypes_IncidentTypeId",
                        column: x => x.IncidentTypeId,
                        principalTable: "IncidentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthUser_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserApplications",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficialEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    EmployeeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApplications", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserApplications_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserApplications_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    RegistrationNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BelongsToUserId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    InspectionStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    InspectionByUserId = table.Column<int>(type: "int", nullable: true),
                    InspectedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.RegistrationNo);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestigationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Finding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suggestions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InverstigationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IncidentsIncidentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestigationDetails_Incidents_IncidentsIncidentId",
                        column: x => x.IncidentsIncidentId,
                        principalTable: "Incidents",
                        principalColumn: "IncidentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrivingLicenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RTA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlowedVehicles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivingLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrivingLicenses_UserApplications_UserId",
                        column: x => x.UserId,
                        principalTable: "UserApplications",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BuildingName", "CompanyName", "SecurityHelpDeskNumber", "SecurityInChargeName" },
                values: new object[] { 1, "Unitech", "Cognizant", "92123456789", "Amit Sau" });

            migrationBuilder.InsertData(
                table: "IncidentTypes",
                columns: new[] { "Id", "ExpectedSLAInDays", "Types" },
                values: new object[,]
                {
                    { 1, 1, "Accident" },
                    { 2, 2, "Theft" },
                    { 3, 1, "Driver Misbehave" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Motorist" },
                    { 2, "Rider" },
                    { 3, "SecurityHead" }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "ID", "FarePerKM", "MaxPassengersAllowed", "Type" },
                values: new object[,]
                {
                    { 1, 13, 7, "SUV" },
                    { 2, 12, 4, "Sedan" },
                    { 3, 9, 1, "2Wheeler" }
                });

            migrationBuilder.InsertData(
                table: "AuthUser",
                columns: new[] { "Id", "Email", "Password", "Phone", "RoleId", "UserName" },
                values: new object[] { 1, "amit@cts.com", "Amit@123", "92123456789", 3, "Amit Sau" });

            migrationBuilder.InsertData(
                table: "UserApplications",
                columns: new[] { "UserId", "AadharNumber", "ApplicationStatus", "CompanyId", "Designation", "EmployeeeId", "OfficialEmail", "Password", "PhoneNumber", "RoleId", "Username" },
                values: new object[] { 1, "786556784567", "New", 1, "Intern", "345678", "niladri@cts.com", "Niladri@123", "9123456789", 1, "Niladri" });

            migrationBuilder.InsertData(
                table: "DrivingLicenses",
                columns: new[] { "Id", "AlowedVehicles", "ExpirationDate", "LicenseNo", "RTA", "UserId" },
                values: new object[] { 1, "Bike", new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "FER6578HYU", "Beltala", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AuthUser_RoleId",
                table: "AuthUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_DrivingLicenses_UserId",
                table: "DrivingLicenses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentTypeId",
                table: "Incidents",
                column: "IncidentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationDetails_IncidentsIncidentId",
                table: "InvestigationDetails",
                column: "IncidentsIncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserApplications_CompanyId",
                table: "UserApplications",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserApplications_RoleId",
                table: "UserApplications",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthUser");

            migrationBuilder.DropTable(
                name: "DrivingLicenses");

            migrationBuilder.DropTable(
                name: "InvestigationDetails");

            migrationBuilder.DropTable(
                name: "VehicleDetails");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "UserApplications");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "IncidentTypes");
        }
    }
}
