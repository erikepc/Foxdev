using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Foxdev.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System;
using Foxdev.Data;

namespace Foxdev.Controllers
{

    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private static List<ConvidadoRankingInfo> _convidadosRanking = new List<ConvidadoRankingInfo>();

        
        public HomeController(AppDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Duvidas()
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

            var licaoAtual = _context.Licaos.FirstOrDefault(l => l.Id == licaoId);
            var questoesDaLicao = _context.Questaos.Where(q => q.LicaoId == licaoId).ToList();

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

