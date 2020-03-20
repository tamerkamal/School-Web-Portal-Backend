using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolPortalAPI.Migrations
{
    public partial class SeedingMembersRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2147483645",
                column: "ConcurrencyStamp",
                value: "3ed38d18-573f-4cd9-950d-dccde8bf92ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3147483643",
                column: "ConcurrencyStamp",
                value: "fec79b21-c948-4524-b3b9-bd62e1e7f6b4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4147483644", "5b1978e1-32f1-4574-acef-73bc55a348da", "AppRole", "Student", "STUDENT" },
                    { "5147483645", "c7271121-bc4c-4fad-bc4a-a8823a622974", "AppRole", "Parent", "PARENT" },
                    { "6147483646", "04cd50a0-30b9-4988-8d7e-0b34efcc31d1", "AppRole", "Teacher", "TEACHER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2147483646",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a82ae38a-dd95-48a5-9388-bb9e16b6d39f", "AQAAAAEAACcQAAAAELQ1TAWawNOj4OLQkAYqFnAFhpDFmqnMiDfUj210aZrwBsXjFQ+2e80fxeRYhbbk5w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4147483644");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5147483645");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6147483646");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b0e05317-7ec0-460a-9d95-972c9886b8ed", "AQAAAAEAACcQAAAAELLVltc00TFE2vmMCevlXkohKlCpP12z8K+ULq1JsUnNYgnmqNs6JiZy8f97fhFlKA==" });
        }
    }
}
