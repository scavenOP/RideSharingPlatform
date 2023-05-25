using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideSharingPlatform.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceCertificateDOCURL",
                table: "VehicleDetails");

            migrationBuilder.DropColumn(
                name: "PUCDOCURL",
                table: "VehicleDetails");

            migrationBuilder.DropColumn(
                name: "RCDocURL",
                table: "VehicleDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InsuranceCertificateDOCURL",
                table: "VehicleDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PUCDOCURL",
                table: "VehicleDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RCDocURL",
                table: "VehicleDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
