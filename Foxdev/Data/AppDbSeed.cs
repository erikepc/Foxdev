using Microsoft.EntityFrameworkCore;
using Foxdev.Models;

namespace Foxdev.Data;

public class AppDbSeed
{
    private readonly ModelBuilder _builder;

    public AppDbSeed(ModelBuilder builder)
    {
        _builder = builder;
    }

    public void Seed()
    {
        SeedModulos();
        SeedLicoes();
        SeedQuestoes();
    }

    private void SeedModulos()
    {
        List<Modulo> modulos = new()
        {
            new Modulo { Id = 1, Titulo = "Lógica de Programação" },
            new Modulo { Id = 2, Titulo = "Introdução ao Frontend" },
            new Modulo { Id = 3, Titulo = "Introdução ao Backend" }
        };
        _builder.Entity<Modulo>().HasData(modulos);
    }

    public void SeedLicoes()
    {
        List<Licao> _todasAsLicoes = new List<Licao>
        {
            new Licao { 
                Id = 1, 
                ModuloId = 1, 
                Titulo = "Introdução a Variáveis",
                Explicacao = "Nesta lição, você aprenderá sobre variáveis, que são espaços na memória do computador usados para armazenar dados. Variáveis são fundamentais na programação, pois permitem que os programas armazenem e manipulem informações. Você aprenderá como declarar variáveis, atribuir valores a elas e utilizá-las em operações básicas.",
                Icon = "fas fa-lightbulb" // Ícone adicionado
            },
            new Licao { 
                Id = 2, 
                ModuloId = 1, 
                Titulo = "Tipos de Dados Básicos",
                Explicacao = "Esta lição aborda os diferentes tipos de dados que podem ser armazenados em variáveis, como números inteiros, números decimais, texto (strings) e valores booleanos (verdadeiro/falso). Compreender os tipos de dados é essencial para manipular informações corretamente em seus programas.",
                Icon = "fas fa-database" // Ícone adicionado
            },
            new Licao { 
                Id = 3, 
                ModuloId = 1, 
                Titulo = "Operadores Aritméticos e Lógicos",
                Explicacao = "Nesta lição, você aprenderá sobre os operadores que permitem realizar cálculos matemáticos (como adição, subtração, multiplicação e divisão) e operações lógicas (como comparações de igualdade, maior que, menor que). Esses operadores são essenciais para criar programas que tomam decisões e processam dados.",
                Icon = "fas fa-calculator" // Ícone adicionado
            },
            new Licao { 
                Id = 4, 
                ModuloId = 1, 
                Titulo = "Estruturas Condicionais (IF/ELSE)",
                Explicacao = "As estruturas condicionais permitem que seu programa tome decisões baseadas em condições. Nesta lição, você aprenderá a usar comandos IF e ELSE para criar fluxos de execução diferentes dependendo de certas condições serem verdadeiras ou falsas.",
                Icon = "fas fa-code-branch" // Ícone adicionado
            },
            new Licao { 
                Id = 5, 
                ModuloId = 1, 
                Titulo = "Laços de Repetição (FOR/WHILE)",
                Explicacao = "Os laços de repetição permitem executar um bloco de código múltiplas vezes. Nesta lição, você aprenderá sobre os laços FOR e WHILE, que são fundamentais para automatizar tarefas repetitivas e processar conjuntos de dados.",
                Icon = "fas fa-sync-alt" // Ícone adicionado
            },
            new Licao { 
                Id = 6, 
                ModuloId = 1, 
                Titulo = "Introdução a Arrays/Listas",
                Explicacao = "Arrays e listas são estruturas de dados que permitem armazenar múltiplos valores em uma única variável. Nesta lição, você aprenderá como criar, acessar e manipular essas estruturas, que são essenciais para trabalhar com conjuntos de dados.",
                Icon = "fas fa-list-ol" // Ícone adicionado
            },
            new Licao { 
                Id = 7, 
                ModuloId = 1, 
                Titulo = "Funções e Parâmetros",
                Explicacao = "Funções são blocos de código reutilizáveis que executam tarefas específicas. Nesta lição, você aprenderá a criar funções, passar parâmetros para elas e retornar valores, permitindo que você organize seu código de forma mais eficiente.",
                Icon = "fas fa-cogs" // Ícone adicionado
            },
            new Licao { 
                Id = 8, 
                ModuloId = 1, 
                Titulo = "Depuração de Código",
                Explicacao = "A depuração é o processo de encontrar e corrigir erros em seu código. Nesta lição, você aprenderá técnicas e ferramentas para identificar problemas, entender mensagens de erro e corrigir bugs em seus programas.",
                Icon = "fas fa-bug" // Ícone adicionado
            },
            new Licao { 
                Id = 9, 
                ModuloId = 1, 
                Titulo = "Pseudocódigo e Planejamento",
                Explicacao = "O pseudocódigo é uma forma de planejar seu programa usando linguagem natural antes de escrever o código real. Nesta lição, você aprenderá como usar o pseudocódigo para planejar a lógica do seu programa e facilitar o processo de desenvolvimento.",
                Icon = "fas fa-file-alt" // Ícone adicionado
            },
            new Licao { 
                Id = 10, 
                ModuloId = 1, 
                Titulo = "Fluxogramas e Lógica Visual",
                Explicacao = "Fluxogramas são representações visuais da lógica de um programa. Nesta lição, você aprenderá a criar e interpretar fluxogramas, que são ferramentas poderosas para visualizar e planejar o fluxo de execução de seus programas.",
                Icon = "fas fa-project-diagram" // Ícone adicionado
            }
        };
        _builder.Entity<Licao>().HasData(_todasAsLicoes);
    }

    public void SeedQuestoes()
    {
        List<Questao> _todasAsQuestoes = new List<Questao>
        {
            // Lição 1: Introdução a Variáveis (IDs 1–10)
            new Questao { Id = 1,  LicaoId = 1, Enunciado = "O que é uma variável em programação?", RespostaA = "Um comentário no código", RespostaB = "Uma função que retorna um valor", RespostaC = "Um contêiner para armazenar dados", RespostaD = "Um tipo de laço de repetição", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 2,  LicaoId = 1, Enunciado = "Como declaramos uma variável em pseudocódigo?", RespostaA = "let nome(valor)", RespostaB = "nome : valor", RespostaC = "def nome(valor)", RespostaD = "var nome = valor", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 3,  LicaoId = 1, Enunciado = "Para que servem as variáveis?", RespostaA = "Armazenar e reutilizar dados", RespostaB = "Compilar o código", RespostaC = "Enviar e-mails", RespostaD = "Desenhar elementos na tela", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 4,  LicaoId = 1, Enunciado = "Qual operador atribuÍ valor a uma variável?", RespostaA = "=>", RespostaB = "<-", RespostaC = "==", RespostaD = "=", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 5,  LicaoId = 1, Enunciado = "Variáveis podem mudar de valor durante a execução?", RespostaA = "Sim", RespostaB = "Só em linguagens funcionais", RespostaC = "Só em pseudocódigo", RespostaD = "Não", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 6,  LicaoId = 1, Enunciado = "Qual palavra reservada declara uma variável em C#?", RespostaA = "dim", RespostaB = "var", RespostaC = "variable", RespostaD = "let", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 7,  LicaoId = 1, Enunciado = "Como nomear variáveis de acordo com convenção?", RespostaA = "Usar snake_case", RespostaB = "Iniciar com número", RespostaC = "CamelCase", RespostaD = "Tudo maiúsculo", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 8,  LicaoId = 1, Enunciado = "Qual alternativa sobre variáveis é FALSA?", RespostaA = "Podem ter qualquer nome", RespostaB = "Não existem em pseudocódigo", RespostaC = "Precisam ser inicializadas antes de usar", RespostaD = "Podem ser globais ou locais", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 9,  LicaoId = 1, Enunciado = "Variáveis não inicializadas contêm:", RespostaA = "Zero", RespostaB = "String vazia", RespostaC = "Erro de compilação", RespostaD = "Null ou lixo de memória", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 10,  LicaoId = 1, Enunciado = "Qual tipo de variável armazena texto?", RespostaA = "bool", RespostaB = "char", RespostaC = "string", RespostaD = "int", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
        
            // Lição 2: Tipos de Dados Básicos (IDs 11–20)
            new Questao { Id = 11,  LicaoId = 2, Enunciado = "Qual tipo armazena números inteiros?", RespostaA = "string", RespostaB = "int", RespostaC = "bool", RespostaD = "float", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 12,  LicaoId = 2, Enunciado = "Qual tipo armazena números com ponto flutuante?", RespostaA = "bool", RespostaB = "char", RespostaC = "int", RespostaD = "float", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 13,  LicaoId = 2, Enunciado = "Qual tipo armazena verdadeiro/falso?", RespostaA = "double", RespostaB = "bool", RespostaC = "int", RespostaD = "string", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 14,  LicaoId = 2, Enunciado = "Qual tipo armazena um único caractere?", RespostaA = "string", RespostaB = "bool", RespostaC = "int", RespostaD = "char", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 15,  LicaoId = 2, Enunciado = "string em C# equivale a:", RespostaA = "Valor lógico", RespostaB = "Único caractere", RespostaC = "Sequência de caracteres", RespostaD = "Número inteiro", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 16,  LicaoId = 2, Enunciado = "double difere de float por:", RespostaA = "Maior alcance e precisão", RespostaB = "Menor precisão", RespostaC = "Armazenar texto", RespostaD = "Ser um tipo lógico", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 17,  LicaoId = 2, Enunciado = "Qual tipo usar para moedas (decimal)?", RespostaA = "int", RespostaB = "bool", RespostaC = "decimal", RespostaD = "float", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 18,  LicaoId = 2, Enunciado = "Qual tipo pode armazenar null em C#?", RespostaA = "string", RespostaB = "int", RespostaC = "enum", RespostaD = "struct", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 19,  LicaoId = 2, Enunciado = "Qual tipo de dado é imutável em C#?", RespostaA = "List", RespostaB = "Array", RespostaC = "string", RespostaD = "Dictionary", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 20,  LicaoId = 2, Enunciado = "Qual alternativa define melhor um enum?", RespostaA = "Função especial", RespostaB = "Objeto de dados", RespostaC = "Lista de strings", RespostaD = "Conjunto nomeado de constantes", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            
            // Lição 3: Operadores Aritméticos e Lógicos (21–30)
            new Questao { Id = 21,  LicaoId = 3, Enunciado = "Qual operador soma valores?", RespostaA = "/", RespostaB = "*", RespostaC = "-", RespostaD = "+", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 22,  LicaoId = 3, Enunciado = "Qual operador subtrai valores?", RespostaA = "-", RespostaB = "/", RespostaC = "*", RespostaD = "%", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 23,  LicaoId = 3, Enunciado = "Operador % retorna:", RespostaA = "Divisão inteira", RespostaB = "Potência", RespostaC = "Resto da divisão", RespostaD = "Concatenação", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 24,  LicaoId = 3, Enunciado = "Qual operador AND lógico?", RespostaA = "!", RespostaB = "&&", RespostaC = "^", RespostaD = "||", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 25,  LicaoId = 3, Enunciado = "Qual operador OR lógico?", RespostaA = "|", RespostaB = "&&", RespostaC = "||", RespostaD = "&", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 26,  LicaoId = 3, Enunciado = "Qual operador NOT lógico?", RespostaA = "¬", RespostaB = "!", RespostaC = "not", RespostaD = "~", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 27,  LicaoId = 3, Enunciado = "++ é operador de:", RespostaA = "Subtração", RespostaB = "Comparação", RespostaC = "Negação", RespostaD = "Incremento", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 28,  LicaoId = 3, Enunciado = "-- é operador de:", RespostaA = "Decremento", RespostaB = "Multiplicação", RespostaC = "Concatenação", RespostaD = "Divisão", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 29,  LicaoId = 3, Enunciado = "1 == '1' em C# resulta em:", RespostaA = "Não faz comparação", RespostaB = "false", RespostaC = "true", RespostaD = "Erro de compilação", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 30,  LicaoId = 3, Enunciado = "Qual operador compara se é diferente?", RespostaA = "==", RespostaB = "!==", RespostaC = "!=", RespostaD = "~=", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            
            // Lição 4: Estruturas Condicionais (IF/ELSE) (31–40)
            new Questao { Id = 31,  LicaoId = 4, Enunciado = "Qual sintaxe básica de um if em pseudocódigo?", RespostaA = "if(condição)", RespostaB = "if = condição", RespostaC = "if condição then", RespostaD = "if: condição", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 32,  LicaoId = 4, Enunciado = "Como se escreve else?", RespostaA = "elseif", RespostaB = "else", RespostaC = "elif", RespostaD = "otherwise", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 33,  LicaoId = 4, Enunciado = "Em IF aninhado, ELSE if é:", RespostaA = "else if", RespostaB = "ifelse", RespostaC = "elif", RespostaD = "elseif", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 34,  LicaoId = 4, Enunciado = "O bloco else é executado quando:", RespostaA = "sempre antes do if", RespostaB = "condição é verdadeira", RespostaC = "nunca", RespostaD = "condição é falsa", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 35,  LicaoId = 4, Enunciado = "É possível aninhar ifs? ", RespostaA = "Sim", RespostaB = "Não", RespostaC = "Só em Java", RespostaD = "Só em pseudocódigo", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 36,  LicaoId = 4, Enunciado = "switch-case é equivalente a:", RespostaA = "for", RespostaB = "do-while", RespostaC = "if aninhado", RespostaD = "while", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 37,  LicaoId = 4, Enunciado = "Qual palavra-chave encerra um case em C#?", RespostaA = "exit", RespostaB = "end", RespostaC = "stop", RespostaD = "break", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 38,  LicaoId = 4, Enunciado = "if(true) { } é executado:", RespostaA = "Nunca", RespostaB = "Sempre", RespostaC = "Uma vez só", RespostaD = "Dupla", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 39,  LicaoId = 4, Enunciado = "Qual é operador ternário em C#?", RespostaA = "::", RespostaB = "=>", RespostaC = "?:", RespostaD = "&&", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 40,  LicaoId = 4, Enunciado = "Em pseudocódigo, quais chaves definem bloco?", RespostaA = "[]", RespostaB = "{}", RespostaC = "<>", RespostaD = "begin…end", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
        
            // Lição 5: Laços de Repetição (FOR/WHILE) (41–50)
            new Questao { Id = 41,  LicaoId = 5, Enunciado = "Qual a sintaxe básica de um for em pseudocódigo?", RespostaA = "repeat i", RespostaB = "while i < 10", RespostaC = "for i = 1 to 10", RespostaD = "loop 10 times", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 42,  LicaoId = 5, Enunciado = "Qual laço repete enquanto a condição for verdadeira?", RespostaA = "for", RespostaB = "if", RespostaC = "switch", RespostaD = "while", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 43,  LicaoId = 5, Enunciado = "repeat…until executa até:", RespostaA = "condição ser verdadeira", RespostaB = "condição ser falsa", RespostaC = "nunca", RespostaD = "sempre", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 44,  LicaoId = 5, Enunciado = "break dentro de um laço:", RespostaA = "Volta ao início", RespostaB = "Interrompe o laço", RespostaC = "Ignora iteração", RespostaD = "Continua fora", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 45,  LicaoId = 5, Enunciado = "continue em um for faz:", RespostaA = "Volta para main", RespostaB = "Encerra o laço", RespostaC = "Nada", RespostaD = "Pula para próxima iteração", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 46,  LicaoId = 5, Enunciado = "for(i=0; i<5; i++) executa quantas vezes?", RespostaA = "4", RespostaB = "6", RespostaC = "5", RespostaD = "0", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 47,  LicaoId = 5, Enunciado = "while(true) { } é:", RespostaA = "Erro", RespostaB = "Condicional", RespostaC = "Laço finito", RespostaD = "Laço infinito", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 48,  LicaoId = 5, Enunciado = "São exemplos de laços, exceto:", RespostaA = "while", RespostaB = "if", RespostaC = "do-while", RespostaD = "for", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 49,  LicaoId = 5, Enunciado = "do { } while(condição) garante ao menos uma execução?", RespostaA = "Só em pseudocódigo", RespostaB = "Não", RespostaC = "Sim", RespostaD = "Só em C#", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 50,  LicaoId = 5, Enunciado = "Qual laço é pré-testado?", RespostaA = "while", RespostaB = "foreach", RespostaC = "repeat-until", RespostaD = "do-while", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
        
            // Lição 6: Introdução a Arrays/Listas (51–60)
            new Questao { Id = 51,  LicaoId = 6, Enunciado = "O que é um array?", RespostaA = "Comentário", RespostaB = "Operador", RespostaC = "Estrutura de dados sequencial", RespostaD = "Função especial", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 52,  LicaoId = 6, Enunciado = "Como acessar o primeiro elemento de um array?", RespostaA = "array[1]", RespostaB = "array.get(1)", RespostaC = "array.first()", RespostaD = "array[0]", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 53,  LicaoId = 6, Enunciado = "Qual índice do último elemento em um array de tamanho n?", RespostaA = "0", RespostaB = "n-1", RespostaC = "n", RespostaD = "n+1", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 54,  LicaoId = 6, Enunciado = "Em C#, List<T> é equivalente a:", RespostaA = "StringBuilder", RespostaB = "Array", RespostaC = "Coleção dinâmica", RespostaD = "Comentário", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 55,  LicaoId = 6, Enunciado = "Como adicionamos elemento em List<T>?", RespostaA = "Add()", RespostaB = "Append()", RespostaC = "Insert()", RespostaD = "Push()", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 56,  LicaoId = 6, Enunciado = "Como removemos elemento de List<T>?", RespostaA = "Pop()", RespostaB = "Clear()", RespostaC = "Delete()", RespostaD = "Remove()", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 57,  LicaoId = 6, Enunciado = "Qual método obtém número de elementos em List<T>?", RespostaA = "Length()", RespostaB = "Size", RespostaC = "Count", RespostaD = "Length", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 58,  LicaoId = 6, Enunciado = "Arrays têm tamanho fixo?", RespostaA = "Não", RespostaB = "Só em Java", RespostaC = "Só em pseudocódigo", RespostaD = "Sim", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 59,  LicaoId = 6, Enunciado = "List<T> permite tamanhos dinâmicos?", RespostaA = "Só em Python", RespostaB = "Sim", RespostaC = "Não", RespostaD = "Só em C#", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 60,  LicaoId = 6, Enunciado = "Qual índice é inválido em array[5]?", RespostaA = "5", RespostaB = "0", RespostaC = "-1", RespostaD = "4", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
        
            // Lição 7: Funções e Parâmetros (61–70)
            new Questao { Id = 61,  LicaoId = 7, Enunciado = "O que é uma função?", RespostaA = "Comentário", RespostaB = "Variável especial", RespostaC = "Condição", RespostaD = "Bloco reutilizável de código", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 62,  LicaoId = 7, Enunciado = "Como definimos pseudocódigo de função?", RespostaA = "def nome():", RespostaB = "function nome():", RespostaC = "proc nome()", RespostaD = "fun nome()", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 63,  LicaoId = 7, Enunciado = "O que são parâmetros?", RespostaA = "Tipos de dados", RespostaB = "Laços", RespostaC = "Operadores", RespostaD = "Variáveis internas à função", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 64,  LicaoId = 7, Enunciado = "Como chamamos uma função?", RespostaA = "exec nome()", RespostaB = "call nome()", RespostaC = "nome()", RespostaD = "run nome", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 65,  LicaoId = 7, Enunciado = "Funções podem retornar valor?", RespostaA = "Só em pseudocódigo", RespostaB = "Sim", RespostaC = "Não", RespostaD = "Só em C#", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 66,  LicaoId = 7, Enunciado = "Retorna em C# é:", RespostaA = "break", RespostaB = "exit", RespostaC = "return", RespostaD = "yield", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 67,  LicaoId = 7, Enunciado = "Funções sem retorna são do tipo:", RespostaA = "void", RespostaB = "bool", RespostaC = "float", RespostaD = "int", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 68,  LicaoId = 7, Enunciado = "Parâmetro opcional é definido com:", RespostaA = "?", RespostaB = ":", RespostaC = "<>", RespostaD = "=", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 69,  LicaoId = 7, Enunciado = "Funções recursivas chamam a si mesmas?", RespostaA = "Só em C#", RespostaB = "Sim", RespostaC = "Só em Python", RespostaD = "Não", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 70,  LicaoId = 7, Enunciado = "Qual palavra-chave define método estático em C#?", RespostaA = "override", RespostaB = "private", RespostaC = "static", RespostaD = "public", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
        
            // Lição 8: Depuração de Código (71–80)
            new Questao { Id = 71,  LicaoId = 8, Enunciado = "O que é depuração (debug)?", RespostaA = "Escrever comentários", RespostaB = "Compilar", RespostaC = "Executar mais rápido", RespostaD = "Corrigir erros de código", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 72,  LicaoId = 8, Enunciado = "Breakpoint serve para:", RespostaA = "Compilar código", RespostaB = "Excluir variável", RespostaC = "Parar execução num ponto", RespostaD = "Acelerar laço", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 73,  LicaoId = 8, Enunciado = "Stack trace mostra:", RespostaA = "Laços ativos", RespostaB = "Sequência de chamadas", RespostaC = "Comentário", RespostaD = "Variáveis globais", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 74,  LicaoId = 8, Enunciado = "Watch window é usada para:", RespostaA = "Visualizar variáveis", RespostaB = "Excluir classe", RespostaC = "Editar método", RespostaD = "Compilar", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 75,  LicaoId = 8, Enunciado = "Step over avança:", RespostaA = "Até próximo breakpoint", RespostaB = "Linha a linha, sem entrar em funções", RespostaC = "Para dentro de funções", RespostaD = "Fim do programa", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 76,  LicaoId = 8, Enunciado = "Step into avança:", RespostaA = "Ignora loops", RespostaB = "Ignora condições", RespostaC = "Para fora de funções", RespostaD = "Para dentro de funções", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 77,  LicaoId = 8, Enunciado = "Logs ajudam a:", RespostaA = "Registrar eventos de execução", RespostaB = "Desenhar UI", RespostaC = "Enviar e-mail", RespostaD = "Compilar mais rápido", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 78,  LicaoId = 8, Enunciado = "Erros de sintaxe são detectados em:", RespostaA = "Tempo de depuração", RespostaB = "Tempo de design", RespostaC = "Tempo de compilação", RespostaD = "Tempo de execução", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 79,  LicaoId = 8, Enunciado = "Erros de runtime ocorrem em:", RespostaA = "Design", RespostaB = "Deploy", RespostaC = "Compilação", RespostaD = "Execução", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 80,  LicaoId = 8, Enunciado = "Exceções não tratadas causam:", RespostaA = "Comentário", RespostaB = "Loop infinito", RespostaC = "Falha do programa", RespostaD = "Compilação", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
        
            // Lição 9: Pseudocódigo e Planejamento (81–90)
            new Questao { Id = 81,  LicaoId = 9, Enunciado = "Pseudocódigo é usado para:", RespostaA = "Desenhar interface", RespostaB = "Escrever código real", RespostaC = "Depurar", RespostaD = "Planejar lógica", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 82,  LicaoId = 9, Enunciado = "Início e fim em pseudocódigo usam:", RespostaA = "<…>", RespostaB = "{…}", RespostaC = "begin…end", RespostaD = "[…]", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 83,  LicaoId = 9, Enunciado = "Comentários em pseudocódigo:", RespostaA = "?!", RespostaB = "/* */", RespostaC = "##", RespostaD = "//", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 84,  LicaoId = 9, Enunciado = "Fluxo linear significa:", RespostaA = "Sem desvios", RespostaB = "Com funções", RespostaC = "Com loops", RespostaD = "Com condições", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 85,  LicaoId = 9, Enunciado = "Passos de planejamento não incluem:", RespostaA = "Mapear fluxo", RespostaB = "Desenhar UI", RespostaC = "Escrever pseudocódigo", RespostaD = "Definir entrada/saída", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 86,  LicaoId = 9, Enunciado = "Objetivo do pseudocódigo é:", RespostaA = "Compilar", RespostaB = "Depurar", RespostaC = "Validar lógica antes de programar", RespostaD = "Testar UI", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 87,  LicaoId = 9, Enunciado = "Pseudocódigo independente de:", RespostaA = "Sistema operacional", RespostaB = "Banco de dados", RespostaC = "Hardware", RespostaD = "Linguagem de programação", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 88,  LicaoId = 9, Enunciado = "A clareza no pseudocódigo evita:", RespostaA = "Loop infinito", RespostaB = "Erros de lógica", RespostaC = "Depuração", RespostaD = "Compilação", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 89,  LicaoId = 9, Enunciado = "Detalhamento excessivo no pseudocódigo:", RespostaA = "Não importa", RespostaB = "Obrigatório", RespostaC = "Pode confundir", RespostaD = "Uso ideal", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 90,  LicaoId = 9, Enunciado = "Pseudocódigo facilita:", RespostaA = "Comunicação entre equipes", RespostaB = "Acelerar rede", RespostaC = "Compilação rápida", RespostaD = "Renderizar UI", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
        
            // Lição 10: Fluxogramas e Lógica Visual (91–100)
            new Questao { Id = 91,  LicaoId = 10, Enunciado = "O que é um fluxograma?", RespostaA = "Comentário", RespostaB = "Código binário", RespostaC = "Texto estruturado", RespostaD = "Diagrama de fluxo", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 92,  LicaoId = 10, Enunciado = "Qual símbolo representa decisão?", RespostaA = "Círculo", RespostaB = "Seta", RespostaC = "Losango", RespostaD = "Retângulo", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 93,  LicaoId = 10, Enunciado = "Processo em fluxograma é:", RespostaA = "Retângulo", RespostaB = "Hexágono", RespostaC = "Círculo", RespostaD = "Losango", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 94,  LicaoId = 10, Enunciado = "Conector mostra:", RespostaA = "Início/fim", RespostaB = "Fluxo de dados", RespostaC = "Comentário", RespostaD = "Banco de dados", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 95,  LicaoId = 10, Enunciado = "Símbolo de início/fim é:", RespostaA = "Retângulo", RespostaB = "Losango", RespostaC = "Elipse", RespostaD = "Seta", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 96,  LicaoId = 10, Enunciado = "Setas em fluxograma indicam:", RespostaA = "Comentários", RespostaB = "Fluxo de execução", RespostaC = "Erro", RespostaD = "Variáveis", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 97,  LicaoId = 10, Enunciado = "Fluxograma ajuda a:", RespostaA = "Depurar automaticamente", RespostaB = "Compilar código", RespostaC = "Enviar e-mail", RespostaD = "Planejar lógica visualmente", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 98,  LicaoId = 10, Enunciado = "Símbolo de entrada/saída é:", RespostaA = "Paralelogramo", RespostaB = "Hexágono", RespostaC = "Retângulo", RespostaD = "Losango", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 99,  LicaoId = 10, Enunciado = "Fluxograma não deve ficar:", RespostaA = "Documentado", RespostaB = "Linear", RespostaC = "Confuso", RespostaD = "Legível", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 100,  LicaoId = 10, Enunciado = "Qual prática melhora fluxogramas?", RespostaA = "Adicionar loops infinitos", RespostaB = "Usar cores aleatórias", RespostaC = "Evitar descrições", RespostaD = "Manter fluxo claro", RespostaCorreta = "D", Tipo = QuestionType.MultipleChoice },
        };

        _builder.Entity<Questao>().HasData(_todasAsQuestoes);
    }

}

