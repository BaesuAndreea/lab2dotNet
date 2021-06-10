using Microsoft.EntityFrameworkCore.Migrations;

namespace lab2.Data.Migrations
{
    public partial class AddExpenseIdToUserExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersExpenses_Expense_ExpenseId",
                table: "UsersExpenses");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseId",
                table: "UsersExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersExpenses_Expense_ExpenseId",
                table: "UsersExpenses",
                column: "ExpenseId",
                principalTable: "Expense",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersExpenses_Expense_ExpenseId",
                table: "UsersExpenses");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseId",
                table: "UsersExpenses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersExpenses_Expense_ExpenseId",
                table: "UsersExpenses",
                column: "ExpenseId",
                principalTable: "Expense",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
