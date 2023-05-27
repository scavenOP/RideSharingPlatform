using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideSharingPlatform.Migrations
{
    public partial class added_ride_managent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookedOn = table.Column<int>(type: "int", nullable: false),
                    RiderUserId = table.Column<int>(type: "int", nullable: false),
                    NoOfSeats = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RideSchedulesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                });

            migrationBuilder.CreateTable(
                name: "Distances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanceInKMS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distances", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RideSchedules",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RideFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RideTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RideStartsOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RideTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RideFare = table.Column<int>(type: "int", nullable: false),
                    VehicleRegistrationNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotoristUserId = table.Column<int>(type: "int", nullable: false),
                    NoOfSeatsAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideSchedules", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Distances",
                columns: new[] { "ID", "DistanceInKMS", "From", "To" },
                values: new object[] { 1, 10, "Unitech", "Dunlop" });

            migrationBuilder.InsertData(
                table: "Distances",
                columns: new[] { "ID", "DistanceInKMS", "From", "To" },
                values: new object[] { 2, 5, "Unitech", "SlatLake" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Distances");

            migrationBuilder.DropTable(
                name: "RideSchedules");
        }
    }
}
