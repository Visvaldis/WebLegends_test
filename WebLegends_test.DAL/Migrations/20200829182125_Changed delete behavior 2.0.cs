using Microsoft.EntityFrameworkCore.Migrations;

namespace WebLegends_test.DAL.Migrations
{
    public partial class Changeddeletebehavior20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Statuses_StatusId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Facilities_FacilityId",
                table: "FacilityLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Facilities_FacilityId1",
                table: "FacilityLogs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_FacilityId1",
                table: "FacilityLogs");

            migrationBuilder.DropColumn(
                name: "FacilityId1",
                table: "FacilityLogs");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityId",
                table: "FacilityLogs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Facilities",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Statuses_StatusId",
                table: "Facilities",
                column: "StatusId",
                principalTable: "FacilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Facilities_FacilityId",
                table: "FacilityLogs",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Statuses_StatusId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Facilities_FacilityId",
                table: "FacilityLogs");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityId",
                table: "FacilityLogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "FacilityId1",
                table: "FacilityLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Facilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Logs_FacilityId1",
                table: "FacilityLogs",
                column: "FacilityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Statuses_StatusId",
                table: "Facilities",
                column: "StatusId",
                principalTable: "FacilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Facilities_FacilityId",
                table: "FacilityLogs",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Facilities_FacilityId1",
                table: "FacilityLogs",
                column: "FacilityId1",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
