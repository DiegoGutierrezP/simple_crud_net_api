using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace simple_crud.Migrations
{
    public partial class add_column_estado_estudiante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "estudiante",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "estudiante");
        }
    }
}
