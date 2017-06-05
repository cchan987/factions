using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTracker.Migrations
{
    public partial class addedwhosenextwhosebefore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WhoseBefore",
                table: "UserParticipation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhoseNext",
                table: "UserParticipation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhoseBefore",
                table: "UserParticipation");

            migrationBuilder.DropColumn(
                name: "WhoseNext",
                table: "UserParticipation");
        }
    }
}
