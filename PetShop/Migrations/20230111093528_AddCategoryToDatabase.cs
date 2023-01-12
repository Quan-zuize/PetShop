using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShop.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admin__3213E83FEC331976", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Banner_image",
                columns: table => new
                {
                    bannerid = table.Column<int>(name: "banner_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    subtitle = table.Column<string>(name: "sub_title", type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Banner_i__10373C34A0B391FB", x => x.bannerid);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    parentId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__3213E83FC4A7E192", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    categoryId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__3213E83FF18F604B", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    contactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    dateadded = table.Column<DateTime>(name: "date_added", type: "datetime", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__3213E83FF44DA073", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    orderId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__3213E83FB2B6A967", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "((0))"),
                    orderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    deliveryDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "((0))"),
                    total = table.Column<decimal>(type: "decimal(15,4)", nullable: true, defaultValueSql: "((0))"),
                    dateadded = table.Column<DateTime>(name: "date_added", type: "datetime", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order__3213E83F58C86865", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    productId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    total = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    quantity = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__3213E83F61A2A8E6", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    productType = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    originalPrice = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
                    specification = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__3213E83F66BADC07", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Banner_image");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "CustomerOrder");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
