﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiServer.Migrations
{
    public partial class changethejointablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostsToTagsJoin");

            migrationBuilder.CreateTable(
                name: "TestPostsToTagsJoin",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPostsToTagsJoin", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_TestPostsToTagsJoin_TestPosts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "TestPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestPostsToTagsJoin_TestTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "TestTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestPostsToTagsJoin_TagsId",
                table: "TestPostsToTagsJoin",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestPostsToTagsJoin");

            migrationBuilder.CreateTable(
                name: "PostsToTagsJoin",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsToTagsJoin", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PostsToTagsJoin_TestPosts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "TestPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostsToTagsJoin_TestTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "TestTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostsToTagsJoin_TagsId",
                table: "PostsToTagsJoin",
                column: "TagsId");
        }
    }
}
