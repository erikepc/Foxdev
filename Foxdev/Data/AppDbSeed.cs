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
        SeedUserProgress();
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

    private void SeedLicoes()
    {
        List<Licao> licaos = new List<Licao>
        {
            new Licao { Id = 1, ModuloId = 1, Titulo = "Introdução a Variáveis" },
            new Licao { Id = 2, ModuloId = 1, Titulo = "Tipos de Dados Básicos" },
            new Licao { Id = 3, ModuloId = 1, Titulo = "Operadores Aritméticos e Lógicos" },
            new Licao { Id = 4, ModuloId = 1, Titulo = "Estruturas Condicionais (IF/ELSE)" },
            new Licao { Id = 5, ModuloId = 1, Titulo = "Laços de Repetição (FOR/WHILE)" },
            new Licao { Id = 6, ModuloId = 1, Titulo = "Introdução a Arrays/Listas" },
            new Licao { Id = 7, ModuloId = 1, Titulo = "Funções e Parâmetros" },
            new Licao { Id = 8, ModuloId = 1, Titulo = "Depuração de Código" },
            new Licao { Id = 9, ModuloId = 1, Titulo = "Pseudocódigo e Planejamento" },
            new Licao { Id = 10, ModuloId = 1, Titulo = "Fluxogramas e Lógica Visual" }
        };
        _builder.Entity<Licao>().HasData(licaos);
    }

    private void SeedQuestoes()
{
    List<Questao> questaos = new List<Questao>
    {
        // Lição 1: Introdução a Variáveis (IDs 1-5)
        new Questao { 
            Id = 1, 
            LicaoId = 1, 
            Conteudo = "O que é uma variável?", 
            Respostas = new List<string> { 
                "Um valor fixo que não pode ser alterado",
                "Um container para armazenar dados", 
                "Um tipo de operador matemático",
                "Um erro de sintaxe"
            }, 
            RespostaCorreta = 1,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 2, 
            LicaoId = 1, 
            Conteudo = "Como declarar uma variável em pseudocódigo?", 
            Respostas = new List<string> { 
                "var nome = valor", 
                "variable nome = valor", 
                "nome : valor", 
                "def nome(valor)"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 3, 
            LicaoId = 1, 
            Conteudo = "Qual é o propósito de usar variáveis?", 
            Respostas = new List<string> { 
                "Executar operações matemáticas",
                "Armazenar e reutilizar dados", 
                "Definir cores em interfaces",
                "Criar laços de repetição"
            }, 
            RespostaCorreta = 1,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 4, 
            LicaoId = 1, 
            Conteudo = "Qual operador é usado para atribuir valor a uma variável?", 
            Respostas = new List<string> { 
                "==", 
                "=", 
                "=>", 
                "<-"
            }, 
            RespostaCorreta = 1,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 5, 
            LicaoId = 1, 
            Conteudo = "Qual afirmação é verdadeira sobre variáveis?", 
            Respostas = new List<string> { 
                "Não podem ser modificadas após a criação",
                "Podem mudar de valor durante a execução", 
                "São sempre números",
                "São obrigatórias apenas em loops"
            }, 
            RespostaCorreta = 1,
            Tipo = QuestionType.MultipleChoice 
        },

        // Lição 2: Tipos de Dados Básicos (IDs 6-10)
        new Questao { 
            Id = 6, 
            LicaoId = 2, 
            Conteudo = "Qual tipo de dado representa texto?", 
            Respostas = new List<string> { 
                "int", 
                "string", 
                "boolean", 
                "float"
            }, 
            RespostaCorreta = 1,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 7, 
            LicaoId = 2, 
            Conteudo = "Qual é o valor de 5 + \"5\" em linguagens de tipagem forte?", 
            Respostas = new List<string> { 
                "10", 
                "55", 
                "Erro de tipo (incompatibilidade)", 
                "5"
            }, 
            RespostaCorreta = 2,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 8, 
            LicaoId = 2, 
            Conteudo = "Como se representa um valor booleano falso?", 
            Respostas = new List<string> { 
                "0", 
                "\"false\"", 
                "false", 
                "null"
            }, 
            RespostaCorreta = 2,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 9, 
            LicaoId = 2, 
            Conteudo = "Qual tipo armazena números decimais?", 
            Respostas = new List<string> { 
                "int", 
                "char", 
                "float", 
                "string"
            }, 
            RespostaCorreta = 2,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 10, 
            LicaoId = 2, 
            Conteudo = "Qual é o resultado de (10 > 5)?", 
            Respostas = new List<string> { 
                "true", 
                "false", 
                "1", 
                "0"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },

        // Lição 3: Operadores Aritméticos e Lógicos (IDs 11-15)
        new Questao { 
            Id = 11, 
            LicaoId = 3, 
            Conteudo = "Qual é o resultado de 15 % 4?", 
            Respostas = new List<string> { 
                "3", 
                "4", 
                "0", 
                "15"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 12, 
            LicaoId = 3, 
            Conteudo = "Qual operador representa \"E lógico\" em JavaScript?", 
            Respostas = new List<string> { 
                "&&", 
                "||", 
                "!", 
                "AND"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 13, 
            LicaoId = 3, 
            Conteudo = "Qual é o valor de (5 > 3) && (2 == \"2\")?", 
            Respostas = new List<string> { 
                "false", 
                "true", 
                "null", 
                "0"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 14, 
            LicaoId = 3, 
            Conteudo = "Qual operador tem maior precedência: + ou *?", 
            Respostas = new List<string> { 
                "*", 
                "+", 
                "Igual precedência", 
                "Depende do contexto"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 15, 
            LicaoId = 3, 
            Conteudo = "Qual é o resultado de !(true || false)?", 
            Respostas = new List<string> { 
                "false", 
                "true", 
                "undefined", 
                "1"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },

        // Lição 4: Estruturas Condicionais (IDs 16-20)
        new Questao { 
            Id = 16, 
            LicaoId = 4, 
            Conteudo = "Qual estrutura verifica múltiplas condições?", 
            Respostas = new List<string> { 
                "else if", 
                "switch", 
                "for", 
                "while"
            }, 
            RespostaCorreta = 1,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 17, 
            LicaoId = 4, 
            Conteudo = "Se x = 10, qual condicional verifica \"maior ou igual a 10\"?", 
            Respostas = new List<string> { 
                "x > 10", 
                "x >= 10", 
                "x => 10", 
                "x != 10"
            }, 
            RespostaCorreta = 1,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 18, 
            LicaoId = 4, 
            Conteudo = "O que o operador ternário \"a ? b : c\" representa?", 
            Respostas = new List<string> { 
                "Se a, faça b; senão, c", 
                "a e b ou c", 
                "a dividido por b : c", 
                "Loop enquanto a for verdadeiro"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 19, 
            LicaoId = 4, 
            Conteudo = "Qual erro ocorre se esquecer as chaves {} em um IF com múltiplas linhas?", 
            Respostas = new List<string> { 
                "Erro de sintaxe", 
                "Executa apenas a primeira linha do IF", 
                "Nenhum erro", 
                "Loop infinito"
            }, 
            RespostaCorreta = 1,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 20, 
            LicaoId = 4, 
            Conteudo = "Qual é a saída de: if (false) { ... } else { \"OK\" }?", 
            Respostas = new List<string> { 
                "OK", 
                "Nada", 
                "Erro", 
                "false"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },

        // Lição 5: Laços de Repetição (IDs 21-25)
        new Questao { 
            Id = 21, 
            LicaoId = 5, 
            Conteudo = "Quantas vezes um loop \"for (i=0; i<5; i++)\" executa?", 
            Respostas = new List<string> { 
                "5 vezes", 
                "4 vezes", 
                "6 vezes", 
                "Infinito"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 22, 
            LicaoId = 5, 
            Conteudo = "Como parar um loop prematuramente?", 
            Respostas = new List<string> { 
                "Usar \"break\"", 
                "Usar \"return\"", 
                "Usar \"exit\"", 
                "Desligar o PC"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 23, 
            LicaoId = 5, 
            Conteudo = "Qual loop executa pelo menos uma vez?", 
            Respostas = new List<string> { 
                "do...while", 
                "while", 
                "for", 
                "forEach"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 24, 
            LicaoId = 5, 
            Conteudo = "Qual é o risco de \"while(true)\" sem break?", 
            Respostas = new List<string> { 
                "Loop infinito", 
                "Nenhum risco", 
                "Erro de sintaxe", 
                "Execução lenta"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 25, 
            LicaoId = 5, 
            Conteudo = "Qual loop é melhor para iterar um array?", 
            Respostas = new List<string> { 
                "for", 
                "while", 
                "do...while", 
                "repeat...until"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },

        // Lição 6: Arrays/Listas (IDs 26-30)
        new Questao { 
            Id = 26, 
            LicaoId = 6, 
            Conteudo = "Como acessar o primeiro elemento de um array?", 
            Respostas = new List<string> { 
                "arr[0]", 
                "arr[1]", 
                "arr.first", 
                "arr(0)"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 27, 
            LicaoId = 6, 
            Conteudo = "Qual método adiciona um item ao final do array?", 
            Respostas = new List<string> { 
                "push()", 
                "pop()", 
                "shift()", 
                "unshift()"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 28, 
            LicaoId = 6, 
            Conteudo = "Qual índice representa o terceiro elemento?", 
            Respostas = new List<string> { 
                "2", 
                "3", 
                "0", 
                "1"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 29, 
            LicaoId = 6, 
            Conteudo = "Qual erro ocorre ao acessar arr[arr.length]?", 
            Respostas = new List<string> { 
                "IndexOutOfBounds", 
                "Nenhum erro", 
                "Erro de tipo", 
                "Loop infinito"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 30, 
            LicaoId = 6, 
            Conteudo = "Qual é o valor de [1,2,3].length?", 
            Respostas = new List<string> { 
                "3", 
                "2", 
                "4", 
                "0"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },

        // Lição 7: Funções e Parâmetros (IDs 31-35)
        new Questao { 
            Id = 31, 
            LicaoId = 7, 
            Conteudo = "Qual palavra-chave retorna um valor?", 
            Respostas = new List<string> { 
                "return", 
                "break", 
                "exit", 
                "end"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 32, 
            LicaoId = 7, 
            Conteudo = "O que são parâmetros?", 
            Respostas = new List<string> { 
                "Variáveis recebidas pela função", 
                "Valores retornados", 
                "Operadores lógicos", 
                "Erros"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 33, 
            LicaoId = 7, 
            Conteudo = "Como chamar uma função \"calcular()\"?", 
            Respostas = new List<string> { 
                "calcular();", 
                "call calcular;", 
                "function calcular;", 
                "run calcular();"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 34, 
            LicaoId = 7, 
            Conteudo = "Qual escopo tem uma variável declarada dentro de uma função?", 
            Respostas = new List<string> { 
                "Local", 
                "Global", 
                "Externo", 
                "Compartilhado"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 35, 
            LicaoId = 7, 
            Conteudo = "O que é recursão?", 
            Respostas = new List<string> { 
                "Função que chama a si mesma", 
                "Loop infinito", 
                "Função sem retorno", 
                "Erro de stack"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },

        // Lição 8: Depuração de Código (IDs 36-40)
        new Questao { 
            Id = 36, 
            LicaoId = 8, 
            Conteudo = "O que é um breakpoint?", 
            Respostas = new List<string> { 
                "Ponto de pausa na execução", 
                "Erro de sintaxe", 
                "Tipo de loop", 
                "Operador lógico"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 37, 
            LicaoId = 8, 
            Conteudo = "Qual técnica ajuda a identificar erros?", 
            Respostas = new List<string> { 
                "Testar partes do código", 
                "Reiniciar o PC", 
                "Ignorar avisos", 
                "Escrever mais código"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 38, 
            LicaoId = 8, 
            Conteudo = "O que significa \"Step Over\" no debugger?", 
            Respostas = new List<string> { 
                "Executar a linha atual sem entrar em funções", 
                "Pular todas as linhas", 
                "Deletar código", 
                "Executar em câmera lenta"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 39, 
            LicaoId = 8, 
            Conteudo = "Qual erro é detectado em tempo de compilação?", 
            Respostas = new List<string> { 
                "Erro de sintaxe", 
                "Erro de lógica", 
                "Loop infinito", 
                "Divisão por zero"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 40, 
            LicaoId = 8, 
            Conteudo = "Como ver o valor de uma variável durante a execução?", 
            Respostas = new List<string> { 
                "Usar o debugger", 
                "Imprimir no console", 
                "Chutar valores", 
                "Recompilar o sistema"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },

        // Lição 9: Pseudocódigo (IDs 41-45)
        new Questao { 
            Id = 41, 
            LicaoId = 9, 
            Conteudo = "Qual é o objetivo do pseudocódigo?", 
            Respostas = new List<string> { 
                "Planejar a lógica sem sintaxe rigorosa", 
                "Escrever código executável", 
                "Substituir comentários", 
                "Documentar APIs"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 42, 
            LicaoId = 9, 
            Conteudo = "Como representar \"se x for maior que 5\" em pseudocódigo?", 
            Respostas = new List<string> { 
                "SE x > 5 ENTÃO", 
                "if x > 5:", 
                "when x > 5", 
                "x > 5 ?"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 43, 
            LicaoId = 9, 
            Conteudo = "Qual símbolo geralmente termina um bloco em pseudocódigo?", 
            Respostas = new List<string> { 
                "FIMSE", 
                "}", 
                "end", 
                "stop"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 44, 
            LicaoId = 9, 
            Conteudo = "O que deve vir primeiro no planejamento?", 
            Respostas = new List<string> { 
                "Entender o problema", 
                "Escrever código", 
                "Escolher cores", 
                "Selecionar frameworks"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 45, 
            LicaoId = 9, 
            Conteudo = "Pseudocódigo é específico de uma linguagem?", 
            Respostas = new List<string> { 
                "Não", 
                "Sim", 
                "Às vezes", 
                "Depende do compilador"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },

        // Lição 10: Fluxogramas (IDs 46-50)
        new Questao { 
            Id = 46, 
            LicaoId = 10, 
            Conteudo = "Qual símbolo representa uma decisão?", 
            Respostas = new List<string> { 
                "Losango", 
                "Retângulo", 
                "Círculo", 
                "Triângulo"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 47, 
            LicaoId = 10, 
            Conteudo = "O que uma seta representa?", 
            Respostas = new List<string> { 
                "Fluxo de execução", 
                "Variável", 
                "Erro", 
                "Comentário"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 48, 
            LicaoId = 10, 
            Conteudo = "Como iniciar/finalizar um fluxograma?", 
            Respostas = new List<string> { 
                "Elipse/oval", 
                "Retângulo", 
                "Losango", 
                "Hexágono"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 49, 
            LicaoId = 10, 
            Conteudo = "Quantas saídas tem um losango (decisão)?", 
            Respostas = new List<string> { 
                "2", 
                "1", 
                "3", 
                "Nenhuma"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        },
        new Questao { 
            Id = 50, 
            LicaoId = 10, 
            Conteudo = "Para que serve um retângulo em fluxogramas?", 
            Respostas = new List<string> { 
                "Processamento/Ação", 
                "Decisão", 
                "Início/Fim", 
                "Entrada/Saída"
            }, 
            RespostaCorreta = 0,
            Tipo = QuestionType.MultipleChoice 
        }
    };

    _builder.Entity<Questao>().HasData(questaos);
}

    private void SeedUserProgress()
    {
        // Adicione dados iniciais de progresso se necessário
        _builder.Entity<UserProgress>().HasData(
            new UserProgress 
            { 
                Id = 1, 
                UserId = "exemplo-user-id", 
                LicaoId = 1, 
                Desbloqueada = true, 
                Vidas = 3 
            }
        );
    }
}