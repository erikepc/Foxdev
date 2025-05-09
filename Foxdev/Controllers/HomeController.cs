using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Foxdev.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Foxdev.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<ConvidadoRankingInfo> _convidadosRanking = new List<ConvidadoRankingInfo>();

        // Simulação dos dados do AppDbSeed.cs para Licoes e Questoes
        private static List<Licao> _todasAsLicoes = new List<Licao>
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

        private static List<Questao> _todasAsQuestoes = new List<Questao>
        {
            new Questao { Id = 1, LicaoId = 1, Enunciado = "O que é uma variável?", RespostaA = "Um valor fixo que não pode ser alterado", RespostaB = "Um container para armazenar dados", RespostaC = "Um tipo de operador matemático", RespostaD = "Um erro de sintaxe", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 2, LicaoId = 1, Enunciado = "Como declarar uma variável em pseudocódigo?", RespostaA = "var nome = valor", RespostaB = "variable nome = valor", RespostaC = "nome : valor", RespostaD ="def nome(valor)", RespostaCorreta = "A", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 3, LicaoId = 1, Enunciado = "Qual é o propósito de usar variáveis?", RespostaA = "Executar operações matemáticas", RespostaB = "Armazenar e reutilizar dados", RespostaC = "Definir cores em interfaces", RespostaD = "Criar laços de repetição", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 4, LicaoId = 1, Enunciado = "Qual operador é usado para atribuir valor a uma variável?", RespostaA = "==", RespostaB = "=", RespostaC = "=>", RespostaD = "<-", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 5, LicaoId = 1, Enunciado = "Qual afirmação é verdadeira sobre variáveis?", RespostaA = "Não podem ser modificadas após a criação", RespostaB = "Podem mudar de valor durante a execução", RespostaC = "São sempre números", RespostaD = "São obrigatórias apenas em loops", RespostaCorreta = "B", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 6, LicaoId = 2, Enunciado = "Qual destes é um tipo de dado numérico inteiro?", RespostaA = "String", RespostaB = "Boolean", RespostaC = "Integer", RespostaD = "Float", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
            new Questao { Id = 7, LicaoId = 2, Enunciado = "O que o tipo de dado 'Boolean' representa?", RespostaA = "Um número decimal", RespostaB = "Um texto", RespostaC = "Verdadeiro ou Falso", RespostaD = "Uma lista de itens", RespostaCorreta = "C", Tipo = QuestionType.MultipleChoice },
        };


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Nickname()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalvarNicknameEContinuar(string nickname)
        {
            if (!string.IsNullOrEmpty(nickname))
            {
                HttpContext.Session.SetString("UserNickname", nickname);
                HttpContext.Session.SetString("SessionStartTime", DateTime.UtcNow.ToString());
                HttpContext.Session.SetInt32("UserScore", 0);
                HttpContext.Session.SetInt32("UserCompletedLessons", 0);

                var convidadoExistente = _convidadosRanking.FirstOrDefault(c => c.Nickname == nickname);
                if (convidadoExistente == null)
                {
                    _convidadosRanking.Add(new ConvidadoRankingInfo { Nickname = nickname, Score = 0, CompletedLessons = 0 });
                }
                // else // Se o convidado já existe, não zeramos o score/lições do ranking aqui.
                // A pontuação da SESSÃO já foi zerada acima.
                // O ranking será atualizado com a nova pontuação da sessão em ProcessarRespostas.
            }
            else
            {
                TempData["ErrorMessage"] = "Por favor, insira um apelido para continuar.";
                return RedirectToAction("Nickname");
            }
            return RedirectToAction("Convidado");
        }

        public IActionResult Convidado()
        {
            var nickname = HttpContext.Session.GetString("UserNickname");
            if (string.IsNullOrEmpty(nickname))
            {
                return RedirectToAction("Nickname");
            }
            ViewData["Nickname"] = nickname;
            return View();
        }

        public IActionResult Trilhas()
        {
            var nickname = HttpContext.Session.GetString("UserNickname");
            if (string.IsNullOrEmpty(nickname))
            {
                return RedirectToAction("Nickname");
            }
            ViewData["Nickname"] = nickname;
            return View();
        }

        public IActionResult Questionario(int licaoId)
        {
            var nickname = HttpContext.Session.GetString("UserNickname");
            if (string.IsNullOrEmpty(nickname))
            {
                return RedirectToAction("Nickname");
            }

            var licaoAtual = _todasAsLicoes.FirstOrDefault(l => l.Id == licaoId);
            var questoesDaLicao = _todasAsQuestoes.Where(q => q.LicaoId == licaoId).ToList();

            ViewData["Nickname"] = nickname;
            ViewData["LicaoId"] = licaoId;
            ViewData["NomeLicao"] = licaoAtual?.Titulo ?? "Lição Desconhecida";
            ViewData["Questoes"] = questoesDaLicao;
            
            return View();
        }

        [HttpPost]
        public IActionResult ProcessarRespostas([FromBody] ConvidadoRankingInfo parametros)
        {
            Console.WriteLine(parametros.scoreObtido);
            var nickname = HttpContext.Session.GetString("UserNickname");
            if (string.IsNullOrEmpty(nickname))
            {
                return Json(new { success = false, message = "Sessão expirada ou inválida." });
            }

            var currentScore = HttpContext.Session.GetInt32("UserScore") ?? 0;
            var currentLessons = HttpContext.Session.GetInt32("UserCompletedLessons") ?? 0;

            currentScore += parametros.scoreObtido;
            currentLessons += 1;

            HttpContext.Session.SetInt32("UserScore", currentScore);
            HttpContext.Session.SetInt32("UserCompletedLessons", currentLessons);

            var convidadoNoRanking = _convidadosRanking.FirstOrDefault(c => c.Nickname == nickname);
            if (convidadoNoRanking != null)
            {
                convidadoNoRanking.Score = currentScore;
                convidadoNoRanking.CompletedLessons = currentLessons;
            }
            else
            {
                 _convidadosRanking.Add(new ConvidadoRankingInfo { Nickname = nickname, Score = currentScore, CompletedLessons = currentLessons });
            }

            return Json(new { success = true, message = "Progresso salvo com sucesso!" });
        }
        
        public IActionResult Ranking()
        {
            ViewData["UserNickname"] = HttpContext.Session.GetString("UserNickname");
            ViewData["UserScore"] = HttpContext.Session.GetInt32("UserScore") ?? 0;
            ViewData["UserCompletedLessons"] = HttpContext.Session.GetInt32("UserCompletedLessons") ?? 0;

            var rankingParaView = new List<ConvidadoRankingInfo>(_convidadosRanking);
            
            if (!rankingParaView.Any(r => r.Nickname == "PlayerOne")) rankingParaView.Add(new ConvidadoRankingInfo { Nickname = "PlayerOne", Score = 1500, CompletedLessons = 10 });

            ViewData["RankingData"] = rankingParaView.OrderByDescending(r => r.Score).ToList();
            return View();
        }

        public IActionResult SairDaSessao()
        {
            HttpContext.Session.Remove("UserNickname");
            HttpContext.Session.Remove("SessionStartTime");
            HttpContext.Session.Remove("UserScore");
            HttpContext.Session.Remove("UserCompletedLessons");
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

