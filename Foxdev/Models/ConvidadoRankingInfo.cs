namespace Foxdev.Models;

// Modelo simples para simular dados do ranking
public class ConvidadoRankingInfo
{
    public string Nickname { get; set; }
    public int Score { get; set; }
    public int CompletedLessons { get; set; }

    public int licaoId { get; set; }
    public int scoreObtido { get; set; }
    public int totalQuestoes { get; set; }
}

