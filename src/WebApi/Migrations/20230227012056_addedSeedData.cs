using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class addedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Reference",
                table: "Properties",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "NULL");

            migrationBuilder.InsertData(
                table: "FeatureTypes",
                columns: new[] { "FeatureTypeId", "Code", "CreatedOn", "Name", "UpdatedOn" },
                values: new object[] { 1, "FT01", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apartment", null });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Reference",
                table: "Properties",
                column: "Reference",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Properties_Reference",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "FeatureTypes",
                keyColumn: "FeatureTypeId",
                keyValue: 1);

            migrationBuilder.AlterColumn<long>(
                name: "Reference",
                table: "Properties",
                type: "bigint",
                nullable: false,
                defaultValueSql: "NULL",
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
