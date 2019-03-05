using Microsoft.EntityFrameworkCore.Migrations;

namespace BasicSyncServer.Migrations
{
    public partial class BasicEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasicEntity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Ort = table.Column<string>(nullable: true),
                    Straße = table.Column<string>(nullable: true),
                    Hausnummer = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicEntity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicEntity");
        }
    }
}
