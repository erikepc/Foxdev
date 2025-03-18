using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foxdev.Models;

public enum QuestionType
{
    MultipleChoice, // Múltipla escolha
    FillInTheBlank, // Preencher lacunas
    CodeCompletion  // Completar código
}

public class Questao
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O conteúdo da questão é obrigatório.")]
    [StringLength(500, ErrorMessage = "O conteúdo não pode exceder 500 caracteres.")]
    public string Conteudo { get; set; }

    [Required(ErrorMessage = "O tipo da questão é obrigatório.")]
    public QuestionType Tipo { get; set; }

    public List<string> Respostas { get; set; } // Alterado para List<string>

    [Required(ErrorMessage = "A resposta correta é obrigatória.")]
    [Range(0, int.MaxValue, ErrorMessage = "Índice inválido")]
    public int RespostaCorreta { get; set; }

    public string CodeSnippet { get; set; }
    public int LicaoId { get; set; }
    public Licao Licao { get; set; }
}