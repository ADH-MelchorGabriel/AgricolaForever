using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EYE.Servicio.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgenciaAduana",
                columns: table => new
                {
                    IdAgenciaAduana = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgenciaAduana", x => x.IdAgenciaAduana);
                });

            migrationBuilder.CreateTable(
                name: "Agricultor",
                columns: table => new
                {
                    IdAgricultor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agricultor", x => x.IdAgricultor);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    IdArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TipoArticulo = table.Column<int>(type: "int", nullable: false),
                    Existencia = table.Column<double>(type: "float", nullable: false),
                    CostoPromedio = table.Column<double>(type: "float", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.IdArticulo);
                });

            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    IdBanco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.IdBanco);
                });

            migrationBuilder.CreateTable(
                name: "ClaveCatastral",
                columns: table => new
                {
                    IdClaveCatastral = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLote = table.Column<int>(type: "int", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaveCatastral", x => x.IdClaveCatastral);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFC = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CveRecidenciaFiscal = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CveRegimenFiscal = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NumRegIdTrib = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DomicilioFiscal = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Destino",
                columns: table => new
                {
                    IdDestino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Calle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroExterior = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CvePais = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CveEstado = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino", x => x.IdDestino);
                });

           

           


            migrationBuilder.CreateTable(
                name: "Empaque",
                columns: table => new
                {
                    IdEmpaque = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empaque", x => x.IdEmpaque);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroExterior = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CvePais = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CveEstado = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CveRegimenFiscal = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    IdEntrada = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Folio = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.IdEntrada);
                });

            migrationBuilder.CreateTable(
                name: "Envase",
                columns: table => new
                {
                    IdEnvase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envase", x => x.IdEnvase);
                });

            

            migrationBuilder.CreateTable(
                name: "FamiliaCultivo",
                columns: table => new
                {
                    IdFamiliaCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamiliaCultivo", x => x.IdFamiliaCultivo);
                });

            migrationBuilder.CreateTable(
                name: "LineaTransporte",
                columns: table => new
                {
                    IdLineaTransporte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaTransporte", x => x.IdLineaTransporte);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    IdLote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    MunicipioProductor = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UbicacionPredio = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Sector = table.Column<int>(type: "int", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.IdLote);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Tamaño",
                columns: table => new
                {
                    IdTamaño = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tamaño", x => x.IdTamaño);
                });

            migrationBuilder.CreateTable(
                name: "Temporada",
                columns: table => new
                {
                    IdTemporada = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporada", x => x.IdTemporada);
                });

            migrationBuilder.CreateTable(
                name: "TipoCambio",
                columns: table => new
                {
                    IdTipoCambio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCambio", x => x.IdTipoCambio);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "EntradaDetalle",
                columns: table => new
                {
                    IdEntradaDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEntrada = table.Column<int>(type: "int", nullable: false),
                    IdArticulo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<double>(type: "float", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaDetalle", x => x.IdEntradaDetalle);
                    table.ForeignKey(
                        name: "FK_EntradaDetalle_Articulos_IdArticulo",
                        column: x => x.IdArticulo,
                        principalTable: "Articulos",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntradaDetalle_Entrada_IdEntrada",
                        column: x => x.IdEntrada,
                        principalTable: "Entrada",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cultivo",
                columns: table => new
                {
                    IdCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdFamiliaCultivo = table.Column<int>(type: "int", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivo", x => x.IdCultivo);
                    table.ForeignKey(
                        name: "FK_Cultivo_FamiliaCultivo_IdFamiliaCultivo",
                        column: x => x.IdFamiliaCultivo,
                        principalTable: "FamiliaCultivo",
                        principalColumn: "IdFamiliaCultivo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Choferes",
                columns: table => new
                {
                    IdChofer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    IdLineaTransporte = table.Column<int>(type: "int", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choferes", x => x.IdChofer);
                    table.ForeignKey(
                        name: "FK_Choferes_LineaTransporte_IdLineaTransporte",
                        column: x => x.IdLineaTransporte,
                        principalTable: "LineaTransporte",
                        principalColumn: "IdLineaTransporte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Remolque",
                columns: table => new
                {
                    IdRemolque = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    Placas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdLineaTransporte = table.Column<int>(type: "int", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remolque", x => x.IdRemolque);
                    table.ForeignKey(
                        name: "FK_Remolque_LineaTransporte_IdLineaTransporte",
                        column: x => x.IdLineaTransporte,
                        principalTable: "LineaTransporte",
                        principalColumn: "IdLineaTransporte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    Placas = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Apodo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdLineaTransporte = table.Column<int>(type: "int", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculos_LineaTransporte_IdLineaTransporte",
                        column: x => x.IdLineaTransporte,
                        principalTable: "LineaTransporte",
                        principalColumn: "IdLineaTransporte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Palet",
                columns: table => new
                {
                    IdPalet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpaque = table.Column<int>(type: "int", nullable: false),
                    Folio = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    TipoPalet = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTemporada = table.Column<int>(type: "int", nullable: false),
                    EsGaseado = table.Column<bool>(type: "bit", nullable: false),
                    EsPaletChep = table.Column<bool>(type: "bit", nullable: false),
                    EstadoPalet = table.Column<int>(type: "int", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palet", x => x.IdPalet);
                    table.ForeignKey(
                        name: "FK_Palet_Empaque_IdEmpaque",
                        column: x => x.IdEmpaque,
                        principalTable: "Empaque",
                        principalColumn: "IdEmpaque",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Palet_Temporada_IdTemporada",
                        column: x => x.IdTemporada,
                        principalTable: "Temporada",
                        principalColumn: "IdTemporada",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolUsuario",
                columns: table => new
                {
                    IdRolUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuario", x => x.IdRolUsuario);
                    table.ForeignKey(
                        name: "FK_RolUsuario_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolUsuario_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcarreoCampo",
                columns: table => new
                {
                    IdAcarreoCampo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Folio = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdLote = table.Column<int>(type: "int", nullable: false),
                    IdCultivo = table.Column<int>(type: "int", nullable: false),
                    Mayordomo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chofer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlacasVehiculo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PlacasRemolque = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Cajas = table.Column<double>(type: "float", nullable: false),
                    Kilogramos = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcarreoCampo", x => x.IdAcarreoCampo);
                    table.ForeignKey(
                        name: "FK_AcarreoCampo_Cultivo_IdCultivo",
                        column: x => x.IdCultivo,
                        principalTable: "Cultivo",
                        principalColumn: "IdCultivo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcarreoCampo_Lote_IdLote",
                        column: x => x.IdLote,
                        principalTable: "Lote",
                        principalColumn: "IdLote",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    IdCultivo = table.Column<int>(type: "int", nullable: false),
                    IdTamaño = table.Column<int>(type: "int", nullable: false),
                    IdEnvase = table.Column<int>(type: "int", nullable: false),
                    Libras = table.Column<double>(type: "float", nullable: false),
                    PesoKg = table.Column<double>(type: "float", nullable: false),
                    CveFraccionArancelaria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CveProductoServicio = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    CveUnidadMedida = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Calidad = table.Column<int>(type: "int", nullable: false),
                    FolioGuia = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Cultivo_IdCultivo",
                        column: x => x.IdCultivo,
                        principalTable: "Cultivo",
                        principalColumn: "IdCultivo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Envase_IdEnvase",
                        column: x => x.IdEnvase,
                        principalTable: "Envase",
                        principalColumn: "IdEnvase",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Tamaño_IdTamaño",
                        column: x => x.IdTamaño,
                        principalTable: "Tamaño",
                        principalColumn: "IdTamaño",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Embarque",
                columns: table => new
                {
                    IdEmbarque = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTemporada = table.Column<int>(type: "int", nullable: false),
                    Manifiesto = table.Column<int>(type: "int", nullable: false),
                    TipoEmbarque = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    CAADES = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    IdAgenciaAduana = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdVehiculo = table.Column<int>(type: "int", nullable: false),
                    IdChofer = table.Column<int>(type: "int", nullable: false),
                    IdRemolque = table.Column<int>(type: "int", nullable: false),
                    IdDestino = table.Column<int>(type: "int", nullable: false),
                    Temperatura = table.Column<int>(type: "int", nullable: false),
                    FolioFiscalDigital = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    SelloPuesto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SelloRepuesto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    EstaTimbrado = table.Column<bool>(type: "bit", nullable: false),
                    IdBanco = table.Column<int>(type: "int", nullable: true),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReferenciaPago = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Importe = table.Column<double>(type: "float", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Embarque", x => x.IdEmbarque);
                    table.ForeignKey(
                        name: "FK_Embarque_AgenciaAduana_IdAgenciaAduana",
                        column: x => x.IdAgenciaAduana,
                        principalTable: "AgenciaAduana",
                        principalColumn: "IdAgenciaAduana",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Embarque_Banco_IdBanco",
                        column: x => x.IdBanco,
                        principalTable: "Banco",
                        principalColumn: "IdBanco",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Embarque_Choferes_IdChofer",
                        column: x => x.IdChofer,
                        principalTable: "Choferes",
                        principalColumn: "IdChofer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Embarque_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Embarque_Destino_IdDestino",
                        column: x => x.IdDestino,
                        principalTable: "Destino",
                        principalColumn: "IdDestino",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Embarque_Remolque_IdRemolque",
                        column: x => x.IdRemolque,
                        principalTable: "Remolque",
                        principalColumn: "IdRemolque",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Embarque_Temporada_IdTemporada",
                        column: x => x.IdTemporada,
                        principalTable: "Temporada",
                        principalColumn: "IdTemporada",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Embarque_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Embarque_Vehiculos_IdVehiculo",
                        column: x => x.IdVehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "IdVehiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaletDetalle",
                columns: table => new
                {
                    IdPaletDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPalet = table.Column<int>(type: "int", nullable: false),
                    IdAgricultor = table.Column<int>(type: "int", nullable: false),
                    IdLote = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    EstaAcivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaletDetalle", x => x.IdPaletDetalle);
                    table.ForeignKey(
                        name: "FK_PaletDetalle_Agricultor_IdAgricultor",
                        column: x => x.IdAgricultor,
                        principalTable: "Agricultor",
                        principalColumn: "IdAgricultor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaletDetalle_Lote_IdLote",
                        column: x => x.IdLote,
                        principalTable: "Lote",
                        principalColumn: "IdLote",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaletDetalle_Palet_IdPalet",
                        column: x => x.IdPalet,
                        principalTable: "Palet",
                        principalColumn: "IdPalet",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaletDetalle_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmbarqueDetalle",
                columns: table => new
                {
                    IdEmbarqueDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmbarque = table.Column<int>(type: "int", nullable: false),
                    IdPalet = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    EsSobrePeso = table.Column<bool>(type: "bit", nullable: false),
                    Posicion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmbarqueDetalle", x => x.IdEmbarqueDetalle);
                    table.ForeignKey(
                        name: "FK_EmbarqueDetalle_Embarque_IdEmbarque",
                        column: x => x.IdEmbarque,
                        principalTable: "Embarque",
                        principalColumn: "IdEmbarque",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmbarqueDetalle_Palet_IdPalet",
                        column: x => x.IdPalet,
                        principalTable: "Palet",
                        principalColumn: "IdPalet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AgenciaAduana",
                columns: new[] { "IdAgenciaAduana", "EstaActivo", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Saviñon y Suarez Brokerage, Company INC" },
                    { 2, true, "RM S DE RL DE CV" },
                    { 3, true, "Valverde y Suarez Brokerage, Company INC" }
                });

            migrationBuilder.InsertData(
                table: "Agricultor",
                columns: new[] { "IdAgricultor", "Codigo", "EstaActivo", "Nombre" },
                values: new object[,]
                {
                    { 1, "AF", true, "agricola forever young farms" },
                    { 2, "AA", true, "AGRICOLA YOUNG 2" }
                });

            migrationBuilder.InsertData(
                table: "Empaque",
                columns: new[] { "IdEmpaque", "Codigo", "EstaActivo", "Nombre" },
                values: new object[] { 1, "E1", true, "Empaque principal" });

            migrationBuilder.InsertData(
                table: "Envase",
                columns: new[] { "IdEnvase", "EstaActivo", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "CARTON" },
                    { 2, true, "CAJA DE PLASTICO" },
                    { 3, true, "Bolsas" }
                });

            migrationBuilder.InsertData(
                table: "FamiliaCultivo",
                columns: new[] { "IdFamiliaCultivo", "EstaActivo", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "BERENJENA" },
                    { 2, true, "BITTERMELON" },
                    { 3, true, "EJOTE" },
                    { 4, true, "CHILES" },
                    { 5, true, "OPO" },
                    { 6, true, "SINGUA" },
                    { 7, true, "Calabazas" },
                    { 8, true, "MOQUA" }
                });

            migrationBuilder.InsertData(
                table: "LineaTransporte",
                columns: new[] { "IdLineaTransporte", "EstaActivo", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, true, "Juan Carlos Sanchez Siqueiros", "" },
                    { 2, true, "TRANSPORTES INTERNACIONALES JCV SA DE CV", "" },
                    { 3, true, "ALMA NUEMI PAYAN GASTELUM", "" }
                });

            migrationBuilder.InsertData(
                table: "Lote",
                columns: new[] { "IdLote", "Codigo", "EstaActivo", "MunicipioProductor", "Nombre", "Sector", "UbicacionPredio" },
                values: new object[,]
                {
                    { 1, "UN", true, "Navolato", "Lote 1", 0, "" },
                    { 2, "L2", true, "Navolato", "Lote 2", 0, "" },
                    { 3, "EP", true, "Navolato", "El pozo", 0, "" },
                    { 4, "EA", true, "Navolato", "El Aguacate", 0, "" },
                    { 5, "EY", true, "Navolato", "El Ayale", 0, "" },
                    { 6, "LP", true, "Navolato", "La piedra", 0, "" }
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "IdRol", "EstaActivo", "Nombre" },
                values: new object[] { 1, true, "Administrador" });

            migrationBuilder.InsertData(
                table: "Tamaño",
                columns: new[] { "IdTamaño", "EstaActivo", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "SMALL" },
                    { 2, true, "MEDIUM" },
                    { 3, true, "LARGE" },
                    { 4, true, "." },
                    { 5, true, "LARGE AND MEDIUM" }
                });

            migrationBuilder.InsertData(
                table: "Temporada",
                columns: new[] { "IdTemporada", "Descripcion", "EstaActivo", "FechaFinal", "FechaInicio" },
                values: new object[,]
                {
                    { 1, "2020-2021", true, new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "2021-2022", true, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "20202-2023", true, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "2023-2024", true, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "IdUsuario", "Correo", "EstaActivo", "Nombre", "Password", "UserName" },
                values: new object[] { 1, "", true, "Administrador", "10368.Z8huy4vYawZmWw5icpzOvw==.J3z5oZJporOFuTMBgSyPNZV2HUSmoBeokQwy1oCXa+U=", "Admin" });

            migrationBuilder.InsertData(
                table: "Choferes",
                columns: new[] { "IdChofer", "EstaActivo", "IdLineaTransporte", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, true, 1, "Javier Gaxiola Lopez", "" },
                    { 2, true, 1, "Juan Pablo Sanchez Santiesteban", "." },
                    { 3, true, 1, "ARNULFO MEDINA BAEZ", "" },
                    { 4, true, 1, "EDUARDO DUARTE VILLALOBOS", "6371117331" },
                    { 5, true, 1, "JORGE ALONSO CAMACHO GARCIA", "6727238388" },
                    { 6, true, 1, "JUAN CARLOS QUINTERO OLIVAS", "6672150856" },
                    { 7, true, 1, "JOEL FIGUEROA LOPEZ", "6623152041" },
                    { 8, true, 1, "Juan Carlos Sanchez Siqueiros", "" },
                    { 9, true, 2, "JULIAN RODOLFO ALVARADO LUQUE", "" },
                    { 10, true, 2, "ALEXIS IRIARTE FELIX", "" },
                    { 11, true, 2, "JAIRO MOISES VALENZUELA LEON", "" },
                    { 12, true, 2, "CAMARGO CONTRERAS MARTIN ALFREDO", "" },
                    { 13, true, 2, "FREDY GUERRERO GAMEZ", "" },
                    { 14, true, 2, "ROBERTO CARLOS MIRANDA GARCIA", "" },
                    { 15, true, 2, "ENRIQUE LEON MACIAS", "" },
                    { 16, true, 2, "CASTILLO LOPEZ LUIS ALBERTO", "" },
                    { 17, true, 2, "MIGUEL ANGEL MARTINEZ CORDOVA", "" },
                    { 18, true, 2, "ALFREDO CAZARES GASTELUM", "" },
                    { 19, true, 2, "HERNANDEZ QUIJANO SEVERIANO", "" },
                    { 20, true, 2, "JESUS ANTONIO GARFIO BENITEZ", "" },
                    { 21, true, 2, "SAUL URETA GARCIA", "" },
                    { 22, true, 2, "RAMIRO PERAZA PARDO", "" },
                    { 23, true, 2, "CUAHUTEMOC MIJAIL ALDANA PAYAN", "" },
                    { 24, true, 2, "NAZARIO RAMON BERRELLEZA CARMONA", "" },
                    { 25, true, 2, "GILDARDO NAVARRETE ONTIVEROS", "" },
                    { 26, true, 2, "GERARDO LOPEZ ROSARIO", "" },
                    { 27, true, 2, "HIPOLITO CORRALES VAZQUEZ", "" },
                    { 28, true, 2, "ALBERTO BURGOS AGUILAR", "" },
                    { 29, true, 2, "JOSE GUADALUPE CALDERON RODELO", "" },
                    { 30, true, 2, "OSCAR MONTOYA", "" },
                    { 31, true, 2, "RAFAEL IRIARTE URIARTE", "" },
                    { 32, true, 2, "EZEQUIEL CECEÑA BOJORQUEZ", "" },
                    { 33, true, 2, "JORGE VALENTIN GARCIA MONTES", "" },
                    { 34, true, 2, "JESUS BENJAMIN LEON CEBREROS", "" },
                    { 35, true, 1, "LUIS DONATO LEAL ALVAREZ", "6441737642" },
                    { 36, true, 2, "JOSE ALDRING BENITEZ REYES", "" },
                    { 37, true, 2, "JOEL ENRIQUE PARRA CASTRO", "" },
                    { 38, true, 2, "ROSENDO TORRES PEREZ", "" },
                    { 39, true, 2, "DAGOBERTO URIAS HERRERA", "" },
                    { 40, true, 2, "JESUS COTA VALENZUELA", "" },
                    { 41, true, 2, "EDEL ALBERTO CECEÑA ALCANTAR", "" },
                    { 42, true, 2, "MARIO ALBERTO NARVAEZ ALVAREZ", "" }
                });

            migrationBuilder.InsertData(
                table: "Choferes",
                columns: new[] { "IdChofer", "EstaActivo", "IdLineaTransporte", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 43, true, 2, "JOSE LUIS LOZOYA FLORES", "" },
                    { 44, true, 2, "FELICIANO CHAPARRO PEÑA", "" },
                    { 45, true, 2, "VICTOR HUGO HERRERA GUTIERREZ", "" },
                    { 46, true, 2, "JUAN CARLOS JUAREZ CRUZ", "" },
                    { 47, true, 2, "Jaime Garcia Monterrubio", "" },
                    { 48, true, 2, "JESUS ALONSO GASTELUM ROCHA", "" },
                    { 49, true, 1, "JESUS SANCHEZ VERDUGO", "" },
                    { 50, true, 1, "ERNESTO CAYETANO IBARRA FRAYRE", "SIN0112161" },
                    { 51, true, 2, "LUIS ENRIQUE MORAILA LLAMAS", "" },
                    { 52, true, 2, "Jorge Aurelio Hernadez Valadez", "" },
                    { 53, true, 2, "RICARDO JIMENEZ CHAVEZ", "" },
                    { 54, true, 2, "RAMON ERENESTO CARRAZCO HERRERA", "" },
                    { 55, true, 2, "SERGIO BALTAZAR SANCHEZ", "" },
                    { 56, true, 2, "JESUS MARTIN GARCIA VALENZUELA", "" },
                    { 57, true, 2, "JOSE RAMON GONZALEZ VALDIVIA", "" },
                    { 58, true, 3, "JESUS MARTIN AGUILAR DOMINGUEZ", "" },
                    { 59, true, 2, "ROBERTO URIAS GUTIERREZ", "" },
                    { 60, true, 2, "JOSE RAMON COTA FIGUEROA", "" },
                    { 61, true, 2, "OSCAR DAVID CHAVEZ CALDERON", "6873664401" },
                    { 62, true, 2, "RODOLFO JOAQUIN URREA CARLOS", "6311732494" },
                    { 63, true, 2, "JESUS ERNESTO SANCHEZ LOPEZ", "" },
                    { 64, true, 2, "ARIEL ORLANDO RAMOS CARDENAS", "6674132749" },
                    { 65, true, 2, "SANCHEZ CRUZ JUAN CARLOS", "" },
                    { 66, true, 2, "OSCAR ANTONIO CHAVEZ LOPEZ", "" },
                    { 67, true, 2, "VICTOR MANUEL ACOSTA APODACA", "" },
                    { 68, true, 2, "AMILCAR INZUNZA ESCALANTE", "" },
                    { 69, true, 2, "HUGO OMAR RAMIREZ GALAVIZ", "" },
                    { 70, true, 2, "JOSE ALFREDO MEDALLO QUINTANA", "" },
                    { 71, true, 2, "IVAN FLORES AHUMADA", "6674021236" },
                    { 72, true, 2, "FAUSTO JAVIER VALDES URIAS", "" },
                    { 73, true, 2, "FORTINO VALENZUELA GARDEA", "" },
                    { 74, true, 1, "LUIS ADOLFO SANCHEZ GUTIERREZ", "" },
                    { 75, true, 1, "ADRIAN BARRAZA ROBLEDO", "" },
                    { 76, true, 1, "LUIS ADOLFO SANCHEZ", "" },
                    { 77, true, 1, "LUIS ARMANDO ARENAS CAZAREZ", "6674821990" },
                    { 78, true, 1, "FELIPE MALVERDE", "4152150972" },
                    { 79, true, 3, "CRISANTO MEDINA MEDINA", "" },
                    { 80, true, 1, "JOSE JAVIER LEYVA", "" },
                    { 81, true, 3, "LUIS SALAZAR LOPEZ", "6672075957" },
                    { 82, true, 1, "NOEL SANCHEZ COSIO", "6131070727" },
                    { 83, true, 3, "SERGIO ABEL URETA MERCADO", "6721206111" },
                    { 84, true, 3, "JUAN DE DIOS SANCHEZ IBARRA", "6673179967" }
                });

            migrationBuilder.InsertData(
                table: "Choferes",
                columns: new[] { "IdChofer", "EstaActivo", "IdLineaTransporte", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 85, true, 3, "JUAN CARLOS CASTAÑO HERNANDEZ", "6671623622" },
                    { 86, true, 3, "CRISTINO LOPEZ DEL REAL", "6675138076" },
                    { 87, true, 1, "JESUS NAVITIVAD MORALES QUEVEDO", "4442003435" },
                    { 88, true, 1, "AXEL SANCHEZ IBARRA", "" },
                    { 89, true, 1, "HUGO GASTELUM QUIÑONEZ CARRO", "" },
                    { 90, true, 1, "JESUS IVAN ANGULO VALDEZ", "" },
                    { 91, true, 3, "JUAN CARLOS CASTAÑOS HERNANDEZ", "" },
                    { 92, true, 3, "ARTURO ATIENZO", "" },
                    { 93, true, 1, "ALFONSO FIERRO ARCE", "" },
                    { 94, true, 3, "AGAPITO CERVANTES", "" },
                    { 95, true, 3, "OSWALDO CARDENAS BRIGAN", "" },
                    { 96, true, 3, "LUIS MIGUEL CASTRO BELTRAN", "" },
                    { 97, true, 3, "Jose Alfredo RuiZ Lopez", "" },
                    { 98, true, 3, "JORGE FRANCO", "" },
                    { 99, true, 1, "CESAR ERNESTO GONZALES CASILLAS", "" }
                });

            migrationBuilder.InsertData(
                table: "Cultivo",
                columns: new[] { "IdCultivo", "EstaActivo", "IdFamiliaCultivo", "Nombre" },
                values: new object[,]
                {
                    { 1, true, 1, "BERENJENA CHINA" },
                    { 2, true, 1, "BERENJENA INDU" },
                    { 3, true, 1, "BERENJENA FILIPINA" },
                    { 4, true, 2, "BITTERMELON CHINO" },
                    { 5, true, 2, "BITTERMELON INDU" },
                    { 6, true, 3, "LONG BEAN" },
                    { 7, true, 4, "THAI CHILE" },
                    { 8, true, 5, "OPO" },
                    { 9, true, 6, "SINGUA" },
                    { 10, true, 4, "BELL PEPPER" },
                    { 11, true, 7, "Calabaza kabocha" },
                    { 12, true, 1, "BERENJENA THAY" },
                    { 13, true, 8, "MOQUA" },
                    { 14, true, 1, "Malla espuma" },
                    { 15, true, 3, "GREEN BEANS" }
                });

            migrationBuilder.InsertData(
                table: "Remolque",
                columns: new[] { "IdRemolque", "Año", "Descripcion", "EstaActivo", "IdLineaTransporte", "Placas" },
                values: new object[,]
                {
                    { 1, 2006, "JP09 512WS5", true, 1, "512WS5" },
                    { 2, 1996, "JP05   25-UA-6C", true, 1, "25UA6C" },
                    { 3, 1998, "JP08   974WS5", true, 1, "974WS5" },
                    { 4, 1996, "JP01 28UE5G", true, 1, "28UE5G" },
                    { 5, 2000, "JP04 266 WB 2", true, 1, "266 WB 2" },
                    { 6, 2000, "JP10-088-UB-5", true, 1, "088-UB-5" },
                    { 7, 2000, "JP06 12UA6C", true, 1, "12UA6C" },
                    { 8, 2017, "MH-1386", true, 2, "46UA9Y" },
                    { 9, 2016, "MH-1215", true, 2, "B644920" },
                    { 10, 2018, "MH 1423", true, 2, "B818074" },
                    { 11, 2017, "MH-1269", true, 2, "64UA8F" },
                    { 12, 2020, "MH-1620", true, 2, "50UJ6L" }
                });

            migrationBuilder.InsertData(
                table: "Remolque",
                columns: new[] { "IdRemolque", "Año", "Descripcion", "EstaActivo", "IdLineaTransporte", "Placas" },
                values: new object[,]
                {
                    { 13, 2014, "MH-1109", true, 2, "C180627" },
                    { 14, 2021, "MH-1607", true, 2, "54UF1M" },
                    { 15, 2017, "MH-1288", true, 2, "15TZ2V" },
                    { 16, 2017, "MH-1264", true, 2, "68UA8F" },
                    { 17, 2022, "MH-1665", true, 2, "C156922" },
                    { 18, 2016, "MH-1192", true, 2, "    163XA3" },
                    { 19, 2020, "MH-1637", true, 2, "60UJ6L" },
                    { 20, 2021, "MH-1600", true, 2, "47UF1M" },
                    { 21, 2017, "MH-1299", true, 2, " 685WM7" },
                    { 22, 2020, "MH-1613", true, 2, "53UJ6L" },
                    { 23, 2017, "MH-1302", true, 2, "31UA7D" },
                    { 24, 2018, "MH-1422", true, 2, "B818073" },
                    { 25, 2013, "MH-983", true, 2, "B435730" },
                    { 26, 2016, "MH-1214", true, 2, "B644919" },
                    { 27, 2018, "MH1453", true, 2, "2087864" },
                    { 28, 2016, "MH-1205", true, 2, "B644910" },
                    { 29, 2016, "MH-1219", true, 2, "B644924" },
                    { 30, 2016, "MH-1100", true, 2, "C180618" },
                    { 31, 2022, "MH-1659", true, 2, "C156916" },
                    { 32, 2013, "MH-947", true, 2, "B385294" },
                    { 33, 2015, "MH-1098", true, 2, "C180616" },
                    { 34, 2022, "MH-1681", true, 2, "C203923" },
                    { 35, 2020, "MH-1388", true, 2, "B766219" },
                    { 36, 2018, "MH-1411", true, 2, "B818062" },
                    { 37, 2017, "MH-1235", true, 2, "B663539" },
                    { 38, 2015, "JP-13", true, 1, "73UK9M" },
                    { 39, 2021, "MH-1605", true, 2, "B998688" },
                    { 40, 2021, "MH-1602", true, 2, "B998685" },
                    { 41, 2017, "MH-1252", true, 2, "B663556" },
                    { 42, 2022, "MH-1666", true, 2, "C156923" },
                    { 43, 2017, "MH-1387", true, 2, "60UA9Y" },
                    { 44, 2017, "MH-1231", true, 2, "B663535" },
                    { 45, 2017, "MH-1393", true, 2, "62UA2R" },
                    { 46, 2016, "MH-1199", true, 2, "B644904" },
                    { 47, 2020, "MH-1638", true, 2, "258464E" },
                    { 48, 2018, "MH-1432", true, 2, "B818083" },
                    { 49, 2018, "MH-1448", true, 2, "B818099" },
                    { 50, 2022, "MH-1689", true, 2, "C203931" },
                    { 51, 2022, "MH-1686", true, 2, "C203928" },
                    { 52, 2017, "MH-1382", true, 2, "B766216" },
                    { 53, 2018, "MH-1402", true, 2, "B818053" },
                    { 54, 2022, "MH-1710", true, 2, "C203952" }
                });

            migrationBuilder.InsertData(
                table: "Remolque",
                columns: new[] { "IdRemolque", "Año", "Descripcion", "EstaActivo", "IdLineaTransporte", "Placas" },
                values: new object[,]
                {
                    { 55, 2017, "MH-1260", true, 2, "B714870" },
                    { 56, 2021, "MH-1608", true, 2, "B998751" },
                    { 57, 2022, "JP06", true, 1, "12-UA6-C" },
                    { 58, 1999, "ZAR22", true, 1, "35UA3C" },
                    { 59, 2022, "MH-1698", true, 2, "C203940" },
                    { 60, 2020, "MH-1644", true, 2, "25-8466E" },
                    { 61, 2022, "MH-1670", true, 2, "C156927" },
                    { 62, 2015, "MH-1080", true, 2, "B575308" },
                    { 63, 2018, "MH-1437", true, 2, "B818088" },
                    { 64, 2015, "MH-1071", true, 2, "B571160" },
                    { 65, 2020, "MH-1621", true, 2, "49UJ6L" },
                    { 66, 2015, "MH-1073", true, 2, "B575303" },
                    { 67, 2022, "MH-1674", true, 2, "C156931" },
                    { 68, 2018, "MH-1445", true, 2, "B818096" },
                    { 69, 2015, "EP-12", true, 3, "86UE7Z" },
                    { 70, 2016, "MH-1190", true, 2, "35TX2S" },
                    { 71, 2022, "MH-1706", true, 2, "C203948" },
                    { 72, 2018, "MH-1403", true, 2, "B818054" },
                    { 73, 2016, "MH-1218", true, 2, "B644923" },
                    { 74, 2008, "MH-1037", true, 2, "B647230" },
                    { 75, 2017, "MH-1301", true, 2, "B743152" },
                    { 76, 2018, "MH-1447", true, 2, "B818098" },
                    { 77, 2017, "MH-1278", true, 2, "B714888" },
                    { 78, 2012, "REASA-61", true, 2, "671WS5" },
                    { 79, 2023, "MH-1732", true, 2, "C234384" },
                    { 80, 2018, "MH-1433", true, 2, "B818084" },
                    { 81, 2018, "MH-1405", true, 2, "B818056" },
                    { 82, 2018, "MH-1406", true, 2, "B818057" },
                    { 83, 2021, "MH-1606", true, 2, "C183926" },
                    { 84, 2018, "MH-1435", true, 2, "B818086" },
                    { 85, 2023, "MH-1740", true, 2, "C234392" },
                    { 86, 2017, "MH-1238", true, 2, "B663542" },
                    { 87, 2022, "MH-1691", true, 2, "C203933" },
                    { 88, 2017, "MH-1399", true, 2, "B780651" },
                    { 89, 2022, "MH-1656", true, 2, "C156913" },
                    { 90, 2017, "MH-1305", true, 2, "B743156" },
                    { 91, 2020, "MH-1394", true, 2, "47UA9Y" },
                    { 92, 2020, "JCV-668", true, 2, "47AK6R" },
                    { 93, 2020, "MH-1622", true, 2, "25-8452E" },
                    { 94, 2020, "MH-1395", true, 2, "57UA9Y" },
                    { 95, 2020, "JP14", true, 1, "61UK7R" },
                    { 96, 2000, "EP23", true, 3, "747UK4" }
                });

            migrationBuilder.InsertData(
                table: "Remolque",
                columns: new[] { "IdRemolque", "Año", "Descripcion", "EstaActivo", "IdLineaTransporte", "Placas" },
                values: new object[,]
                {
                    { 97, 2000, "EP323", true, 3, "498WB1" },
                    { 98, 1984, "JP03", true, 1, "091-AP-8" },
                    { 99, 1995, "JP07", true, 1, "921WS5" },
                    { 100, 2015, "EP-19 50UE8T", true, 3, "50UE8T" },
                    { 101, 2005, "EP2 399WL5", true, 3, "399WL5" },
                    { 102, 2006, "EP302- 449WS5", true, 3, "449WS5" },
                    { 103, 2013, "EP20-813WL4", true, 3, "813WL4" },
                    { 104, 2000, "EP320-511WB1", true, 3, "511WB1" },
                    { 105, 2020, "EP06 30UA3C", true, 3, "30UA3C" },
                    { 106, 2020, "EP21-39-UE-8Z", true, 3, "39-UE-8Z" },
                    { 107, 2020, "SL01 -45UK9M", true, 1, "45UK9M" },
                    { 108, 2012, "70UA3C EP-16", true, 3, "70UA3C" },
                    { 109, 2020, "JG -21 43UA4C", true, 1, "43UA4C" },
                    { 110, 2000, "EP-03", true, 3, "20UP9R" },
                    { 111, 2000, "EP-01", true, 3, "29UA3C" },
                    { 112, 2020, "EP -13", true, 3, "21-UG-9K" },
                    { 113, 2000, "EP-10", true, 3, "69-UA-3C" },
                    { 114, 2000, "EP-7", true, 3, "748UK4" },
                    { 115, 2000, "EP-11", true, 3, "28-up-1s" }
                });

            migrationBuilder.InsertData(
                table: "RolUsuario",
                columns: new[] { "IdRolUsuario", "EstaActivo", "IdRol", "IdUsuario" },
                values: new object[] { 1, true, 1, 1 });

            migrationBuilder.InsertData(
                table: "Vehiculos",
                columns: new[] { "IdVehiculo", "Apodo", "Año", "Descripcion", "EstaActivo", "IdLineaTransporte", "Placas" },
                values: new object[,]
                {
                    { 1, "", 2000, "International Dorado", true, 1, "091AP8" },
                    { 2, "", 1996, "Freightliner Verde", true, 1, "951DV4" },
                    { 3, "", 2003, "Freightliner BLANCO", true, 1, "40AE4G" },
                    { 4, "", 2002, "International BLANCO----", true, 1, "680DV7" },
                    { 5, "", 2010, "International BLANCO NUEVO", true, 1, "70AM4X" },
                    { 6, "", 2016, "VOLVO BLANCO", true, 2, "79AD3A" },
                    { 7, "", 2015, "VOLVO BLANCO", true, 2, "332DV4" },
                    { 8, "", 2021, "KENWORTH BLANCO", true, 2, "44AR3G" },
                    { 9, "", 2020, "International BLANCO", true, 2, "48AK6R" },
                    { 10, "", 2020, "International BLANCO", true, 2, "19AK2C" },
                    { 11, "", 2018, "Freightliner CREMA", true, 2, "97AF4M" },
                    { 12, "", 2020, "International BLANCO", true, 2, "36AK6R" },
                    { 13, "", 2018, "Freightliner GRIS", true, 2, "37AF6M" },
                    { 14, "", 2015, "VOLVO BLANCO", true, 2, "66AA2N" },
                    { 15, "", 2021, "KENWORTH BLANCO", true, 2, "23AR3E" },
                    { 16, "", 2020, "International BLANCO", true, 2, "43AK6R" },
                    { 17, "", 2015, "Freightliner BLANCO", true, 2, "98AE3A" },
                    { 18, "", 2020, "International BLANCO", true, 2, "83AK1C" },
                    { 19, "", 2015, "VOLVO BLANCO", true, 2, "878EY6" },
                    { 20, "", 2021, "KENWORTH BLANCO", true, 2, "31AR3E" },
                    { 21, "", 2020, "International BLANCO", true, 2, "44AL6E" },
                    { 22, "", 2018, "Freightliner CREMA", true, 2, "72AR3G" }
                });

            migrationBuilder.InsertData(
                table: "Vehiculos",
                columns: new[] { "IdVehiculo", "Apodo", "Año", "Descripcion", "EstaActivo", "IdLineaTransporte", "Placas" },
                values: new object[,]
                {
                    { 23, "", 2020, "International BLANCO", true, 2, "80AK5R" },
                    { 24, "", 2020, "International BLANCO", true, 2, "31AK6R" },
                    { 25, "", 2020, "International BLANCO", true, 2, "44AK6R" },
                    { 26, "", 2021, "KENWORTH BLANCO", true, 2, "52AR3E" },
                    { 27, "", 2020, "International BLANCO", true, 2, "24AK2C" },
                    { 28, "", 2020, "International BLANCO", true, 2, "59AK5R" },
                    { 29, "", 2016, "VOLVO BLANCO", true, 2, "80AB9M" },
                    { 30, "", 2018, "Freightliner GRIS", true, 2, "84AG2K" },
                    { 31, "", 2021, "KENWORTH BLANCO", true, 2, "08AR3E" },
                    { 32, "", 2015, "Freightliner BLANCO", true, 2, "21AK6R" },
                    { 33, "", 2020, "International BLANCO", true, 2, "42AK6R" },
                    { 34, "", 2017, "Freightliner BLANCO", true, 2, "59AE4A" },
                    { 35, "", 2016, "VOLVO BLANCO", true, 2, "85AC9H" },
                    { 36, "", 2018, "Freightliner GRIS", true, 2, "83AG2K" },
                    { 37, "", 2016, "VOLVO BLANCO", true, 2, "81AB9M" },
                    { 38, "", 2015, "Freightliner BLANCO", true, 2, "839EY6" },
                    { 39, "", 2016, "International BLANCO", true, 2, "51AH6F" },
                    { 40, "", 2018, "Freightliner CREMA", true, 2, "90AR3E" },
                    { 41, "", 2020, "International BLANCO", true, 2, "39AK6R" },
                    { 42, "", 2020, "International BLANCO", true, 2, "55AK5R" },
                    { 43, "", 2015, "Freightliner BLANCO", true, 2, "818EY6" },
                    { 44, "", 2020, "International BLANCO", true, 2, "40AM2G" },
                    { 45, "", 2016, "VOLVO BLANCO", true, 2, "28AC1J" },
                    { 46, "", 2020, "International BLANCO", true, 2, "21AK2C" },
                    { 47, "", 1977, "KENWORTH ROJO", true, 1, "97IDV9" },
                    { 48, "", 1999, "KENWORTH BLANCO", true, 1, "297DV9" },
                    { 49, "", 2018, "Freightliner CREMA", true, 2, "87AF4M" },
                    { 50, "", 2016, "VOLVO BLANCO", true, 2, "90AB1N" },
                    { 51, "", 2015, "Freightliner BLANCO", true, 2, "826EY6" },
                    { 52, "", 2015, "Freightliner BLANCO", true, 2, "824EY6" },
                    { 53, "", 2016, "VOLVO BLANCO", true, 2, "33AC1J" },
                    { 54, "", 2019, "VOLVO BLANCO", true, 2, "99AH9N" },
                    { 55, "", 2012, "KENWORTH LILA", true, 3, "590DV9" },
                    { 56, "", 2021, "KENWORTH BLANCO", true, 2, "19AR3E" },
                    { 57, "", 2015, "VOLVO BLANCO", true, 2, "334DV4" },
                    { 58, "", 2020, "International BLANCO", true, 2, "22AK2C" },
                    { 59, "", 2020, "International BLANCO", true, 2, "45AK6R" },
                    { 60, "", 2016, "VOLVO BLANCO", true, 2, "98AB7K" },
                    { 61, "", 2021, "KENWORTH BLANCO", true, 2, "18AR3E" },
                    { 62, "", 2018, "Freightliner GRIS", true, 2, "88AG2K" },
                    { 63, "", 2021, "KENWORTH BLANCO", true, 2, "30AR3E" },
                    { 64, "", 2021, "KENWORTH BLANCO", true, 2, "11AR3E" }
                });

            migrationBuilder.InsertData(
                table: "Vehiculos",
                columns: new[] { "IdVehiculo", "Apodo", "Año", "Descripcion", "EstaActivo", "IdLineaTransporte", "Placas" },
                values: new object[,]
                {
                    { 65, "", 2016, "VOLVO BLANCO", true, 2, "63AR3E" },
                    { 66, "", 2018, "Freightliner GRIS", true, 2, "03AS7A" },
                    { 67, "", 2015, "VOLVO BLANCO", true, 2, "340DV4" },
                    { 68, "", 2020, "International BLANCO", true, 2, "54AK5R" },
                    { 69, "", 2020, "International BLANCO", true, 2, "35AK6R" },
                    { 70, "", 2023, "GENERICOS BLANC", true, 2, "C234380" },
                    { 71, "", 2011, "International NEGRO", true, 1, "12AS1W" },
                    { 72, "", 2001, "Freightliner BLANCO", true, 1, "19AE2G" },
                    { 73, "", 2020, "KENWORTH BLANCO", true, 3, "09AM3X" },
                    { 74, "", 1980, "KENWORTH AZUL", true, 1, "880AM9" },
                    { 75, "", 2007, "KENWORTH NEGRO", true, 3, "754DW1" },
                    { 76, "", 2019, "KENWORTH ROJO", true, 3, "31AJ9P" },
                    { 77, "", 2013, "KENWORTH AZUL", true, 3, "488AP8" },
                    { 78, "", 2016, "KENWORTH ANARANJADO", true, 3, "59AT8P" },
                    { 79, "", 2013, "KENWORTH VERDE", true, 3, "953DV9" },
                    { 80, "", 2012, "VOLVO BLANCO", true, 1, "64AT5R" },
                    { 81, "", 1972, "DINA AMARILLO", true, 1, "470DW1" },
                    { 82, "", 2020, "Freightliner ROJO", true, 1, "851AR2" },
                    { 83, "", 2008, "International LILA", true, 3, "73AM4X" },
                    { 84, "", 2010, "International BLANCO", true, 1, "81AT4R" },
                    { 85, "", 2000, "KENWORTH AMARILLO", true, 3, "28AC8H" },
                    { 86, "", 2020, "KENWORTH blanco", true, 3, "583DB8" },
                    { 87, "", 2018, "KENWORTH anaranjado", true, 3, "59-AT-8P" },
                    { 88, "", 2017, "KENWORTH ROJO", true, 3, "536DW2" },
                    { 89, "", 2010, "KENWORTH BLANCO", true, 3, "56AC711" },
                    { 90, "", 0, "KENWORTH BLANCO", true, 3, "20-AC-8H" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "IdProducto", "Calidad", "Cantidad", "Codigo", "CveFraccionArancelaria", "CveProductoServicio", "CveUnidadMedida", "EstaActivo", "FolioGuia", "IdCultivo", "IdEnvase", "IdTamaño", "Libras", "Nombre", "PesoKg" },
                values: new object[,]
                {
                    { 1, 0, 49, "M1L", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 3, 0.0, "BITTTERMELON CHINO LARGE", 13.608000000000001 },
                    { 2, 0, 49, "MPM", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 2, 0.0, "BITTER MELON CHINO MEDIUM", 13.608000000000001 },
                    { 3, 0, 49, "M2L", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 1, 0.0, "BITTERMELON CHINO small", 13.608000000000001 },
                    { 4, 0, 49, "MSM", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 2, 0.0, "BITTERMELON CHINO 2cc MEDIUM", 13.608000000000001 },
                    { 5, 0, 49, "I1L", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 3, 0.0, "BITTERMELON CHINO 2cc LARGE", 13.608000000000001 },
                    { 6, 0, 56, "I1M", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 2, 0.0, "BITTER MELON CHINO 2CC MEDIUM", 13.608000000000001 },
                    { 7, 0, 40, "I2L", "0807199901", "50304600", "XBX", true, "186010", 4, 2, 3, 0.0, "BITTER MELON CHINO LARGE 2CP", 13.608000000000001 },
                    { 8, 0, 40, "I2M", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 2, 0.0, "BITTER MELON CHINO MEDIUM 2CP", 13.608000000000001 },
                    { 9, 0, 40, "OPS", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 1, 0.0, "BITTER MELON CHINO 2CP SMALL", 13.608000000000001 },
                    { 10, 0, 49, "OPM", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 2, 0.0, "BITTER MELON CHINO SMALL 2CC", 13.608000000000001 },
                    { 11, 0, 40, "OPL", "0807199901", "50304600", "XBX", true, "186010", 4, 2, 2, 0.0, "BITTERMELON CHINO MEDIUM 2CP", 13.608000000000001 },
                    { 12, 0, 40, "OSS", "0807199901", "50304600", "XBX", true, "186010", 4, 2, 3, 0.0, "BITTERMELON CHINO LARGE 2CP", 13.608000000000001 },
                    { 13, 0, 49, "OSM", "0709999999", "50407047", "XBX", true, "186012", 8, 1, 2, 0.0, "OPO  MEDIUM  ", 13.608000000000001 },
                    { 14, 0, 49, "OSL", "0709999999", "50407047", "XBX", true, "186012", 8, 1, 1, 0.0, "OPO SMALL", 13.608000000000001 },
                    { 15, 0, 49, "BI1", "0709999999", "50407047", "XBX", true, "186012", 8, 1, 2, 0.0, "OPO MEDIUM 2CC", 13.608000000000001 },
                    { 16, 0, 49, "CPL", "0709300100", "50403500", "XBX", true, "186037", 1, 1, 3, 0.0, "BERENJENA CHINA LARGE", 13.608000000000001 },
                    { 17, 0, 49, "CPM", "0709300100", "50403500", "XBX", true, "186037", 1, 1, 2, 0.0, "BERENJENA CHINA  MEDIUM", 13.608000000000001 },
                    { 18, 0, 49, "C2L", "0709300100", "50403500", "XBX", true, "186037", 1, 1, 3, 0.0, "BERENJENA CHINA 2 LARGE", 13.608000000000001 },
                    { 19, 0, 49, "CSM", "0709300100", "50403500", "XBX", true, "186037", 1, 1, 2, 0.0, "BERENJENA CHINA 1 -1/2 MEDIUM", 13.608000000000001 },
                    { 20, 0, 49, "FPL", "0709300100", "50403500", "XBX", true, "186037", 3, 1, 3, 0.0, "BERENJENA FILIPINA LARGE", 13.608000000000001 },
                    { 21, 0, 49, "FPM", "0709300100", "50403500", "XBX", true, "186037", 3, 1, 2, 0.0, "BERENJENA FILIPINA MEDIUM", 13.608000000000001 },
                    { 22, 0, 49, "FSL", "0709300100", "50403500", "XBX", true, "186037", 3, 1, 3, 0.0, "BERENJENA FILIPINA 2 LARGE", 13.608000000000001 },
                    { 23, 0, 49, "FSM", "0709300100", "50403500", "XBX", true, "186037", 3, 1, 2, 0.0, "BERENJENA FILIPINA 2 MEDIUM", 13.608000000000001 },
                    { 24, 0, 40, "LOB", "0708200100", "50401847", "XBX", true, "186013", 6, 2, 4, 0.0, "LONG BEAN", 13.608000000000001 },
                    { 25, 0, 40, "SPL", "0709999999", "50403901", "XBX", true, "186011", 9, 2, 3, 0.0, "SINGUA  LARGE", 13.608000000000001 },
                    { 26, 0, 40, "SPM", "0709999999", "50403901", "XBX", true, "186011", 9, 2, 2, 0.0, "SINGUA MEDIUM ", 13.608000000000001 },
                    { 27, 0, 49, "CTV", "0709609999", "50405634", "XBX", true, "186000", 7, 1, 4, 0.0, "CHILE THAI VERDE", 13.608000000000001 },
                    { 28, 0, 49, "CTR", "0709609999", "50405634", "XBX", true, "186000", 7, 1, 4, 0.0, "CHILE THAI ROJO", 13.608000000000001 },
                    { 29, 0, 40, "SPP", "0709999999", "50403901", "XBX", true, "186011", 9, 2, 3, 0.0, "SINGUA  SEGUNDA LARGE CP", 13.608000000000001 },
                    { 30, 0, 49, "SPC", "0709999999", "50403901", "XBX", true, "186011", 9, 1, 2, 0.0, "SINGUA SEGUNDA LARGE CC49", 13.608000000000001 },
                    { 31, 0, 56, "LBP", "0708200100", "50401847", "XBX", true, "186013", 6, 2, 4, 0.0, "LONG BEAN PLASTICO", 13.608000000000001 },
                    { 32, 0, 49, "SMC", "0709999999", "50403901", "XBX", true, "186011", 9, 1, 2, 0.0, "SINGUA PRIMERA MEDIUM CC", 13.608000000000001 },
                    { 33, 0, 40, "ICP", "0807199999", "50304600", "XBX", true, "186010", 5, 2, 4, 0.0, "BITTER MELON INDU CP 40 ", 13.608000000000001 },
                    { 35, 0, 56, "BIC", "0807199999", "50304600", "XBX", true, "186010", 5, 2, 4, 0.0, "BITTER MELON INDU CP", 13.608000000000001 },
                    { 36, 0, 49, "SMP", "0709999999", "50403901", "XBX", true, "186011", 9, 1, 3, 0.0, "SINGUA large", 13.608000000000001 },
                    { 37, 0, 49, "BCP", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 1, 0.0, "BITTERMELON CHINO YOUNG SMALL", 13.608000000000001 },
                    { 38, 0, 56, "BCM", "0709300100", "50403500", "XBX", true, "186037", 1, 2, 2, 0.0, "BERENJENA CHINA CP SEGUNDA MEDIUM", 13.608000000000001 },
                    { 39, 0, 40, "BM2", "0807199901", "50304600", "XBX", true, "186010", 4, 2, 4, 0.0, "BITTER MELON CHINO SEGUNDA MEDIUM CP", 13.608000000000001 },
                    { 40, 0, 40, "BIP", "0709300100", "50403500", "XBX", true, "186037", 2, 2, 4, 0.0, "BERENJENA INDU CP 40", 13.608000000000001 },
                    { 41, 0, 49, "KCC", "0709930101", "50406714", "XBX", true, "024003", 11, 1, 3, 0.0, "KABOCHA LARGE CC ", 13.608000000000001 },
                    { 42, 0, 49, "KCM", "0709930101", "50406714", "XBX", true, "024003", 11, 1, 2, 0.0, "KABOCHA MEDIUM C", 13.608000000000001 },
                    { 43, 0, 56, "B2P", "0807199901", "50304600", "XBX", true, "186010", 4, 2, 2, 0.0, "BITTERMELON CHINO MEDIANO SEGUNDA CP 56", 13.608000000000001 }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "IdProducto", "Calidad", "Cantidad", "Codigo", "CveFraccionArancelaria", "CveProductoServicio", "CveUnidadMedida", "EstaActivo", "FolioGuia", "IdCultivo", "IdEnvase", "IdTamaño", "Libras", "Nombre", "PesoKg" },
                values: new object[,]
                {
                    { 44, 0, 49, "MCP", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 1, 0.0, "BITTERMELON CHINO YOUNG 2 SMALL", 13.608000000000001 },
                    { 45, 0, 49, "LCP", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 2, 0.0, "BITTERMELON CHINO YOUNG 2 MEDIUM", 13.608000000000001 },
                    { 46, 0, 49, "FLC", "0709300100", "50403500", "XBX", true, "186037", 3, 1, 1, 0.0, "BERENJENA FILIPINA small", 13.608000000000001 },
                    { 47, 0, 56, "FCP", "0709300100", "50403500", "XBX", true, "186037", 3, 2, 2, 0.0, "BERENJENA FILIPINA M CP", 13.608000000000001 },
                    { 48, 0, 49, "CCP", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 3, 0.0, "BITTERMELON CHINO segunda L", 13.608000000000001 },
                    { 49, 0, 49, "BMC", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 2, 0.0, "BITTER MELON CHINO 2 MEDIUM", 13.608000000000001 },
                    { 50, 0, 49, "BCS", "0709300100", "50403500", "XBX", true, "186037", 1, 1, 1, 0.0, "BERENJENA CHINA 2 SMALL ", 13.608000000000001 },
                    { 51, 0, 40, "BSP", "0709300100", "50403500", "XBX", true, "186037", 1, 2, 1, 0.0, "BERENJENA CHINA SMALL CP", 13.608000000000001 },
                    { 52, 0, 49, "OCP", "0709999999", "50407047", "XBX", true, "186012", 8, 1, 1, 0.0, "OPO SMALL 2CC", 13.608000000000001 },
                    { 53, 0, 49, "OMC", "0709999999", "50407047", "XBX", true, "186012", 8, 1, 3, 0.0, "OPO LARGE 2CC", 13.608000000000001 },
                    { 54, 0, 35, "OLP", "0709999999", "50407047", "XBX", true, "186012", 8, 2, 3, 0.0, "OPO LARGE CP", 13.608000000000001 },
                    { 55, 0, 40, "SSP", "0709999999", "50407047", "XBX", true, "186012", 8, 2, 1, 0.0, "OPO SEGUNDA SMALL CP", 13.608000000000001 },
                    { 56, 0, 49, "OMP", "0709999999", "50407047", "XBX", true, "186012", 8, 1, 3, 0.0, "OPO LARGE CC ", 13.608000000000001 },
                    { 57, 0, 35, "SLP", "0709999999", "50407047", "XBX", true, "186012", 8, 2, 3, 0.0, "OPO SEGUNDA LARGE CP", 13.608000000000001 },
                    { 58, 0, 56, "CHI", "0807199901", "50304600", "XBX", true, "186010", 4, 2, 2, 0.0, "BITTER MELON CHINO MEDIUM CP", 13.608000000000001 },
                    { 59, 0, 56, "C56", "0807199901", "50304600", "XBX", true, "186010", 4, 2, 3, 0.0, "BITTER MELON CHINO LARGE CP", 13.608000000000001 },
                    { 60, 0, 49, "BTA", "0709300100", "50403500", "XBX", true, "186037", 12, 1, 4, 0.0, "BERENJENA THAY", 13.608000000000001 },
                    { 61, 0, 49, "ICC", "0709300100", "50403500", "XBX", true, "186037", 2, 1, 4, 0.0, "BERENJENA INDU CC", 13.608000000000001 },
                    { 62, 0, 49, "BCF", "0709300100", "50403500", "XBX", true, "186037", 1, 1, 2, 0.0, "BERENJENA CHINA M FCO", 13.608000000000001 },
                    { 63, 0, 49, "FCO", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 3, 0.0, "BITTERMELON CHINO YOUNG 2 LARGE", 13.608000000000001 },
                    { 64, 0, 49, "CFC", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 3, 0.0, "BITTERMELON CHINO YOUNG LARGE", 13.608000000000001 },
                    { 65, 0, 49, "Bmf", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 2, 0.0, "BITTERMELON CHINO YOUNG MEDIUM", 13.608000000000001 },
                    { 66, 0, 49, "FIL", "0709300100", "50403500", "XBX", true, "186037", 3, 1, 3, 0.0, "BERENJENA FILIPINA L FCO", 13.608000000000001 },
                    { 67, 0, 49, "KSM", "0709930101", "50406714", "XBX", true, "024003", 11, 1, 1, 0.0, "KABOCHA SMALL ", 13.608000000000001 },
                    { 68, 0, 49, "KAB", "0709930101", "50406714", "XBX", true, "024003", 11, 1, 1, 0.0, "KABOCHA SMALL A", 13.608000000000001 },
                    { 69, 0, 49, "KAL", "0709930101", "50406714", "XBX", true, "024003", 11, 1, 2, 0.0, "KABOCHA LARGE A", 13.608000000000001 },
                    { 70, 0, 49, "KAM", "0709930101", "50406714", "XBX", true, "024003", 11, 1, 2, 0.0, "KABOCHA MEDIUM A", 13.608000000000001 },
                    { 71, 0, 49, "FUZ", "0709930199", "50403900", "XBX", true, "125019", 13, 1, 2, 0.0, "MOQUA (FUZZY SQUASH) MEDIUM", 13.608000000000001 },
                    { 72, 0, 49, "FUQ", "0709930199", "50403900", "XBX", true, "125019", 13, 1, 1, 0.0, "MOQUA (FUZZY SQUASH) SMALL", 13.608000000000001 },
                    { 73, 0, 49, "QUA", "0709930199", "50403900", "XBX", true, "125019", 13, 1, 2, 0.0, " MOQUA (FUZZY SQUASH) 2 MEDIUM", 13.608000000000001 },
                    { 74, 0, 49, "ASH", "0709930199", "50403900", "XBX", true, "125019", 13, 1, 1, 0.0, "MOQUA (FUZZY SQUASH) 2 SMALL", 13.608000000000001 },
                    { 75, 0, 49, "ZZY", "0709930199", "50403900", "XBX", true, "125019", 13, 1, 3, 0.0, " MOQUA (FUZZY SQUASH) 2 LARGE", 13.608000000000001 },
                    { 76, 0, 30, "mll", "3923909900", "80141701", "XEC", true, "000000", 14, 3, 4, 0.0, "Malla de espuma", 2.5 },
                    { 77, 0, 40, "3BM", "0807199901", "50304600", "XBX", true, "186010", 4, 2, 2, 0.0, "BITTERMELON CHINO 3-MEDIUM", 13.608000000000001 },
                    { 78, 0, 49, "2BM", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 1, 0.0, "BITTERMELON CHINO 2 SMALL", 13.608000000000001 },
                    { 79, 0, 40, "2SM", "0709999999", "50403901", "XBX", true, "186011", 9, 2, 2, 0.0, "SINGUA SEGUNDA MEDIUM CP", 13.608000000000001 },
                    { 80, 0, 49, "LYM", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 5, 0.0, "BITTER MELON CHINO LAR/MED ", 13.608000000000001 },
                    { 81, 0, 49, "SMA", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 1, 0.0, "BITTER MELON CHINO SMALL 1 1/2", 13.608000000000001 },
                    { 82, 0, 49, "SIN", "0709999999", "50403901", "XBX", true, "186011", 9, 1, 1, 0.0, "SINQUA SMALL CC", 13.608000000000001 },
                    { 83, 0, 49, "1/1", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 5, 0.0, "BITTER MELON CHINO LAR/MED 1-1/2", 13.608000000000001 },
                    { 84, 0, 40, "HDS", "0807199901", "50304600", "XBX", true, "186010", 4, 2, 1, 0.0, "BITTERMELON CHINO CP 2SMALL", 13.608000000000001 },
                    { 85, 0, 49, "FLA", "0709930199", "50403900", "XBX", true, "125019", 13, 1, 3, 0.0, "MOQUA (FUZZY SQUASH) LARGE", 13.608000000000001 }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "IdProducto", "Calidad", "Cantidad", "Codigo", "CveFraccionArancelaria", "CveProductoServicio", "CveUnidadMedida", "EstaActivo", "FolioGuia", "IdCultivo", "IdEnvase", "IdTamaño", "Libras", "Nombre", "PesoKg" },
                values: new object[,]
                {
                    { 86, 0, 56, "GRE", "0708200100", "50401847", "XBX", true, "186013", 15, 2, 4, 0.0, "GREEN BEANS", 13.608000000000001 },
                    { 87, 0, 56, "GEN", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 2, 0.0, "BITTER CHINO GENERICO M", 13.608000000000001 },
                    { 88, 0, 49, "scd", "0709300100", "50403500", "XBX", true, "186037", 1, 1, 2, 0.0, "BERENJENA MEDIUM YOUNG", 13.608000000000001 },
                    { 89, 0, 49, "ZVD", "0709300100", "50403500", "XBX", true, "186037", 1, 1, 3, 0.0, "BERENJENA LARGE YOUNG", 13.608000000000001 },
                    { 90, 0, 49, "DFW", "0709300100", "50403500", "XBX", true, "186037", 1, 1, 2, 0.0, "BERENJENA 2M YOUNG", 13.608000000000001 },
                    { 91, 0, 49, "DFS", "0709300100", "50403500", "XBX", true, "186037", 1, 1, 3, 0.0, "BERENJENA 2L YOUNG", 13.608000000000001 },
                    { 92, 0, 49, "SDF", "0709999999", "50407047", "XBX", true, "186012", 8, 1, 3, 0.0, "OPO 2L EMP", 13.608000000000001 },
                    { 93, 0, 49, "DFA", "0709999999", "50407047", "XBX", true, "186012", 8, 1, 2, 0.0, "OPO 2M EMP", 13.608000000000001 },
                    { 94, 0, 49, "SDR", "0709999999", "50407047", "XBX", true, "186012", 8, 1, 1, 0.0, "OPO 2 SMALL EMP", 13.608000000000001 },
                    { 95, 0, 49, "DES", "0709999999", "50407047", "XBX", true, "186012", 8, 1, 1, 0.0, "OPO SMALL EMP", 13.608000000000001 },
                    { 96, 0, 49, "QWE", "0709999999", "50407047", "XBX", true, "186012", 8, 1, 2, 0.0, "OPO MEDIUM EMP", 13.608000000000001 },
                    { 97, 0, 49, "RTY", "0709999999", "50407047", "XBX", true, "186012", 8, 1, 3, 0.0, "OPO LARGE EMP", 13.608000000000001 },
                    { 98, 0, 49, "GDF", "0807199901", "50304600", "XBX", true, "186010", 4, 1, 1, 0.0, "BITTER MELON YOUNG  2SMALL ", 13.608000000000001 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcarreoCampo_IdCultivo",
                table: "AcarreoCampo",
                column: "IdCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_AcarreoCampo_IdLote",
                table: "AcarreoCampo",
                column: "IdLote");

            migrationBuilder.CreateIndex(
                name: "IX_Choferes_IdLineaTransporte",
                table: "Choferes",
                column: "IdLineaTransporte");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivo_IdFamiliaCultivo",
                table: "Cultivo",
                column: "IdFamiliaCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_Embarque_IdAgenciaAduana",
                table: "Embarque",
                column: "IdAgenciaAduana");

            migrationBuilder.CreateIndex(
                name: "IX_Embarque_IdBanco",
                table: "Embarque",
                column: "IdBanco");

            migrationBuilder.CreateIndex(
                name: "IX_Embarque_IdChofer",
                table: "Embarque",
                column: "IdChofer");

            migrationBuilder.CreateIndex(
                name: "IX_Embarque_IdCliente",
                table: "Embarque",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Embarque_IdDestino",
                table: "Embarque",
                column: "IdDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Embarque_IdRemolque",
                table: "Embarque",
                column: "IdRemolque");

            migrationBuilder.CreateIndex(
                name: "IX_Embarque_IdTemporada",
                table: "Embarque",
                column: "IdTemporada");

            migrationBuilder.CreateIndex(
                name: "IX_Embarque_IdUsuario",
                table: "Embarque",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Embarque_IdVehiculo",
                table: "Embarque",
                column: "IdVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_EmbarqueDetalle_IdEmbarque",
                table: "EmbarqueDetalle",
                column: "IdEmbarque");

            migrationBuilder.CreateIndex(
                name: "IX_EmbarqueDetalle_IdPalet",
                table: "EmbarqueDetalle",
                column: "IdPalet");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaDetalle_IdArticulo",
                table: "EntradaDetalle",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaDetalle_IdEntrada",
                table: "EntradaDetalle",
                column: "IdEntrada");

            migrationBuilder.CreateIndex(
                name: "IX_Palet_IdEmpaque",
                table: "Palet",
                column: "IdEmpaque");

            migrationBuilder.CreateIndex(
                name: "IX_Palet_IdTemporada",
                table: "Palet",
                column: "IdTemporada");

            migrationBuilder.CreateIndex(
                name: "IX_PaletDetalle_IdAgricultor",
                table: "PaletDetalle",
                column: "IdAgricultor");

            migrationBuilder.CreateIndex(
                name: "IX_PaletDetalle_IdLote",
                table: "PaletDetalle",
                column: "IdLote");

            migrationBuilder.CreateIndex(
                name: "IX_PaletDetalle_IdPalet",
                table: "PaletDetalle",
                column: "IdPalet");

            migrationBuilder.CreateIndex(
                name: "IX_PaletDetalle_IdProducto",
                table: "PaletDetalle",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCultivo",
                table: "Productos",
                column: "IdCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdEnvase",
                table: "Productos",
                column: "IdEnvase");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdTamaño",
                table: "Productos",
                column: "IdTamaño");

            migrationBuilder.CreateIndex(
                name: "IX_Remolque_IdLineaTransporte",
                table: "Remolque",
                column: "IdLineaTransporte");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_IdRol",
                table: "RolUsuario",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_IdUsuario",
                table: "RolUsuario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdLineaTransporte",
                table: "Vehiculos",
                column: "IdLineaTransporte");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcarreoCampo");

            migrationBuilder.DropTable(
                name: "ClaveCatastral");

            migrationBuilder.DropTable(
                name: "EmbarqueDetalle");

          

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "EntradaDetalle");

           

            migrationBuilder.DropTable(
                name: "PaletDetalle");

            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.DropTable(
                name: "TipoCambio");

            migrationBuilder.DropTable(
                name: "Embarque");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Entrada");

            migrationBuilder.DropTable(
                name: "Agricultor");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropTable(
                name: "Palet");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "AgenciaAduana");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "Choferes");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Destino");

            migrationBuilder.DropTable(
                name: "Remolque");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Empaque");

            migrationBuilder.DropTable(
                name: "Temporada");

            migrationBuilder.DropTable(
                name: "Cultivo");

            migrationBuilder.DropTable(
                name: "Envase");

            migrationBuilder.DropTable(
                name: "Tamaño");

            migrationBuilder.DropTable(
                name: "LineaTransporte");

            migrationBuilder.DropTable(
                name: "FamiliaCultivo");
        }
    }
}
