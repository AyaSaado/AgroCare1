using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroCare1.Migrations
{
    /// <inheritdoc />
    public partial class intiail_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agricultural_Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agricultural_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engineer_Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineer_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Farmer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Land_Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Land_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Soil_Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soil_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store_Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engineer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Engineer_Type_Id = table.Column<int>(type: "int", nullable: false),
                    Head_Engineer_Id = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engineer_Engineer",
                        column: x => x.Head_Engineer_Id,
                        principalTable: "Engineer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Engineer_Engineer_Type",
                        column: x => x.Engineer_Type_Id,
                        principalTable: "Engineer_Type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Land",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Farmer_Id = table.Column<int>(type: "int", nullable: false),
                    Type_Id = table.Column<int>(type: "int", nullable: false),
                    Soil_Type_Id = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Has_Well = table.Column<bool>(type: "bit", nullable: false),
                    Area = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Land", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Land_Farmer",
                        column: x => x.Farmer_Id,
                        principalTable: "Farmer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Land_Land_Type",
                        column: x => x.Type_Id,
                        principalTable: "Land_Type",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Land_Soil_Type",
                        column: x => x.Soil_Type_Id,
                        principalTable: "Soil_Type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_Store_Type",
                        column: x => x.Type_Id,
                        principalTable: "Store_Type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buyer_Id = table.Column<int>(type: "int", nullable: false),
                    Admin_Engineer_Id = table.Column<int>(type: "int", nullable: false),
                    Executive_Team_Id = table.Column<int>(type: "int", nullable: false),
                    Order_Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Buyer",
                        column: x => x.Buyer_Id,
                        principalTable: "Buyer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Engineer",
                        column: x => x.Admin_Engineer_Id,
                        principalTable: "Engineer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Engineer1",
                        column: x => x.Executive_Team_Id,
                        principalTable: "Engineer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Kilos = table.Column<int>(type: "int", nullable: false),
                    Kilo_Price = table.Column<float>(type: "real", nullable: false),
                    Delivery_Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Details_Item",
                        column: x => x.Item_Id,
                        principalTable: "Item",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Details_Order",
                        column: x => x.Order_Id,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Details_Id = table.Column<int>(type: "int", nullable: false),
                    Land_Id = table.Column<int>(type: "int", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Finish_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Distribution_Land",
                        column: x => x.Land_Id,
                        principalTable: "Land",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Distribution_Order_Details",
                        column: x => x.Order_Details_Id,
                        principalTable: "Order_Details",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Store_Id = table.Column<int>(type: "int", nullable: false),
                    Plan_Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Order_Distribution",
                        column: x => x.Plan_Id,
                        principalTable: "Plan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Purchase_Store",
                        column: x => x.Store_Id,
                        principalTable: "Store",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plan_Id = table.Column<int>(type: "int", nullable: false),
                    Action_Id = table.Column<int>(type: "int", nullable: false),
                    Estimated_Start_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Estimated_Finish_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Is_Checked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Step_Action",
                        column: x => x.Action_Id,
                        principalTable: "Action",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Step_Plan",
                        column: x => x.Plan_Id,
                        principalTable: "Plan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Purchase_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purchase_Id = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Details_Purchase",
                        column: x => x.Purchase_Id,
                        principalTable: "Purchase",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Step_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Step_Id = table.Column<int>(type: "int", nullable: false),
                    Agricultural_Item_Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Step_Details_Agricultural_Item",
                        column: x => x.Agricultural_Item_Id,
                        principalTable: "Agricultural_Item",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Step_Details_Step",
                        column: x => x.Step_Id,
                        principalTable: "Step",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Engineer_Engineer_Type_Id",
                table: "Engineer",
                column: "Engineer_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Engineer_Head_Engineer_Id",
                table: "Engineer",
                column: "Head_Engineer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Land_Farmer_Id",
                table: "Land",
                column: "Farmer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Land_Soil_Type_Id",
                table: "Land",
                column: "Soil_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Land_Type_Id",
                table: "Land",
                column: "Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Admin_Engineer_Id",
                table: "Order",
                column: "Admin_Engineer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Buyer_Id",
                table: "Order",
                column: "Buyer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Executive_Team_Id",
                table: "Order",
                column: "Executive_Team_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_Item_Id",
                table: "Order_Details",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_Order_Id",
                table: "Order_Details",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_Land_Id",
                table: "Plan",
                column: "Land_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_Order_Details_Id",
                table: "Plan",
                column: "Order_Details_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Plan_Id",
                table: "Purchase",
                column: "Plan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Store_Id",
                table: "Purchase",
                column: "Store_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Details_Purchase_Id",
                table: "Purchase_Details",
                column: "Purchase_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Action_Id",
                table: "Step",
                column: "Action_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Plan_Id",
                table: "Step",
                column: "Plan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Details_Agricultural_Item_Id",
                table: "Step_Details",
                column: "Agricultural_Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Details_Step_Id",
                table: "Step_Details",
                column: "Step_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Type_Id",
                table: "Store",
                column: "Type_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase_Details");

            migrationBuilder.DropTable(
                name: "Step_Details");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Agricultural_Item");

            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "Store_Type");

            migrationBuilder.DropTable(
                name: "Land");

            migrationBuilder.DropTable(
                name: "Order_Details");

            migrationBuilder.DropTable(
                name: "Farmer");

            migrationBuilder.DropTable(
                name: "Land_Type");

            migrationBuilder.DropTable(
                name: "Soil_Type");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.DropTable(
                name: "Engineer");

            migrationBuilder.DropTable(
                name: "Engineer_Type");
        }
    }
}
