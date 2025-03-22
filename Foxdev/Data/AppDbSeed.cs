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
            new Questao 
            { 
                Id = 1, 
                LicaoId = 1, 
                Conteudo = "O que é uma variável?", 
                Respostas = new List<string> 
                { 
                    "Um valor fixo que não pode ser alterado",
                    "Um nome que se refere a um valor que pode mudar",
                    "Um tipo de loop em programação"
                }, 
                RespostaCorreta = 1,
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