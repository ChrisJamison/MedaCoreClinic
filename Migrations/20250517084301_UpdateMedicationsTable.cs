using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyBenhVien.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMedicationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Medications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerialNumber",
                table: "Medications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
