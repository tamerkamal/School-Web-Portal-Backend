using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolPortalAPI.Migrations
{
    public partial class SeedRemainingRolesAndMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2147483645",
                column: "ConcurrencyStamp",
                value: "2067ce1d-70d4-4c18-a37e-6870909bbbc2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "3147483643", "39f828da-4d25-44f3-81f0-6cf7a839b859", "AppRole", "Member", "MEMBER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2147483646",
                column: "ConcurrencyStamp",
                value: "8b268e59-adec-437f-8a53-a398412a40f8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3147483643");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2147483645",
                column: "ConcurrencyStamp",
                value: "7ef97c35-8090-4049-aca1-53b0686fcbf6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2147483646",
                column: "ConcurrencyStamp",
                value: "049dc5d6-ab11-45d6-914c-e0a336a966dd");
        }
    }
}
