using System;
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

    public Array Resposta { get; set; }

    [Required(ErrorMessage = "A resposta correta é obrigatória.")]
    public int RespostaCorreta { get; set; }

    // Código relevante para a questão (opcional)
    public string CodeSnippet { get; set; }

    // Relacionamento com a lição (uma questão pertence a uma lição)
    public int LicaoId { get; set; }
    public Licao Licao { get; set; }
}