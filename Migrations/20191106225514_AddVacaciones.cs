using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_BU.Migrations
{
    public partial class AddVacaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Estatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    estatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Num_ext = table.Column<string>(nullable: true),
                    Num_int = table.Column<string>(nullable: true),
                    Cp = table.Column<int>(nullable: false),
                    Colonia = table.Column<string>(nullable: true),
                    Municipio = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Entre_calle1 = table.Column<string>(nullable: true),
                    Entre_calle2 = table.Column<string>(nullable: true),
                    Curp = table.Column<string>(nullable: true),
                    Rfc = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    Edo_ivil = table.Column<string>(nullable: true),
                    Fecha_nacimiento = table.Column<DateTime>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Num_trajeta = table.Column<int>(nullable: false),
                    Cta_bancaria = table.Column<int>(nullable: false),
                    Imss = table.Column<int>(nullable: false),
                    Umf = table.Column<int>(nullable: false),
                    Categoria = table.Column<string>(nullable: true),
                    Credito_info = table.Column<int>(nullable: false),
                    Porcentaje_info = table.Column<int>(nullable: false),
                    Nombre_padre = table.Column<string>(nullable: true),
                    Nombre_madre = table.Column<string>(nullable: true),
                    Lugar_nacimiento = table.Column<string>(nullable: true),
                    Tarjet_despensa = table.Column<int>(nullable: false),
                    Cuenta_despensa = table.Column<int>(nullable: false),
                    Afore = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fecha_ingreso = table.Column<DateTime>(nullable: false),
                    Salario_diario = table.Column<float>(nullable: false),
                    Salrio_base = table.Column<float>(nullable: false),
                    Sdi = table.Column<float>(nullable: false),
                    Dias_contrato = table.Column<int>(nullable: false),
                    Fecha_creacion = table.Column<DateTime>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Id_usuario_creo = table.Column<int>(nullable: false),
                    Id_puesto = table.Column<int>(nullable: false),
                    Id_contrato = table.Column<int>(nullable: false),
                    EmpresaID = table.Column<int>(nullable: false),
                    reloj = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.EmpleadoID);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre_empresa = table.Column<string>(nullable: true),
                    Rfc_empresa = table.Column<string>(nullable: true),
                    Direccion_empresa = table.Column<string>(nullable: true),
                    Num_ext_empresa = table.Column<string>(nullable: true),
                    Num_int_empresa = table.Column<string>(nullable: true),
                    Estado_empresa = table.Column<string>(nullable: true),
                    Pais_empresa = table.Column<string>(nullable: true),
                    Municipio_empresa = table.Column<string>(nullable: true),
                    Cp_empresa = table.Column<int>(nullable: false),
                    Logo_empresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaID);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    El = table.Column<string>(maxLength: 10, nullable: true),
                    Sl = table.Column<string>(maxLength: 10, nullable: true),
                    Emar = table.Column<string>(maxLength: 10, nullable: true),
                    Smar = table.Column<string>(maxLength: 10, nullable: true),
                    EMier = table.Column<string>(maxLength: 10, nullable: true),
                    SMier = table.Column<string>(maxLength: 10, nullable: true),
                    EJ = table.Column<string>(maxLength: 10, nullable: true),
                    SJ = table.Column<string>(maxLength: 10, nullable: true),
                    EV = table.Column<string>(maxLength: 10, nullable: true),
                    SV = table.Column<string>(maxLength: 10, nullable: true),
                    ES = table.Column<string>(maxLength: 10, nullable: true),
                    SS = table.Column<string>(maxLength: 10, nullable: true),
                    ED = table.Column<string>(maxLength: 10, nullable: true),
                    SD = table.Column<string>(maxLength: 10, nullable: true),
                    Turno = table.Column<bool>(nullable: false),
                    Dinicio = table.Column<int>(nullable: false),
                    Dtrabajar = table.Column<int>(nullable: false),
                    Ttrabajar = table.Column<int>(nullable: false),
                    Estatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgHorario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_emp = table.Column<int>(nullable: false),
                    Id_horario = table.Column<int>(nullable: false),
                    semana = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgHorario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reloj",
                columns: table => new
                {
                    RelojID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ip = table.Column<string>(nullable: true),
                    Protocolo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reloj", x => x.RelojID);
                });

            migrationBuilder.CreateTable(
                name: "Vacaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_emp = table.Column<int>(nullable: false),
                    Fh_solic = table.Column<DateTime>(nullable: false),
                    Periodo = table.Column<int>(nullable: false),
                    Dias_periodo = table.Column<int>(nullable: false),
                    Dias_disp = table.Column<int>(nullable: false),
                    D_solicita = table.Column<int>(nullable: false),
                    D_restantes = table.Column<int>(nullable: false),
                    Fh_inicio = table.Column<DateTime>(nullable: false),
                    Fh_fin = table.Column<DateTime>(nullable: false),
                    UsuSol = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    Descansos = table.Column<int>(nullable: false),
                    Canc = table.Column<bool>(nullable: false),
                    Usu_can = table.Column<int>(nullable: false),
                    Obs_can = table.Column<string>(nullable: true),
                    Fh_canc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Puesto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    id_depto = table.Column<int>(nullable: false),
                    estatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puesto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Puesto_Departamento_id_depto",
                        column: x => x.id_depto,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Puesto_id_depto",
                table: "Puesto",
                column: "id_depto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "ProgHorario");

            migrationBuilder.DropTable(
                name: "Puesto");

            migrationBuilder.DropTable(
                name: "Reloj");

            migrationBuilder.DropTable(
                name: "Vacaciones");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
