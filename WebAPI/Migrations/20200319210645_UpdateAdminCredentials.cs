using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolPortalAPI.Migrations
{
    public partial class UpdateAdminCredentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2147483645",
                column: "ConcurrencyStamp",
                value: "2d4b9577-ea2e-4786-8c68-c972a8a4cda3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3147483643",
                column: "ConcurrencyStamp",
                value: "df44e39b-7ed8-47df-b95e-ff1dd885e6cc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2147483646",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "b0e05317-7ec0-460a-9d95-972c9886b8ed", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAELLVltc00TFE2vmMCevlXkohKlCpP12z8K+ULq1JsUnNYgnmqNs6JiZy8f97fhFlKA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2147483645",
                column: "ConcurrencyStamp",
                value: "2067ce1d-70d4-4c18-a37e-6870909bbbc2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3147483643",
                column: "ConcurrencyStamp",
                value: "39f828da-4d25-44f3-81f0-6cf7a839b859");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2147483646",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "8b268e59-adec-437f-8a53-a398412a40f8", null, null, "1234" });
        }
    }
}
