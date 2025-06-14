using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Foxdev.Models;

public enum QuestionType
{
    MultipleChoice,
    FillInTheBlank, 
    CodeCompletion  
}

public class Questao
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O conteúdo da questão é obrigatório.")]
    [StringLength(500, ErrorMessage = "O conteúdo não pode exceder 500 caracteres.")]
    public string Enunciado { get; set; }

    [Required(ErrorMessage = "O tipo da questão é obrigatório.")]
    public QuestionType Tipo { get; set; }

    public string RespostaA { get; set; }
    public string RespostaB { get; set; }
    public string RespostaC { get; set; }
    public string RespostaD { get; set; }
    
    // Para MultipleChoice, RespostaCorreta armazena a letra (A, B, C, D).
    // Para FillInTheBlank/CodeCompletion, armazena a resposta esperada.
    public string RespostaCorreta { get; set; }

    [ForeignKey(nameof(LicaoId))] 
    [Required(ErrorMessage = "Questão incorreta")] 
    public int LicaoId { get; set; }

    [JsonIgnore]
    public Licao Licao { get; set; }
}


