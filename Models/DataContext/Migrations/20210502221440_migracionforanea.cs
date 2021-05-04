using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace APITienda.Migrations
{
    public partial class migracionforanea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacto",
                table: "Contacto");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Contacto",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "personaId",
                table: "Contacto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacto",
                table: "Contacto",
                columns: new[] { "Id", "personaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_personaId",
                table: "Contacto",
                column: "personaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacto_Persona_personaId",
                table: "Contacto",
                column: "personaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacto_Persona_personaId",
                table: "Contacto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacto",
                table: "Contacto");

            migrationBuilder.DropIndex(
                name: "IX_Contacto_personaId",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "personaId",
                table: "Contacto");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Contacto",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacto",
                table: "Contacto",
                column: "Id");
        }
    }
}
