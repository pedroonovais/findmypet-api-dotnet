using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ADOCAO",
                columns: table => new
                {
                    idAdocao = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    idPessoa = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    idAnimal = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    dataAdocao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    tipoAdocao = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ADOCAO", x => x.idAdocao);
                });

            migrationBuilder.CreateTable(
                name: "TB_ANIMAL",
                columns: table => new
                {
                    idAnimal = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    nomeAnimal = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    especie = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    porte = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    idadeEstimada = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ANIMAL", x => x.idAnimal);
                });

            migrationBuilder.CreateTable(
                name: "TB_LOCAL",
                columns: table => new
                {
                    idLocal = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    tipoDesastre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dataOcorrencia = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LOCAL", x => x.idLocal);
                });

            migrationBuilder.CreateTable(
                name: "TB_PESSOA",
                columns: table => new
                {
                    idPessoa = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    nomePessoa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    tipoPessoa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PESSOA", x => x.idPessoa);
                });

            migrationBuilder.CreateTable(
                name: "TB_REPORT",
                columns: table => new
                {
                    idReport = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    idPessoa = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    idAnimal = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    idLocal = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    idSensor = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    dataReport = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    descricaoLocal = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    statusReport = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_REPORT", x => x.idReport);
                });

            migrationBuilder.CreateTable(
                name: "TB_SENSOR",
                columns: table => new
                {
                    idSensor = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    tipoSensor = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    latitude = table.Column<decimal>(type: "decimal(18,15)", nullable: false),
                    longitude = table.Column<decimal>(type: "decimal(18,15)", nullable: false),
                    ativo = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SENSOR", x => x.idSensor);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ADOCAO");

            migrationBuilder.DropTable(
                name: "TB_ANIMAL");

            migrationBuilder.DropTable(
                name: "TB_LOCAL");

            migrationBuilder.DropTable(
                name: "TB_PESSOA");

            migrationBuilder.DropTable(
                name: "TB_REPORT");

            migrationBuilder.DropTable(
                name: "TB_SENSOR");
        }
    }
}
