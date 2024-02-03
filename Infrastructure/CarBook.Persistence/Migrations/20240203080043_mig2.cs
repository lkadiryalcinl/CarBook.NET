using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDescriptions_Cars_CarID",
                table: "CarDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_CarFeatures_Cars_CarID",
                table: "CarFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_CarFeatures_Features_FeatureID",
                table: "CarFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_CarPricings_Cars_CarID",
                table: "CarPricings");

            migrationBuilder.DropForeignKey(
                name: "FK_CarPricings_Pricings_PricingID",
                table: "CarPricings");

            migrationBuilder.DropIndex(
                name: "IX_CarPricings_CarID",
                table: "CarPricings");

            migrationBuilder.DropIndex(
                name: "IX_CarPricings_PricingID",
                table: "CarPricings");

            migrationBuilder.DropIndex(
                name: "IX_CarFeatures_CarID",
                table: "CarFeatures");

            migrationBuilder.DropIndex(
                name: "IX_CarFeatures_FeatureID",
                table: "CarFeatures");

            migrationBuilder.DropIndex(
                name: "IX_CarDescriptions_CarID",
                table: "CarDescriptions");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Testimonials",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "SocialMedias",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Services",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Pricings",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "FooterAddresses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Features",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandID",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "CarPricings",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "CarID1",
                table: "CarPricings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PricingID1",
                table: "CarPricings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "CarFeatures",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "CarID1",
                table: "CarFeatures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureID1",
                table: "CarFeatures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "CarDescriptions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "CarID1",
                table: "CarDescriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Brands",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Banners",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Abouts",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_CarPricings_CarID1",
                table: "CarPricings",
                column: "CarID1");

            migrationBuilder.CreateIndex(
                name: "IX_CarPricings_PricingID1",
                table: "CarPricings",
                column: "PricingID1");

            migrationBuilder.CreateIndex(
                name: "IX_CarFeatures_CarID1",
                table: "CarFeatures",
                column: "CarID1");

            migrationBuilder.CreateIndex(
                name: "IX_CarFeatures_FeatureID1",
                table: "CarFeatures",
                column: "FeatureID1");

            migrationBuilder.CreateIndex(
                name: "IX_CarDescriptions_CarID1",
                table: "CarDescriptions",
                column: "CarID1");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDescriptions_Cars_CarID1",
                table: "CarDescriptions",
                column: "CarID1",
                principalTable: "Cars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarFeatures_Cars_CarID1",
                table: "CarFeatures",
                column: "CarID1",
                principalTable: "Cars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarFeatures_Features_FeatureID1",
                table: "CarFeatures",
                column: "FeatureID1",
                principalTable: "Features",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPricings_Cars_CarID1",
                table: "CarPricings",
                column: "CarID1",
                principalTable: "Cars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPricings_Pricings_PricingID1",
                table: "CarPricings",
                column: "PricingID1",
                principalTable: "Pricings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDescriptions_Cars_CarID1",
                table: "CarDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_CarFeatures_Cars_CarID1",
                table: "CarFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_CarFeatures_Features_FeatureID1",
                table: "CarFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_CarPricings_Cars_CarID1",
                table: "CarPricings");

            migrationBuilder.DropForeignKey(
                name: "FK_CarPricings_Pricings_PricingID1",
                table: "CarPricings");

            migrationBuilder.DropIndex(
                name: "IX_CarPricings_CarID1",
                table: "CarPricings");

            migrationBuilder.DropIndex(
                name: "IX_CarPricings_PricingID1",
                table: "CarPricings");

            migrationBuilder.DropIndex(
                name: "IX_CarFeatures_CarID1",
                table: "CarFeatures");

            migrationBuilder.DropIndex(
                name: "IX_CarFeatures_FeatureID1",
                table: "CarFeatures");

            migrationBuilder.DropIndex(
                name: "IX_CarDescriptions_CarID1",
                table: "CarDescriptions");

            migrationBuilder.DropColumn(
                name: "CarID1",
                table: "CarPricings");

            migrationBuilder.DropColumn(
                name: "PricingID1",
                table: "CarPricings");

            migrationBuilder.DropColumn(
                name: "CarID1",
                table: "CarFeatures");

            migrationBuilder.DropColumn(
                name: "FeatureID1",
                table: "CarFeatures");

            migrationBuilder.DropColumn(
                name: "CarID1",
                table: "CarDescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Testimonials",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "SocialMedias",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Services",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Pricings",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Locations",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "FooterAddresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Features",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Contacts",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Categories",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "BrandID",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "CarPricings",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "CarFeatures",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "CarDescriptions",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Brands",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Banners",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Abouts",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_CarPricings_CarID",
                table: "CarPricings",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_CarPricings_PricingID",
                table: "CarPricings",
                column: "PricingID");

            migrationBuilder.CreateIndex(
                name: "IX_CarFeatures_CarID",
                table: "CarFeatures",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_CarFeatures_FeatureID",
                table: "CarFeatures",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_CarDescriptions_CarID",
                table: "CarDescriptions",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDescriptions_Cars_CarID",
                table: "CarDescriptions",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarFeatures_Cars_CarID",
                table: "CarFeatures",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarFeatures_Features_FeatureID",
                table: "CarFeatures",
                column: "FeatureID",
                principalTable: "Features",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPricings_Cars_CarID",
                table: "CarPricings",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPricings_Pricings_PricingID",
                table: "CarPricings",
                column: "PricingID",
                principalTable: "Pricings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
