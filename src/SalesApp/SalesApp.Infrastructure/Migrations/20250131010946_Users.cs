using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SalesApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    username = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    address_city = table.Column<string>(type: "text", nullable: false),
                    address_number = table.Column<int>(type: "integer", nullable: false),
                    address_street = table.Column<string>(type: "text", nullable: false),
                    address_zipcode = table.Column<string>(type: "text", nullable: false),
                    address_geolocation_lat = table.Column<string>(type: "text", nullable: false),
                    address_geolocation_long = table.Column<string>(type: "text", nullable: false),
                    name_firstname = table.Column<string>(type: "text", nullable: false),
                    name_lastname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
