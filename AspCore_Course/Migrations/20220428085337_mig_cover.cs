﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCore_Course.Migrations
{
    public partial class mig_cover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Posts");
        }
    }
}
