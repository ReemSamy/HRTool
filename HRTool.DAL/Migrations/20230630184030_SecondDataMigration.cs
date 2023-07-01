using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRTool.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SecondDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Employees",
                newName: "SickBalance");

            migrationBuilder.AddColumn<int>(
                name: "AnnualBalance",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "AnnualBalance",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "AnnualBalance",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "AnnualBalance",
                value: 21);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualBalance",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "SickBalance",
                table: "Employees",
                newName: "Balance");
        }
    }
}
