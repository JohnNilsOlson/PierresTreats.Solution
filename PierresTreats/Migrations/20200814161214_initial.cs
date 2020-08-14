using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PierresTreats.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flavors",
                columns: table => new
                {
                    FlavorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FlavorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flavors", x => x.FlavorId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treats",
                columns: table => new
                {
                    TreatId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TreatName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treats", x => x.TreatId);
                });

            migrationBuilder.CreateTable(
                name: "TreatFlavors",
                columns: table => new
                {
                    TreatFlavorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TreatId = table.Column<int>(nullable: false),
                    FlavorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatFlavors", x => x.TreatFlavorId);
                    table.ForeignKey(
                        name: "FK_TreatFlavors_Flavors_FlavorId",
                        column: x => x.FlavorId,
                        principalTable: "Flavors",
                        principalColumn: "FlavorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatFlavors_Treats_TreatId",
                        column: x => x.TreatId,
                        principalTable: "Treats",
                        principalColumn: "TreatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreatFlavors_FlavorId",
                table: "TreatFlavors",
                column: "FlavorId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatFlavors_TreatId",
                table: "TreatFlavors",
                column: "TreatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUsers");

            migrationBuilder.DropTable(
                name: "TreatFlavors");

            migrationBuilder.DropTable(
                name: "Flavors");

            migrationBuilder.DropTable(
                name: "Treats");
        }
    }
}
