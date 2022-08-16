using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clubv1._3.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeceaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActorId = table.Column<int>(type: "int", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    SerieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCds = table.Column<int>(type: "int", nullable: false),
                    AvailableCds = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    RentingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfRent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentedMovieId = table.Column<int>(type: "int", nullable: false),
                    RentedSerieId = table.Column<int>(type: "int", nullable: false),
                    RentingId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Movies_RentedMovieId",
                        column: x => x.RentedMovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Rents_RentingId",
                        column: x => x.RentingId,
                        principalTable: "Rents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Seasons = table.Column<int>(type: "int", nullable: false),
                    Episodes = table.Column<int>(type: "int", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableCds = table.Column<int>(type: "int", nullable: false),
                    TotalCds = table.Column<int>(type: "int", nullable: false),
                    RentingId = table.Column<int>(type: "int", nullable: true),
                    SerieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Rents_RentingId",
                        column: x => x.RentingId,
                        principalTable: "Rents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Series_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actors_ActorId",
                table: "Actors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_MovieId",
                table: "Actors",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_SerieId",
                table: "Actors",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieId",
                table: "Movies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_RentingId",
                table: "Movies",
                column: "RentingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_RentedMovieId",
                table: "Rents",
                column: "RentedMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_RentedSerieId",
                table: "Rents",
                column: "RentedSerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_RentingId",
                table: "Rents",
                column: "RentingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_UserId",
                table: "Rents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_RentingId",
                table: "Series",
                column: "RentingId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_SerieId",
                table: "Series",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_MovieId",
                table: "Actors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Series_SerieId",
                table: "Actors",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Rents_RentingId",
                table: "Movies",
                column: "RentingId",
                principalTable: "Rents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Series_RentedSerieId",
                table: "Rents",
                column: "RentedSerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Movies_RentedMovieId",
                table: "Rents");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Series_RentedSerieId",
                table: "Rents");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
