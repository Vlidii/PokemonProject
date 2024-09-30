using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddPokemonTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PokemonNumber = table.Column<int>(type: "int", nullable: false),
                    PokemonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PokemonInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PokemonType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PokemonType2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseHP = table.Column<int>(type: "int", nullable: false),
                    BaseAttack = table.Column<int>(type: "int", nullable: false),
                    BaseDefense = table.Column<int>(type: "int", nullable: false),
                    BaseSPAttack = table.Column<int>(type: "int", nullable: false),
                    BaseSPDefense = table.Column<int>(type: "int", nullable: false),
                    BaseSpeed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnedPokemon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shiny = table.Column<bool>(type: "bit", nullable: false),
                    CaptureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    IVHP = table.Column<int>(type: "int", nullable: false),
                    EVHP = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    IVAttack = table.Column<int>(type: "int", nullable: false),
                    EVAttack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    IVDefense = table.Column<int>(type: "int", nullable: false),
                    EVDefense = table.Column<int>(type: "int", nullable: false),
                    SPAttack = table.Column<int>(type: "int", nullable: false),
                    IVSPAttack = table.Column<int>(type: "int", nullable: false),
                    EVSPAttack = table.Column<int>(type: "int", nullable: false),
                    SPDefence = table.Column<int>(type: "int", nullable: false),
                    IVSPDefence = table.Column<int>(type: "int", nullable: false),
                    EVSPDefence = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    IVSpeed = table.Column<int>(type: "int", nullable: false),
                    EVSpeed = table.Column<int>(type: "int", nullable: false),
                    PokemonId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedPokemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnedPokemon_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnedPokemon_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavoriteTeam = table.Column<bool>(type: "bit", nullable: false),
                    OwnedPokemonId1 = table.Column<int>(type: "int", nullable: false),
                    OwnedPokemonId2 = table.Column<int>(type: "int", nullable: false),
                    OwnedPokemonId3 = table.Column<int>(type: "int", nullable: false),
                    OwnedPokemonId4 = table.Column<int>(type: "int", nullable: false),
                    OwnedPokemonId5 = table.Column<int>(type: "int", nullable: false),
                    OwnedPokemonId6 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonTeam_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                   
                    table.ForeignKey(
                        name: "FK_PokemonTeam_OwnedPokemon_OwnedPokemonId1",
                        column: x => x.OwnedPokemonId1,
                        principalTable: "OwnedPokemon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonTeam_OwnedPokemon_OwnedPokemonId2",
                        column: x => x.OwnedPokemonId2,
                        principalTable: "OwnedPokemon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonTeam_OwnedPokemon_OwnedPokemonId3",
                        column: x => x.OwnedPokemonId3,
                        principalTable: "OwnedPokemon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonTeam_OwnedPokemon_OwnedPokemonId4",
                        column: x => x.OwnedPokemonId4,
                        principalTable: "OwnedPokemon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonTeam_OwnedPokemon_OwnedPokemonId5",
                        column: x => x.OwnedPokemonId5,
                        principalTable: "OwnedPokemon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonTeam_OwnedPokemon_OwnedPokemonId6",
                        column: x => x.OwnedPokemonId6,
                        principalTable: "OwnedPokemon",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "70b5fa50-87fe-4ffd-8cea-53df36885298", null, "User", "USER" },
                    { "dd18e515-23d3-455b-b878-d3dcec451e6a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedPokemon_AppUserId",
                table: "OwnedPokemon",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedPokemon_PokemonId",
                table: "OwnedPokemon",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeam_AppUserId",
                table: "PokemonTeam",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeam_OwnedPokemonId1",
                table: "PokemonTeam",
                column: "OwnedPokemonId1");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeam_OwnedPokemonId2",
                table: "PokemonTeam",
                column: "OwnedPokemonId2");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeam_OwnedPokemonId3",
                table: "PokemonTeam",
                column: "OwnedPokemonId3");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeam_OwnedPokemonId4",
                table: "PokemonTeam",
                column: "OwnedPokemonId4");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeam_OwnedPokemonId5",
                table: "PokemonTeam",
                column: "OwnedPokemonId5");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeam_OwnedPokemonId6",
                table: "PokemonTeam",
                column: "OwnedPokemonId6");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PokemonTeam");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OwnedPokemon");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Pokemon");
        }
    }
}
