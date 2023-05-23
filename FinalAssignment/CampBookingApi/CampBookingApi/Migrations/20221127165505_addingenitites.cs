using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampBookingApi.Migrations
{
    public partial class addingenitites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Bookingid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Zipcode = table.Column<int>(nullable: false),
                    Cellphone = table.Column<long>(nullable: false),
                    Bookingreferencenumber = table.Column<string>(nullable: true),
                    Totalprice = table.Column<long>(nullable: false),
                    Totalstay = table.Column<int>(nullable: false),
                    Campid = table.Column<int>(nullable: false),
                    Userid = table.Column<int>(nullable: false),
                    Bookingfrom = table.Column<DateTime>(nullable: false),
                    Bookingto = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Bookingid);
                });

            migrationBuilder.CreateTable(
                name: "Camps",
                columns: table => new
                {
                    CampId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campname = table.Column<string>(nullable: true),
                    Ratepernightforweekdays = table.Column<int>(nullable: false),
                    Ratepernightforweekend = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Availablefrom = table.Column<DateTime>(nullable: false),
                    Availableto = table.Column<DateTime>(nullable: false),
                    Imageurl = table.Column<string>(nullable: true),
                    Bookingid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camps", x => x.CampId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    MemberSince = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(nullable: false),
                    Campid = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: false),
                    CampsCampId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_Camps_CampsCampId",
                        column: x => x.CampsCampId,
                        principalTable: "Camps",
                        principalColumn: "CampId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CampsCampId",
                table: "Ratings",
                column: "CampsCampId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Camps");
        }
    }
}
