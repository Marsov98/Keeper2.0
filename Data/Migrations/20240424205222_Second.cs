using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statement_VisitTime_VisitTimeId",
                table: "Statement");

            migrationBuilder.AlterColumn<int>(
                name: "VisitTimeId",
                table: "Statement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Statement_VisitTime_VisitTimeId",
                table: "Statement",
                column: "VisitTimeId",
                principalTable: "VisitTime",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statement_VisitTime_VisitTimeId",
                table: "Statement");

            migrationBuilder.AlterColumn<int>(
                name: "VisitTimeId",
                table: "Statement",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Statement_VisitTime_VisitTimeId",
                table: "Statement",
                column: "VisitTimeId",
                principalTable: "VisitTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
