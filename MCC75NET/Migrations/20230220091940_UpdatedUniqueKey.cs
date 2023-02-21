using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCC75NET.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUniqueKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_tb_m_employees_email_phone_number",
                table: "tb_m_employees");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "tb_m_employees",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<double>(
                name: "gpa",
                table: "tb_m_educations",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_email_phone_number",
                table: "tb_m_employees",
                columns: new[] { "email", "phone_number" },
                unique: true,
                filter: "[phone_number] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_m_employees_email_phone_number",
                table: "tb_m_employees");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "tb_m_employees",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "gpa",
                table: "tb_m_educations",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tb_m_employees_email_phone_number",
                table: "tb_m_employees",
                columns: new[] { "email", "phone_number" });
        }
    }
}
