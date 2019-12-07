using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class ChangePeriodRelationshipWithSubjutctToCareerSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Periods_PeriodId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_PeriodId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "Subjects");

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "CareerSubjects",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_CareerSubjects_PeriodId",
                table: "CareerSubjects",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareerSubjects_Periods_PeriodId",
                table: "CareerSubjects",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareerSubjects_Periods_PeriodId",
                table: "CareerSubjects");

            migrationBuilder.DropIndex(
                name: "IX_CareerSubjects_PeriodId",
                table: "CareerSubjects");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "CareerSubjects");

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 14, 6, 16, 583, DateTimeKind.Local).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 14, 6, 16, 583, DateTimeKind.Local).AddTicks(6861));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 14, 6, 16, 583, DateTimeKind.Local).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 14, 6, 16, 583, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 14, 6, 16, 583, DateTimeKind.Local).AddTicks(7807));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 14, 6, 16, 583, DateTimeKind.Local).AddTicks(7810));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 7, 14, 6, 16, 581, DateTimeKind.Local).AddTicks(4366));

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_PeriodId",
                table: "Subjects",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Periods_PeriodId",
                table: "Subjects",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
