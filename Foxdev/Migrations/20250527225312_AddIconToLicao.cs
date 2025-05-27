using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxdev.Migrations
{
    /// <inheritdoc />
    public partial class AddIconToLicao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "modulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modulo", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Avatar = table.Column<string>(type: "longtext", nullable: true),
                    Descricao = table.Column<string>(type: "longtext", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Licaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    Explicacao = table.Column<string>(type: "longtext", nullable: true),
                    Icon = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licaos_modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "perfil_regra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil_regra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_perfil_regra_perfil_RoleId",
                        column: x => x.RoleId,
                        principalTable: "perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario_login",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_login", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_usuario_login_usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario_perfil",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_perfil", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_usuario_perfil_perfil_RoleId",
                        column: x => x.RoleId,
                        principalTable: "perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuario_perfil_usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario_regra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_regra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_regra_usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario_token",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_token", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_usuario_token_usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Questaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Enunciado = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    RespostaA = table.Column<string>(type: "longtext", nullable: true),
                    RespostaB = table.Column<string>(type: "longtext", nullable: true),
                    RespostaC = table.Column<string>(type: "longtext", nullable: true),
                    RespostaD = table.Column<string>(type: "longtext", nullable: true),
                    RespostaCorreta = table.Column<string>(type: "longtext", nullable: true),
                    LicaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questaos_Licaos_LicaoId",
                        column: x => x.LicaoId,
                        principalTable: "Licaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "modulo",
                columns: new[] { "Id", "Titulo" },
                values: new object[,]
                {
                    { 1, "Lógica de Programação" },
                    { 2, "Introdução ao Frontend" },
                    { 3, "Introdução ao Backend" }
                });

            migrationBuilder.InsertData(
                table: "Licaos",
                columns: new[] { "Id", "Explicacao", "Icon", "ModuloId", "Titulo" },
                values: new object[,]
                {
                    { 1, "Nesta lição, você aprenderá sobre variáveis, que são espaços na memória do computador usados para armazenar dados. Variáveis são fundamentais na programação, pois permitem que os programas armazenem e manipulem informações. Você aprenderá como declarar variáveis, atribuir valores a elas e utilizá-las em operações básicas.", "fas fa-lightbulb", 1, "Introdução a Variáveis" },
                    { 2, "Esta lição aborda os diferentes tipos de dados que podem ser armazenados em variáveis, como números inteiros, números decimais, texto (strings) e valores booleanos (verdadeiro/falso). Compreender os tipos de dados é essencial para manipular informações corretamente em seus programas.", "fas fa-database", 1, "Tipos de Dados Básicos" },
                    { 3, "Nesta lição, você aprenderá sobre os operadores que permitem realizar cálculos matemáticos (como adição, subtração, multiplicação e divisão) e operações lógicas (como comparações de igualdade, maior que, menor que). Esses operadores são essenciais para criar programas que tomam decisões e processam dados.", "fas fa-calculator", 1, "Operadores Aritméticos e Lógicos" },
                    { 4, "As estruturas condicionais permitem que seu programa tome decisões baseadas em condições. Nesta lição, você aprenderá a usar comandos IF e ELSE para criar fluxos de execução diferentes dependendo de certas condições serem verdadeiras ou falsas.", "fas fa-code-branch", 1, "Estruturas Condicionais (IF/ELSE)" },
                    { 5, "Os laços de repetição permitem executar um bloco de código múltiplas vezes. Nesta lição, você aprenderá sobre os laços FOR e WHILE, que são fundamentais para automatizar tarefas repetitivas e processar conjuntos de dados.", "fas fa-sync-alt", 1, "Laços de Repetição (FOR/WHILE)" },
                    { 6, "Arrays e listas são estruturas de dados que permitem armazenar múltiplos valores em uma única variável. Nesta lição, você aprenderá como criar, acessar e manipular essas estruturas, que são essenciais para trabalhar com conjuntos de dados.", "fas fa-list-ol", 1, "Introdução a Arrays/Listas" },
                    { 7, "Funções são blocos de código reutilizáveis que executam tarefas específicas. Nesta lição, você aprenderá a criar funções, passar parâmetros para elas e retornar valores, permitindo que você organize seu código de forma mais eficiente.", "fas fa-cogs", 1, "Funções e Parâmetros" },
                    { 8, "A depuração é o processo de encontrar e corrigir erros em seu código. Nesta lição, você aprenderá técnicas e ferramentas para identificar problemas, entender mensagens de erro e corrigir bugs em seus programas.", "fas fa-bug", 1, "Depuração de Código" },
                    { 9, "O pseudocódigo é uma forma de planejar seu programa usando linguagem natural antes de escrever o código real. Nesta lição, você aprenderá como usar o pseudocódigo para planejar a lógica do seu programa e facilitar o processo de desenvolvimento.", "fas fa-file-alt", 1, "Pseudocódigo e Planejamento" },
                    { 10, "Fluxogramas são representações visuais da lógica de um programa. Nesta lição, você aprenderá a criar e interpretar fluxogramas, que são ferramentas poderosas para visualizar e planejar o fluxo de execução de seus programas.", "fas fa-project-diagram", 1, "Fluxogramas e Lógica Visual" }
                });

            migrationBuilder.InsertData(
                table: "Questaos",
                columns: new[] { "Id", "Enunciado", "LicaoId", "RespostaA", "RespostaB", "RespostaC", "RespostaCorreta", "RespostaD", "Tipo" },
                values: new object[,]
                {
                    { 1, "O que é uma variável?", 1, "Um valor fixo que não pode ser alterado", "Um container para armazenar dados", "Um tipo de operador matemático", "B", "Um erro de sintaxe", 0 },
                    { 2, "Como declarar uma variável em pseudocódigo?", 1, "var nome = valor", "variable nome = valor", "nome : valor", "A", "def nome(valor)", 0 },
                    { 3, "Qual é o propósito de usar variáveis?", 1, "Executar operações matemáticas", "Armazenar e reutilizar dados", "Definir cores em interfaces", "B", "Criar laços de repetição", 0 },
                    { 4, "Qual operador é usado para atribuir valor a uma variável?", 1, "==", "=", "=>", "B", "<-", 0 },
                    { 5, "Qual afirmação é verdadeira sobre variáveis?", 1, "Não podem ser modificadas após a criação", "Podem mudar de valor durante a execução", "São sempre números", "B", "São obrigatórias apenas em loops", 0 },
                    { 6, "O que é uma variavel int?", 2, "Não podem ser modificadas após a criação", "somente contem numeros", "São sempre números", "B", "São obrigatórias apenas em loops", 0 },
                    { 7, "O que é uma variavel int?", 3, "Não podem ser modificadas após a criação", "somente contem numeros", "São sempre números", "B", "São obrigatórias apenas em loops", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Licaos_ModuloId",
                table: "Licaos",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "perfil",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_perfil_regra_RoleId",
                table: "perfil_regra",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Questaos_LicaoId",
                table: "Questaos",
                column: "LicaoId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "usuario",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "usuario",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_login_UserId",
                table: "usuario_login",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_perfil_RoleId",
                table: "usuario_perfil",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_regra_UserId",
                table: "usuario_regra",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "perfil_regra");

            migrationBuilder.DropTable(
                name: "Questaos");

            migrationBuilder.DropTable(
                name: "usuario_login");

            migrationBuilder.DropTable(
                name: "usuario_perfil");

            migrationBuilder.DropTable(
                name: "usuario_regra");

            migrationBuilder.DropTable(
                name: "usuario_token");

            migrationBuilder.DropTable(
                name: "Licaos");

            migrationBuilder.DropTable(
                name: "perfil");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "modulo");
        }
    }
}
