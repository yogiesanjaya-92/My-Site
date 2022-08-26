using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySite.Data.Migrations
{
    public partial class InitialDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ARTICLE",
                columns: table => new
                {
                    ARTICLE_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    ARTICLE_CATEGORY_ID = table.Column<Guid>(nullable: false),
                    ARTICLE_TITLE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ARTICLE_CONTENT = table.Column<string>(nullable: false),
                    ARTICLE_ATTACHMENT = table.Column<int>(nullable: false),
                    ARTICLE_COMMENT = table.Column<int>(nullable: false),
                    ARTICLE_RATE = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValueSql: "(0.0)"),
                    IS_DELETE = table.Column<bool>(nullable: true, defaultValueSql: "(0)"),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CREATED = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTICLE", x => x.ARTICLE_ID);
                });

            migrationBuilder.CreateTable(
                name: "ARTICLE_ATTACHMENT",
                columns: table => new
                {
                    ATTACHMENT_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    ARTICLE_ID = table.Column<Guid>(nullable: false),
                    ATTACHMENT_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ATTACHMENT_FILE = table.Column<string>(type: "text", nullable: false),
                    ATTACHMENT_SIZE = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    IS_DELETE = table.Column<bool>(nullable: true, defaultValueSql: "(0)"),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CREATED = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTICLE_ATTACHMENT", x => x.ATTACHMENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "ARTICLE_CATEGORY",
                columns: table => new
                {
                    CATEGORY_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    CATEGORY_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CATEGORY_COLOR = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    IS_DELETE = table.Column<bool>(nullable: true, defaultValueSql: "(0)"),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CREATED = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTICLE_CATEGORY", x => x.CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "ARTICLE_COMMENT",
                columns: table => new
                {
                    COMMENT_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    ARTICLE_ID = table.Column<Guid>(nullable: false),
                    COMMENT_CONTENT = table.Column<string>(maxLength: 255, nullable: false),
                    IS_DELETE = table.Column<bool>(nullable: true, defaultValueSql: "(0)"),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CREATED = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTICLE_COMMENT", x => x.COMMENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "ARTICLE_RATE",
                columns: table => new
                {
                    RATE_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    ARTICLE_ID = table.Column<Guid>(nullable: false),
                    RATE = table.Column<int>(nullable: false),
                    IS_DELETE = table.Column<bool>(nullable: true, defaultValueSql: "(0)"),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CREATED = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTICLE_RATE", x => x.RATE_ID);
                });

            migrationBuilder.CreateTable(
                name: "LOG",
                columns: table => new
                {
                    LOG_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    LOG_MODULE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    LOG_FUNCTION = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    LOG_EXCEPTION = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    LOG_MESSAGE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    LOG_STACK_TRACE = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    LOG_CREATED = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG", x => x.LOG_ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    USER_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    DISPLAY_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    PICTURE = table.Column<string>(type: "varchar(2083)", maxLength: 2083, nullable: false),
                    IS_DELETE = table.Column<bool>(nullable: true, defaultValueSql: "(0)"),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CREATED = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.USER_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ARTICLE");

            migrationBuilder.DropTable(
                name: "ARTICLE_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "ARTICLE_CATEGORY");

            migrationBuilder.DropTable(
                name: "ARTICLE_COMMENT");

            migrationBuilder.DropTable(
                name: "ARTICLE_RATE");

            migrationBuilder.DropTable(
                name: "LOG");

            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
