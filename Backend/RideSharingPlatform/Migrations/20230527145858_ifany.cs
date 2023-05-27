using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideSharingPlatform.Migrations
{
    public partial class ifany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookedOn",
                table: "Bookings",
                newName: "RideScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RideScheduleID",
                table: "Bookings",
                column: "RideScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_RideSchedules_RideScheduleID",
                table: "Bookings",
                column: "RideScheduleID",
                principalTable: "RideSchedules",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_RideSchedules_RideScheduleID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RideScheduleID",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "RideScheduleID",
                table: "Bookings",
                newName: "BookedOn");
        }
    }
}
