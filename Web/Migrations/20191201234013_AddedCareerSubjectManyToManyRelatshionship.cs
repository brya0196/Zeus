using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class AddedCareerSubjectManyToManyRelatshionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Careers_CareerId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_CareerId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CareerId",
                table: "Subjects");

            migrationBuilder.CreateTable(
                name: "CareerSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    CareerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CareerSubjects_Careers_CareerId",
                        column: x => x.CareerId,
                        principalTable: "Careers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareerSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 1, 19, 40, 12, 269, DateTimeKind.Local).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 1, 19, 40, 12, 268, DateTimeKind.Local).AddTicks(8522));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 1, 19, 40, 12, 268, DateTimeKind.Local).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 1, 19, 40, 12, 269, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 1, 19, 40, 12, 269, DateTimeKind.Local).AddTicks(640));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 1, 19, 40, 12, 269, DateTimeKind.Local).AddTicks(643));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 1, 19, 40, 12, 262, DateTimeKind.Local).AddTicks(1084));

            migrationBuilder.CreateIndex(
                name: "IX_CareerSubjects_CareerId",
                table: "CareerSubjects",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_CareerSubjects_SubjectId",
                table: "CareerSubjects",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareerSubjects");

            migrationBuilder.AddColumn<int>(
                name: "CareerId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 1, 16, 5, 53, 822, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 1, 16, 5, 53, 822, DateTimeKind.Local).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 1, 16, 5, 53, 822, DateTimeKind.Local).AddTicks(2953));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 1, 16, 5, 53, 822, DateTimeKind.Local).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 1, 16, 5, 53, 822, DateTimeKind.Local).AddTicks(3783));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 1, 16, 5, 53, 822, DateTimeKind.Local).AddTicks(3785));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 1, 16, 5, 53, 820, DateTimeKind.Local).AddTicks(665));

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CareerId",
                table: "Subjects",
                column: "CareerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Careers_CareerId",
                table: "Subjects",
                column: "CareerId",
                principalTable: "Careers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
