using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApplicationCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    SalarioBase = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cargo__3214EC0721FD1E19", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Presupuesto = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departam__3214EC0761F11BC9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombres = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    DepartamentoId = table.Column<int>(type: "integer", nullable: false),
                    CargoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empleado__3214EC0700716A1A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Empleado__CargoI__3D5E1FD2",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Empleado__Depart__3C69FB99",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Asistencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpleadoId = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    HoraEntrada = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    HoraSalida = table.Column<TimeOnly>(type: "time without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Asistenc__3214EC079485D30E", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Asistenci__Emple__4316F928",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpleadoId = table.Column<int>(type: "integer", nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: true),
                    Tipo = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Contrato__3214EC079E281EC0", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Contrato__Emplea__403A8C7D",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EvaluacionDesempeno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpleadoId = table.Column<int>(type: "integer", nullable: false),
                    FechaEvaluacion = table.Column<DateOnly>(type: "date", nullable: false),
                    Puntuacion = table.Column<int>(type: "integer", nullable: false),
                    Comentarios = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Evaluaci__3214EC07BC8C1015", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Evaluacio__Emple__4E88ABD4",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nomina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpleadoId = table.Column<int>(type: "integer", nullable: false),
                    FechaEmision = table.Column<DateOnly>(type: "date", nullable: false),
                    SalarioNeto = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Deducciones = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nomina__3214EC07A7CB722C", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Nomina__Empleado__45F365D3",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpleadoId = table.Column<int>(type: "integer", nullable: false),
                    FechaSolicitud = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "now()"),
                    Dias = table.Column<int>(type: "integer", nullable: false),
                    Motivo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Estado = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "Pendiente")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Permiso__3214EC07FED0AEB1", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Permiso__Emplead__4AB81AF0",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_EmpleadoId",
                table: "Asistencia",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_EmpleadoId",
                table: "Contrato",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CargoId",
                table: "Empleado",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_DepartamentoId",
                table: "Empleado",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "UQ__Empleado__A9D105349DBE8487",
                table: "Empleado",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EvaluacionDesempeno_EmpleadoId",
                table: "EvaluacionDesempeno",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_EmpleadoId",
                table: "Nomina",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_EmpleadoId",
                table: "Permiso",
                column: "EmpleadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencia");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "EvaluacionDesempeno");

            migrationBuilder.DropTable(
                name: "Nomina");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
