using Microsoft.EntityFrameworkCore.Migrations;

namespace MDF.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinhasProducao",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false),
                    descricao_Id = table.Column<string>(nullable: true),
                    posicaoAbsolutaLinhaProducao_x = table.Column<int>(nullable: false),
                    posicaoAbsolutaLinhaProducao_y = table.Column<int>(nullable: false),
                    orientacaoLinhaProducao_orientacao = table.Column<string>(nullable: true),
                    dimensaoLinhaProducao_comprimento = table.Column<int>(nullable: false),
                    dimensaoLinhaProducao_largura = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhasProducao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Operacoes",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false),
                    descricaoOperacao_Id = table.Column<string>(nullable: true),
                    duracaoOperacao_hora = table.Column<string>(nullable: true),
                    duracaoOperacao_min = table.Column<string>(nullable: true),
                    duracaoOperacao_seg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacoes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TiposMaquina",
                columns: table => new
                {
                    id_tipoMaquina = table.Column<long>(nullable: false),
                    descricaoTipoMaquina_Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMaquina", x => x.id_tipoMaquina);
                });

            migrationBuilder.CreateTable(
                name: "Maquinas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    nomeMaquina_nomeMaquina = table.Column<string>(nullable: true),
                    marcaMaquina_marca = table.Column<string>(nullable: true),
                    modeloMaquina_modelo = table.Column<string>(nullable: true),
                    posicaoLinhaProducao_x = table.Column<int>(nullable: false),
                    posicaoLinhaProducao_y = table.Column<int>(nullable: false),
                    posicaoRelativa_posicao = table.Column<int>(nullable: false),
                    id_tipoMaquina = table.Column<long>(nullable: false),
                    id_linhaProducao = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maquinas_LinhasProducao_id_linhaProducao",
                        column: x => x.id_linhaProducao,
                        principalTable: "LinhasProducao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maquinas_TiposMaquina_id_tipoMaquina",
                        column: x => x.id_tipoMaquina,
                        principalTable: "TiposMaquina",
                        principalColumn: "id_tipoMaquina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoMaquinaOperacao",
                columns: table => new
                {
                    id_tipoMaquina = table.Column<long>(nullable: false),
                    id_operacao = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMaquinaOperacao", x => new { x.id_operacao, x.id_tipoMaquina });
                    table.ForeignKey(
                        name: "FK_TipoMaquinaOperacao_Operacoes_id_operacao",
                        column: x => x.id_operacao,
                        principalTable: "Operacoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoMaquinaOperacao_TiposMaquina_id_tipoMaquina",
                        column: x => x.id_tipoMaquina,
                        principalTable: "TiposMaquina",
                        principalColumn: "id_tipoMaquina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maquinas_id_linhaProducao",
                table: "Maquinas",
                column: "id_linhaProducao");

            migrationBuilder.CreateIndex(
                name: "IX_Maquinas_id_tipoMaquina",
                table: "Maquinas",
                column: "id_tipoMaquina");

            migrationBuilder.CreateIndex(
                name: "IX_TipoMaquinaOperacao_id_tipoMaquina",
                table: "TipoMaquinaOperacao",
                column: "id_tipoMaquina");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maquinas");

            migrationBuilder.DropTable(
                name: "TipoMaquinaOperacao");

            migrationBuilder.DropTable(
                name: "LinhasProducao");

            migrationBuilder.DropTable(
                name: "Operacoes");

            migrationBuilder.DropTable(
                name: "TiposMaquina");
        }
    }
}
