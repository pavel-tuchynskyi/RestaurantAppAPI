using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MenuItemsInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingridients",
                columns: table => new
                {
                    IngridientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageBlob = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingridients", x => x.IngridientId);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageBlob = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                });

            migrationBuilder.CreateTable(
                name: "PizzaIngridients",
                columns: table => new
                {
                    IngridientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PizzaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngridients", x => new { x.IngridientId, x.PizzaId });
                    table.ForeignKey(
                        name: "FK_PizzaIngridients_Ingridients_IngridientId",
                        column: x => x.IngridientId,
                        principalTable: "Ingridients",
                        principalColumn: "IngridientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaIngridients_MenuItems_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RollsIngridients",
                columns: table => new
                {
                    IngridientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RollsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollsIngridients", x => new { x.IngridientId, x.RollsId });
                    table.ForeignKey(
                        name: "FK_RollsIngridients_Ingridients_IngridientId",
                        column: x => x.IngridientId,
                        principalTable: "Ingridients",
                        principalColumn: "IngridientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RollsIngridients_MenuItems_RollsId",
                        column: x => x.RollsId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SetComponents",
                columns: table => new
                {
                    JapaneesFoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetComponents", x => new { x.JapaneesFoodId, x.SetId });
                    table.ForeignKey(
                        name: "FK_SetComponents_MenuItems_JapaneesFoodId",
                        column: x => x.JapaneesFoodId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId");
                    table.ForeignKey(
                        name: "FK_SetComponents_MenuItems_SetId",
                        column: x => x.SetId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SusiIngridients",
                columns: table => new
                {
                    IngridientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SusiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SusiIngridients", x => new { x.IngridientId, x.SusiId });
                    table.ForeignKey(
                        name: "FK_SusiIngridients_Ingridients_IngridientId",
                        column: x => x.IngridientId,
                        principalTable: "Ingridients",
                        principalColumn: "IngridientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SusiIngridients_MenuItems_SusiId",
                        column: x => x.SusiId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngridients_PizzaId",
                table: "PizzaIngridients",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_RollsIngridients_RollsId",
                table: "RollsIngridients",
                column: "RollsId");

            migrationBuilder.CreateIndex(
                name: "IX_SetComponents_SetId",
                table: "SetComponents",
                column: "SetId");

            migrationBuilder.CreateIndex(
                name: "IX_SusiIngridients_SusiId",
                table: "SusiIngridients",
                column: "SusiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaIngridients");

            migrationBuilder.DropTable(
                name: "RollsIngridients");

            migrationBuilder.DropTable(
                name: "SetComponents");

            migrationBuilder.DropTable(
                name: "SusiIngridients");

            migrationBuilder.DropTable(
                name: "Ingridients");

            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
