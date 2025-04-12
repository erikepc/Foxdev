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
        new Questao 
        { 
        Id = 1, 
        LicaoId = 1, 
        Enunciado = "O que é uma variável?", 
        RespostaA = "Um valor fixo que não pode ser alterado",
        RespostaB = "Um container para armazenar dados", 
        RespostaC = "Um tipo de operador matemático",
        RespostaD = "Um erro de sintaxe",
        RespostaCorreta = "B",
        Tipo = QuestionType.MultipleChoice 
        }, 
        
        
        new Questao { 
            Id = 2, 
            LicaoId = 1, 
            Enunciado = "Como declarar uma variável em pseudocódigo?", 
            RespostaA = "var nome = valor", 
            RespostaB = "variable nome = valor", 
            RespostaC = "nome : valor", 
            RespostaD ="def nome(valor)",
            RespostaCorreta = "A",
            Tipo = QuestionType.MultipleChoice 
            }, 
        
        new Questao { 
            Id = 3, 
            LicaoId = 1, 
            Enunciado = "Qual é o propósito de usar variáveis?", 
            RespostaA = "Executar operações matemáticas",
            RespostaB = "Armazenar e reutilizar dados", 
            RespostaC = "Definir cores em interfaces",
            RespostaD = "Criar laços de repetição",
            RespostaCorreta = "B",
            Tipo = QuestionType.MultipleChoice 
            }, 
        
        new Questao { 
            Id = 4, 
            LicaoId = 1, 
            Enunciado = "Qual operador é usado para atribuir valor a uma variável?", 
            RespostaA = "==", 
            RespostaB = "=", 
            RespostaC = "=>", 
            RespostaD = "<-",
            RespostaCorreta = "B",
            Tipo = QuestionType.MultipleChoice 
            }, 
        
        new Questao { 
            Id = 5, 
            LicaoId = 1, 
            Enunciado = "Qual afirmação é verdadeira sobre variáveis?", 
            RespostaA = "Não podem ser modificadas após a criação",
            RespostaB = "Podem mudar de valor durante a execução", 
            RespostaC = "São sempre números",
            RespostaD = "São obrigatórias apenas em loops",
            RespostaCorreta = "B",
            Tipo = QuestionType.MultipleChoice 
            } 
    };

    _builder.Entity<Questao>().HasData(questaos);
}

}