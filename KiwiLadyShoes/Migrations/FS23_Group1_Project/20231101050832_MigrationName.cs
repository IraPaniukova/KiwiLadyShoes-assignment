using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KiwiLadyShoes.Migrations.FS23_Group1_Project
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Shoe__Descriptio__6C190EBB",
                table: "Shoe");

            migrationBuilder.DropTable(
                name: "ShoeDescription");

            migrationBuilder.RenameColumn(
                name: "DescriptionId",
                table: "Shoe",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Shoe_DescriptionId",
                table: "Shoe",
                newName: "IX_Shoe_TypeId");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Shoe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Shoe",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Shoe",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Shoe",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Shoe",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ShoeName",
                table: "Shoe",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_BrandId",
                table: "Shoe",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK__ShoeDescr__Brand__619B8048",
                table: "Shoe",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK__ShoeDescr__TypeI__60A75C0F",
                table: "Shoe",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ShoeDescr__Brand__619B8048",
                table: "Shoe");

            migrationBuilder.DropForeignKey(
                name: "FK__ShoeDescr__TypeI__60A75C0F",
                table: "Shoe");

            migrationBuilder.DropIndex(
                name: "IX_Shoe_BrandId",
                table: "Shoe");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Shoe");

            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Shoe");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Shoe");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Shoe");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Shoe");

            migrationBuilder.DropColumn(
                name: "ShoeName",
                table: "Shoe");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Shoe",
                newName: "DescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Shoe_TypeId",
                table: "Shoe",
                newName: "IX_Shoe_DescriptionId");

            migrationBuilder.CreateTable(
                name: "ShoeDescription",
                columns: table => new
                {
                    ShoeDescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Colour = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Image = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Material = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeDescription", x => x.ShoeDescriptionId);
                    table.ForeignKey(
                        name: "FK__ShoeDescr__Brand__619B8048",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandID");
                    table.ForeignKey(
                        name: "FK__ShoeDescr__TypeI__60A75C0F",
                        column: x => x.TypeId,
                        principalTable: "Type",
                        principalColumn: "TypeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoeDescription_BrandId",
                table: "ShoeDescription",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeDescription_TypeId",
                table: "ShoeDescription",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK__Shoe__Descriptio__6C190EBB",
                table: "Shoe",
                column: "DescriptionId",
                principalTable: "ShoeDescription",
                principalColumn: "ShoeDescriptionId");
        }
    }
}
