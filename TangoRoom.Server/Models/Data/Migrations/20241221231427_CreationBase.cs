using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TangoRoom.Server.Models.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreationBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marathons",
                columns: table => new
                {
                    IdMarathon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinInscription = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatutMarathon = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marathons", x => x.IdMarathon);
                    table.CheckConstraint("CK_MarathonEndRegister", "( DateFinInscription<=DATEADD(m,-15,DateDebut))");
                    table.CheckConstraint("CK_MarathonStatus", "StatutMarathon IN ('disponible', 'clos')");
                    table.CheckConstraint("CK_MarathonValidity", "(DateDebut <= GETDATE())");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    StatutPersonnel = table.Column<int>(type: "int", nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ValideInscription = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    TextInvitation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.IdUtilisateur);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole");
                });

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    IdLeader = table.Column<int>(type: "int", nullable: false),
                    IdFollower = table.Column<int>(type: "int", nullable: false),
                    IdMarathon = table.Column<int>(type: "int", nullable: false),
                    DateMatchUp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => new { x.IdLeader, x.IdFollower, x.IdMarathon });
                    table.ForeignKey(
                        name: "FK_Inscriptions_Marathons_IdMarathon",
                        column: x => x.IdMarathon,
                        principalTable: "Marathons",
                        principalColumn: "IdMarathon");
                    table.ForeignKey(
                        name: "FK_Inscriptions_Utilisateurs_IdFollower",
                        column: x => x.IdFollower,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur");
                    table.ForeignKey(
                        name: "FK_Inscriptions_Utilisateurs_IdLeader",
                        column: x => x.IdLeader,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur");
                });

            migrationBuilder.CreateTable(
                name: "PlanningAnnuel",
                columns: table => new
                {
                    IdMarathon = table.Column<int>(type: "int", nullable: false),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningAnnuel", x => new { x.IdMarathon, x.IdUtilisateur });
                    table.ForeignKey(
                        name: "FK_PlanningAnnuel_Marathons_IdMarathon",
                        column: x => x.IdMarathon,
                        principalTable: "Marathons",
                        principalColumn: "IdMarathon");
                    table.ForeignKey(
                        name: "FK_PlanningAnnuel_Utilisateurs_IdUtilisateur",
                        column: x => x.IdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "IdUtilisateur");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_IdFollower",
                table: "Inscriptions",
                column: "IdFollower");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_IdMarathon",
                table: "Inscriptions",
                column: "IdMarathon");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningAnnuel_IdUtilisateur",
                table: "PlanningAnnuel",
                column: "IdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_IdRole",
                table: "Utilisateurs",
                column: "IdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "PlanningAnnuel");

            migrationBuilder.DropTable(
                name: "Marathons");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
