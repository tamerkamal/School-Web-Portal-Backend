using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolPortalAPI.Migrations
{
    public partial class FixedMemberColumnFirstNameSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirsName",
                table: "Members",
                newName: "FirstName");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2147483645",
                column: "ConcurrencyStamp",
                value: "57afa154-d804-4d2d-b101-41875358abd1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3147483643",
                column: "ConcurrencyStamp",
                value: "a323b857-4dcc-4c9c-8088-07a88ee9f98f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4147483644",
                column: "ConcurrencyStamp",
                value: "ad0101ab-c7f4-496f-ac04-8a0343e805d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5147483645",
                column: "ConcurrencyStamp",
                value: "8c4c6fff-8404-40aa-b239-b53e027ab27d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6147483646",
                column: "ConcurrencyStamp",
                value: "433c1cc7-b7e2-48ca-8f09-11157fb23c90");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2147483646",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a7966ed6-d785-4fcf-a350-5b3e4410af38", "AQAAAAEAACcQAAAAEPJoXqoP5WSQK52ZL5rZwa4h8wE1hh9pge8ywvdz+V9WpBRa3V8n45qK/ZIo6Gmtqw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Members",
                newName: "FirsName");

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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4147483644",
                column: "ConcurrencyStamp",
                value: "5b1978e1-32f1-4574-acef-73bc55a348da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5147483645",
                column: "ConcurrencyStamp",
                value: "c7271121-bc4c-4fad-bc4a-a8823a622974");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6147483646",
                column: "ConcurrencyStamp",
                value: "04cd50a0-30b9-4988-8d7e-0b34efcc31d1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2147483646",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a82ae38a-dd95-48a5-9388-bb9e16b6d39f", "AQAAAAEAACcQAAAAELQ1TAWawNOj4OLQkAYqFnAFhpDFmqnMiDfUj210aZrwBsXjFQ+2e80fxeRYhbbk5w==" });
        }
    }
}
