using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Property.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    paisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.paisId);
                });

            migrationBuilder.CreateTable(
                name: "servicio",
                columns: table => new
                {
                    servicioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicio", x => x.servicioId);
                });

            migrationBuilder.CreateTable(
                name: "tipoPropiedad",
                columns: table => new
                {
                    tipoPropiedadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoPropiedad", x => x.tipoPropiedadId);
                });

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    itemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    paisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.itemId);
                    table.ForeignKey(
                        name: "FK_ciudad_pais_paisId",
                        column: x => x.paisId,
                        principalTable: "pais",
                        principalColumn: "paisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propiedad",
                columns: table => new
                {
                    propiedadItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    fueVerificado = table.Column<bool>(type: "bit", nullable: false),
                    tipoPropiedadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ciudadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propiedad", x => x.propiedadItemId);
                    table.ForeignKey(
                        name: "FK_propiedad_ciudad_ciudadId",
                        column: x => x.ciudadId,
                        principalTable: "ciudad",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_propiedad_tipoPropiedad_tipoPropiedadId",
                        column: x => x.tipoPropiedadId,
                        principalTable: "tipoPropiedad",
                        principalColumn: "tipoPropiedadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ciudad_paisId",
                table: "ciudad",
                column: "paisId");

            migrationBuilder.CreateIndex(
                name: "IX_propiedad_ciudadId",
                table: "propiedad",
                column: "ciudadId");

            migrationBuilder.CreateIndex(
                name: "IX_propiedad_tipoPropiedadId",
                table: "propiedad",
                column: "tipoPropiedadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "propiedad");

            migrationBuilder.DropTable(
                name: "servicio");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "tipoPropiedad");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}
