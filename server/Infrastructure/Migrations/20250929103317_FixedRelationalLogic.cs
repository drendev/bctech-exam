using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedRelationalLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeePersonalInfos",
                table: "EmployeePersonalInfos");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePersonalInfos_EmployeeId",
                table: "EmployeePersonalInfos");

            migrationBuilder.DropColumn(
                name: "PersonalInfoId",
                table: "EmployeePersonalInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeePersonalInfos",
                table: "EmployeePersonalInfos",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeePersonalInfos",
                table: "EmployeePersonalInfos");

            migrationBuilder.AddColumn<int>(
                name: "PersonalInfoId",
                table: "EmployeePersonalInfos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeePersonalInfos",
                table: "EmployeePersonalInfos",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePersonalInfos_EmployeeId",
                table: "EmployeePersonalInfos",
                column: "EmployeeId",
                unique: true);
        }
    }
}
