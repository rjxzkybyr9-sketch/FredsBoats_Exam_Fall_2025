using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FredsBoats.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "boat_colour",
                columns: table => new
                {
                    colourid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boat_colour", x => x.colourid);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customerid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    surname = table.Column<string>(type: "TEXT", maxLength: 70, nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    telephone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    licence = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customerid);
                });

            migrationBuilder.CreateTable(
                name: "boat",
                columns: table => new
                {
                    boatid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    hour_rate = table.Column<float>(type: "REAL", nullable: false),
                    daily_rate = table.Column<float>(type: "REAL", nullable: false),
                    fkcategoryid = table.Column<int>(type: "INTEGER", nullable: false),
                    fkcolourid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boat", x => x.boatid);
                    table.ForeignKey(
                        name: "FK_boat_boat_colour_fkcolourid",
                        column: x => x.fkcolourid,
                        principalTable: "boat_colour",
                        principalColumn: "colourid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_boat_category_fkcategoryid",
                        column: x => x.fkcategoryid,
                        principalTable: "category",
                        principalColumn: "categoryid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    bookingid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    start_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    end_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    fkboatid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.bookingid);
                    table.ForeignKey(
                        name: "FK_reservation_boat_fkboatid",
                        column: x => x.fkboatid,
                        principalTable: "boat",
                        principalColumn: "boatid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cust_reservations",
                columns: table => new
                {
                    res_cust_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fkcustomerid = table.Column<int>(type: "INTEGER", nullable: false),
                    fkbookingid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cust_reservations", x => x.res_cust_id);
                    table.ForeignKey(
                        name: "FK_cust_reservations_customer_fkcustomerid",
                        column: x => x.fkcustomerid,
                        principalTable: "customer",
                        principalColumn: "customerid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cust_reservations_reservation_fkbookingid",
                        column: x => x.fkbookingid,
                        principalTable: "reservation",
                        principalColumn: "bookingid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_boat_fkcategoryid",
                table: "boat",
                column: "fkcategoryid");

            migrationBuilder.CreateIndex(
                name: "IX_boat_fkcolourid",
                table: "boat",
                column: "fkcolourid");

            migrationBuilder.CreateIndex(
                name: "IX_cust_reservations_fkbookingid",
                table: "cust_reservations",
                column: "fkbookingid");

            migrationBuilder.CreateIndex(
                name: "IX_cust_reservations_fkcustomerid",
                table: "cust_reservations",
                column: "fkcustomerid");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_fkboatid",
                table: "reservation",
                column: "fkboatid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cust_reservations");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "boat");

            migrationBuilder.DropTable(
                name: "boat_colour");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
