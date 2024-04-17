using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Create3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ApplicationNumber",
                table: "Statement",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VisitTimeId",
                table: "Statement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VisitTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitTime", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statement_VisitTimeId",
                table: "Statement",
                column: "VisitTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statement_VisitTime_VisitTimeId",
                table: "Statement",
                column: "VisitTimeId",
                principalTable: "VisitTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statement_VisitTime_VisitTimeId",
                table: "Statement");

            migrationBuilder.DropTable(
                name: "VisitTime");

            migrationBuilder.DropIndex(
                name: "IX_Statement_VisitTimeId",
                table: "Statement");

            migrationBuilder.DropColumn(
                name: "VisitTimeId",
                table: "Statement");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationNumber",
                table: "Statement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
