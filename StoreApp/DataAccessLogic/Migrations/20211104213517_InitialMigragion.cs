using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLogic.Migrations
{
    public partial class InitialMigragion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cust_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    cust_address = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: true),
                    cust_email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    cust_phone_number = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__customer__A1B71F90DD81F00C", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "store",
                columns: table => new
                {
                    store_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    store_address = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store", x => x.store_id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_total_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    store_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__orders__730E34DE09B91646", x => x.order_number);
                    table.ForeignKey(
                        name: "FK__orders__store_id__4B7734FF",
                        column: x => x.store_id,
                        principalTable: "store",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_customer_CustomerCustID",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    product_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    product_description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    product_quantity = table.Column<int>(type: "int", nullable: false),
                    store_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_product_store_store_id",
                        column: x => x.store_id,
                        principalTable: "store",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lineItem",
                columns: table => new
                {
                    lineItem_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lineItem_quantity = table.Column<int>(type: "int", nullable: false),
                    order_number = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("lineItem_id", x => x.lineItem_id);
                    table.ForeignKey(
                        name: "FK_lineItem_orders_OrderNumber1",
                        column: x => x.order_number,
                        principalTable: "orders",
                        principalColumn: "order_number",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_lineItem_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lineItem_OrderNumber1",
                table: "lineItem",
                column: "order_number");

            migrationBuilder.CreateIndex(
                name: "IX_lineItem_product_id",
                table: "lineItem",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerCustID",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_store_id",
                table: "orders",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_store_id",
                table: "product",
                column: "store_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lineItem");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "store");
        }
    }
}
