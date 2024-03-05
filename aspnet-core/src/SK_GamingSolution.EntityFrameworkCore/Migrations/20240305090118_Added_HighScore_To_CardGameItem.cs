using Microsoft.EntityFrameworkCore.Migrations;
using SK_GamingSolution.Entities;
using System;

#nullable disable

namespace SK_GamingSolution.Migrations
{
    /// <inheritdoc />
    public partial class Added_HighScore_To_CardGameItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
            name: "HighScore",
            table: "CardGameItems",
            nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighScore",
                table: "CardGameItems");
        }
    }
}
