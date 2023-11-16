using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenunciasAmbientaisAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Denuncias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoDenuncia = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    LocalDenuncia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DataDenuncia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FotoDenuncia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataVerificacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DenunciaVerificada = table.Column<bool>(type: "bit", nullable: true),
                    DenunciaEncaminhadaParaAutoridades = table.Column<bool>(type: "bit", nullable: true),
                    QualAutoridadeFoiEncaminhada = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncias", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Denuncias");
        }
    }
}
