using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DairyFarm.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(Max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(Max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(Max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(Max)", maxLength: 6, nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUsersRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsersRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblUsersRole_Role",
                table: "tblUsersRole",
                column: "Role",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblUsers");

            migrationBuilder.DropTable(
                name: "tblUsersRole");
        }
    }
}
