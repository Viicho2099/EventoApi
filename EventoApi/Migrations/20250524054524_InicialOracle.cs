using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventoApi.Migrations
{
    /// <inheritdoc />
    public partial class InicialOracle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventosTable", // Cambié "Eventos1" por "EventosTable"
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Lugar = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosTable", x => x.EventoId); // Cambié la clave primaria
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    ParticipanteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.ParticipanteId);
                });

            migrationBuilder.CreateTable(
                name: "Ponentes",
                columns: table => new
                {
                    PonenteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Apellido = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Bio = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponentes", x => x.PonenteId);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    SesionId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.SesionId);
                    table.ForeignKey(
                        name: "FK_Sesiones_EventosTable_EventoId", // Cambié "Eventos1" por "EventosTable"
                        column: x => x.EventoId,
                        principalTable: "EventosTable", // Cambié "Eventos1" por "EventosTable"
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    InscripcionId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ParticipanteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.InscripcionId);
                    table.ForeignKey(
                        name: "FK_Inscripciones_EventosTable_EventoId", // Cambié "Eventos1" por "EventosTable"
                        column: x => x.EventoId,
                        principalTable: "EventosTable", // Cambié "Eventos1" por "EventosTable"
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "ParticipanteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PonentesEventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PonenteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PonenteEventoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PonentesEventos", x => new { x.EventoId, x.PonenteId });
                    table.ForeignKey(
                        name: "FK_PonentesEventos_EventosTable_EventoId", // Cambié "Eventos1" por "EventosTable"
                        column: x => x.EventoId,
                        principalTable: "EventosTable", // Cambié "Eventos1" por "EventosTable"
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PonentesEventos_Ponentes_PonenteId",
                        column: x => x.PonenteId,
                        principalTable: "Ponentes",
                        principalColumn: "PonenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Monto = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    FechaPago = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    InscripcionId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pagos_Inscripciones_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "Inscripciones",
                        principalColumn: "InscripcionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EventoId",
                table: "Inscripciones",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ParticipanteId",
                table: "Inscripciones",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_InscripcionId",
                table: "Pagos",
                column: "InscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_PonentesEventos_PonenteId",
                table: "PonentesEventos",
                column: "PonenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_EventoId",
                table: "Sesiones",
                column: "EventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "PonentesEventos");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Ponentes");

            migrationBuilder.DropTable(
                name: "EventosTable"); // Cambié "Eventos1" por "EventosTable"

            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}

