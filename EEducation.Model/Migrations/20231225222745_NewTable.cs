using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EEducation.Model.Migrations
{
    /// <inheritdoc />
    public partial class NewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStock",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProductShortDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryIcon",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryImage",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropColumn(
                name: "IsStock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductShortDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryIcon",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryImage",
                table: "Categories");
        }
    }
}
