using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMvcApp.Migrations
{
    /// <inheritdoc />
    public partial class InitJohnDoe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a32e868-9191-4c77-a8ea-4c825571b5bf",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "19c2137e-4aec-40e3-a2bb-e86b4c711813", "a1ddbd22-3f92-4c54-8e1d-222a020b1319" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4b43c757-9e01-4243-bf9b-f4738b588bec", 0, "7b422a0d-8879-49c8-8796-f00326b45efa", "john.doe@example.com", false, false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN DOE", "AQAAAAIAAYagAAAAEI9bnzxidZZ+yhCWxSEb3S6FK1cSyK/2GPjRLnssQErapeLrjxRDdlzL22WyyowLRA==", null, false, "0d26478e-03ba-4c45-b109-f1f00264f7f4", false, "John Doe" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "eb6b2a41-9e08-4243-bf9b-74f5ac6d9297", "4b43c757-9e01-4243-bf9b-f4738b588bec" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eb6b2a41-9e08-4243-bf9b-74f5ac6d9297", "4b43c757-9e01-4243-bf9b-f4738b588bec" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b43c757-9e01-4243-bf9b-f4738b588bec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a32e868-9191-4c77-a8ea-4c825571b5bf",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dca3a927-1c7f-4adf-a1f5-8ef1e3686408", "8442b14c-1226-420b-b6c6-08f13e103d02" });
        }
    }
}
