using Microsoft.EntityFrameworkCore.Migrations;

namespace MCS.Migrations
{
    public partial class EmployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BalanceSheet_Employees_EmployeeId",
                table: "BalanceSheet");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "BalanceSheet",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BalanceSheet_Employees_EmployeeId",
                table: "BalanceSheet",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BalanceSheet_Employees_EmployeeId",
                table: "BalanceSheet");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "BalanceSheet",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BalanceSheet_Employees_EmployeeId",
                table: "BalanceSheet",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
