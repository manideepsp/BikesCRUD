using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikesCRUD.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bike",
                columns: table => new
                {
                    BikeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BikeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BikeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BikeColour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BikeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bike", x => x.BikeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bike");
        }
    }
}
