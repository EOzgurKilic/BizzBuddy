using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BizBuddy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentCustomerFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Customer_CustomerId",
                schema: "Orders",
                table: "Appointment");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Customer_CustomerId",
                schema: "Orders",
                table: "Appointment",
                column: "CustomerId",
                principalSchema: "Customers",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Customer_CustomerId",
                schema: "Orders",
                table: "Appointment");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Customer_CustomerId",
                schema: "Orders",
                table: "Appointment",
                column: "CustomerId",
                principalSchema: "Customers",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
