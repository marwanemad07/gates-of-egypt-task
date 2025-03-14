using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_items_carts_CartId",
                table: "cart_items");

            migrationBuilder.DropForeignKey(
                name: "FK_cart_items_products_ProductId",
                table: "cart_items");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_users_UserId",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_product_translations_products_ProductId",
                table: "product_translations");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "users",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "users",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "users",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "users",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "products",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "products",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "product_translations",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "product_translations",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "product_translations",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "LanguageCode",
                table: "product_translations",
                newName: "language_code");

            migrationBuilder.RenameIndex(
                name: "IX_product_translations_ProductId",
                table: "product_translations",
                newName: "IX_product_translations_product_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "carts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "carts",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "carts",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "carts",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_carts_UserId",
                table: "carts",
                newName: "IX_carts_user_id");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "cart_items",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cart_items",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "cart_items",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "cart_items",
                newName: "cart_id");

            migrationBuilder.RenameIndex(
                name: "IX_cart_items_ProductId",
                table: "cart_items",
                newName: "IX_cart_items_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_cart_items_CartId",
                table: "cart_items",
                newName: "IX_cart_items_cart_id");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_items_carts_cart_id",
                table: "cart_items",
                column: "cart_id",
                principalTable: "carts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cart_items_products_product_id",
                table: "cart_items",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_users_user_id",
                table: "carts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_translations_products_product_id",
                table: "product_translations",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_items_carts_cart_id",
                table: "cart_items");

            migrationBuilder.DropForeignKey(
                name: "FK_cart_items_products_product_id",
                table: "cart_items");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_users_user_id",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_product_translations_products_product_id",
                table: "product_translations");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "users",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "products",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "products",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "product_translations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "product_translations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "product_translations",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "language_code",
                table: "product_translations",
                newName: "LanguageCode");

            migrationBuilder.RenameIndex(
                name: "IX_product_translations_product_id",
                table: "product_translations",
                newName: "IX_product_translations_ProductId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "carts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "carts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "carts",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "carts",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_carts_user_id",
                table: "carts",
                newName: "IX_carts_UserId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "cart_items",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "cart_items",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "cart_items",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "cart_id",
                table: "cart_items",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_cart_items_product_id",
                table: "cart_items",
                newName: "IX_cart_items_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_cart_items_cart_id",
                table: "cart_items",
                newName: "IX_cart_items_CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_cart_items_carts_CartId",
                table: "cart_items",
                column: "CartId",
                principalTable: "carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cart_items_products_ProductId",
                table: "cart_items",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_users_UserId",
                table: "carts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_translations_products_ProductId",
                table: "product_translations",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
