using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolPortalAPI.Migrations
{
    public partial class RemovedUnusedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "TeacherStages");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(nullable: false),
                    FirsName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    MembershipTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_MembershipTypes_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipTypes",
                        principalColumn: "MembershipTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MembershipTypes",
                columns: new[] { "MembershipTypeId", "Name" },
                values: new object[] { new Guid("3b8db47a-57d6-4a49-92d3-02599fd003ef"), "Student" });

            migrationBuilder.InsertData(
                table: "MembershipTypes",
                columns: new[] { "MembershipTypeId", "Name" },
                values: new object[] { new Guid("cff38bc0-1948-481e-89a5-597cad9530a7"), "Parent" });

            migrationBuilder.InsertData(
                table: "MembershipTypes",
                columns: new[] { "MembershipTypeId", "Name" },
                values: new object[] { new Guid("0041727c-9884-4a46-9690-ec1c522d3dbe"), "Teacher" });

            migrationBuilder.CreateIndex(
                name: "IX_Members_MembershipTypeId",
                table: "Members",
                column: "MembershipTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DeleteData(
                table: "MembershipTypes",
                keyColumn: "MembershipTypeId",
                keyValue: new Guid("0041727c-9884-4a46-9690-ec1c522d3dbe"));

            migrationBuilder.DeleteData(
                table: "MembershipTypes",
                keyColumn: "MembershipTypeId",
                keyValue: new Guid("3b8db47a-57d6-4a49-92d3-02599fd003ef"));

            migrationBuilder.DeleteData(
                table: "MembershipTypes",
                keyColumn: "MembershipTypeId",
                keyValue: new Guid("cff38bc0-1948-481e-89a5-597cad9530a7"));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    EduQualification = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    FirsName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    MembershipTypeId = table.Column<Guid>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Profession = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Parents_MembershipTypes_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipTypes",
                        principalColumn: "MembershipTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    StageId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.StageId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FirsName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    MembershipTypeId = table.Column<Guid>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    TeachingExperience = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Teachers_MembershipTypes_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipTypes",
                        principalColumn: "MembershipTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FirsName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    MembershipTypeId = table.Column<Guid>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    StageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Students_MembershipTypes_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipTypes",
                        principalColumn: "MembershipTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    TeacherCourseId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false),
                    MemberId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => x.TeacherCourseId);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Teachers",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherStages",
                columns: table => new
                {
                    TeacherStageId = table.Column<Guid>(nullable: false),
                    MemberId = table.Column<Guid>(nullable: false),
                    StageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherStages", x => x.TeacherStageId);
                    table.ForeignKey(
                        name: "FK_TeacherStages_Teachers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Teachers",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherStages_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parents_MembershipTypeId",
                table: "Parents",
                column: "MembershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_MembershipTypeId",
                table: "Students",
                column: "MembershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StageId",
                table: "Students",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_CourseId",
                table: "TeacherCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_MemberId",
                table: "TeacherCourses",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_MembershipTypeId",
                table: "Teachers",
                column: "MembershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStages_MemberId",
                table: "TeacherStages",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStages_StageId",
                table: "TeacherStages",
                column: "StageId");
        }
    }
}
