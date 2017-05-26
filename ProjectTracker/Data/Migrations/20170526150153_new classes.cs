using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectTracker.Data.Migrations
{
    public partial class newclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountActiveParticipants = table.Column<int>(nullable: false),
                    CountParticipants = table.Column<int>(nullable: false),
                    WhoseTurn = table.Column<int>(nullable: false),
                    isAcceptingParticipants = table.Column<bool>(nullable: false),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectChange",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Change = table.Column<string>(maxLength: 100, nullable: true),
                    ChangeBy = table.Column<int>(nullable: false),
                    ChangeConcerns = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectChange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserParticipation",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserParticipation", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserStats",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataA = table.Column<int>(nullable: false),
                    DataB = table.Column<int>(nullable: false),
                    DataC = table.Column<int>(nullable: false),
                    DataD = table.Column<int>(nullable: false),
                    DataE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStats", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectChange");

            migrationBuilder.DropTable(
                name: "UserParticipation");

            migrationBuilder.DropTable(
                name: "UserStats");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
