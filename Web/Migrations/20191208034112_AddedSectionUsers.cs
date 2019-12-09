using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class AddedSectionUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesUsers");

            migrationBuilder.DropColumn(
                name: "CurrentRoom",
                table: "Sections");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SectionUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionUsers_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 23, 41, 11, 364, DateTimeKind.Local).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 23, 41, 11, 363, DateTimeKind.Local).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 23, 41, 11, 363, DateTimeKind.Local).AddTicks(9893));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 23, 41, 11, 364, DateTimeKind.Local).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 23, 41, 11, 364, DateTimeKind.Local).AddTicks(864));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 23, 41, 11, 364, DateTimeKind.Local).AddTicks(867));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 23, 41, 11, 358, DateTimeKind.Local).AddTicks(5646));

            migrationBuilder.CreateIndex(
                name: "IX_Sections_StatusId",
                table: "Sections",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionUsers_SectionId",
                table: "SectionUsers",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionUsers_UserId",
                table: "SectionUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Statuses_StatusId",
                table: "Sections",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Statuses_StatusId",
                table: "Sections");

            migrationBuilder.DropTable(
                name: "SectionUsers");

            migrationBuilder.DropIndex(
                name: "IX_Sections_StatusId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Sections");

            migrationBuilder.AddColumn<int>(
                name: "CurrentRoom",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CoursesUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesUsers_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesUsers_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 14, 43, 20, 37, DateTimeKind.Local).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 14, 43, 20, 36, DateTimeKind.Local).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 14, 43, 20, 36, DateTimeKind.Local).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 14, 43, 20, 36, DateTimeKind.Local).AddTicks(9523));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 14, 43, 20, 36, DateTimeKind.Local).AddTicks(9579));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 14, 43, 20, 36, DateTimeKind.Local).AddTicks(9585));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 14, 43, 20, 33, DateTimeKind.Local).AddTicks(1792));

            migrationBuilder.CreateIndex(
                name: "IX_CoursesUsers_StatusId",
                table: "CoursesUsers",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesUsers_SubjectId",
                table: "CoursesUsers",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesUsers_UserId",
                table: "CoursesUsers",
                column: "UserId");
        }
    }
}
