using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameCategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameMethode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresseUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idTypeUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Username);
                    table.ForeignKey(
                        name: "FK_User_TypeUser_TypeUserId",
                        column: x => x.TypeUserId,
                        principalTable: "TypeUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresseItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceItem = table.Column<float>(type: "real", nullable: false),
                    DatePost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QteItem = table.Column<int>(type: "int", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    idCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    idImage = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_User_Username",
                        column: x => x.Username,
                        principalTable: "User",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateMessage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usernameProvider = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    usernameReceiver = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_User_usernameProvider",
                        column: x => x.usernameProvider,
                        principalTable: "User",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_User_usernameReceiver",
                        column: x => x.usernameReceiver,
                        principalTable: "User",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Qte = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    idItem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_User_Username",
                        column: x => x.Username,
                        principalTable: "User",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commande",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    DateCommande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QteCommande = table.Column<int>(type: "int", nullable: false),
                    priceCommande = table.Column<double>(type: "float", nullable: false),
                    idItem = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    idPaymentMethode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    idUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commande", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commande_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commande_PaymentMethode_PaymentMethodeId",
                        column: x => x.PaymentMethodeId,
                        principalTable: "PaymentMethode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commande_User_Username",
                        column: x => x.Username,
                        principalTable: "User",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemPaymentMethode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    idItem = table.Column<int>(type: "int", nullable: false),
                    idPaymentMethode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPaymentMethode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPaymentMethode_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPaymentMethode_PaymentMethode_PaymentMethodeId",
                        column: x => x.PaymentMethodeId,
                        principalTable: "PaymentMethode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dateDelivery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceDelivery = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idDeliveryMan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryManUsername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    idCommande = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommandeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delivery_Commande_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commande",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Delivery_User_DeliveryManUsername",
                        column: x => x.DeliveryManUsername,
                        principalTable: "User",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TypeUser",
                columns: new[] { "Id", "nameType" },
                values: new object[] { new Guid("5849b298-1663-4b57-9356-e8af058e24b8"), "User" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Username", "AdresseUser", "Fullname", "Numero", "Password", "TypeUserId", "idTypeUser" },
                values: new object[] { "test", null, null, "0618053929", "test", null, new Guid("5849b298-1663-4b57-9356-e8af058e24b8") });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ItemId",
                table: "Cart",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Username",
                table: "Cart",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_ItemId",
                table: "Commande",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_PaymentMethodeId",
                table: "Commande",
                column: "PaymentMethodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_Username",
                table: "Commande",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_CommandeId",
                table: "Delivery",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_DeliveryManUsername",
                table: "Delivery",
                column: "DeliveryManUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryId",
                table: "Item",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ImageId",
                table: "Item",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Username",
                table: "Item",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPaymentMethode_ItemId",
                table: "ItemPaymentMethode",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPaymentMethode_PaymentMethodeId",
                table: "ItemPaymentMethode",
                column: "PaymentMethodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_usernameProvider",
                table: "Message",
                column: "usernameProvider");

            migrationBuilder.CreateIndex(
                name: "IX_Message_usernameReceiver",
                table: "Message",
                column: "usernameReceiver");

            migrationBuilder.CreateIndex(
                name: "IX_User_TypeUserId",
                table: "User",
                column: "TypeUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "ItemPaymentMethode");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Commande");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "PaymentMethode");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TypeUser");
        }
    }
}
