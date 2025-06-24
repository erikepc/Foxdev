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
        private const int LifeRegenerationIntervalMinutes = 5;

        
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
                HttpContext.Session.SetString("SessionStartTime", DateTime.UtcNow.ToString("o")); // Use ISO 8601 format
                HttpContext.Session.SetInt32("UserScore", 0);
                HttpContext.Session.SetInt32("UserCompletedLessons", 0);
                
                // Inicializa o sistema de vidas
                HttpContext.Session.SetInt32("UserLives", 5);
                HttpContext.Session.SetString("LastLifeRegenerationTime", DateTime.UtcNow.ToString("o")); // Use ISO 8601 format

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
            
            // Verificar e regenerar vidas se necessário
            RegenerarVidas();
            
            var currentLives = HttpContext.Session.GetInt32("UserLives") ?? 5;
            var lastRegenerationTimeStr = HttpContext.Session.GetString("LastLifeRegenerationTime") ?? DateTime.UtcNow.ToString("o");

            ViewData["Nickname"] = nickname;
            ViewData["UserLives"] = currentLives;
            // Passa o timestamp da última regeneração para a view
            ViewData["LastRegenTimestamp"] = lastRegenerationTimeStr;
            // Passa o intervalo de regeneração para a view (em minutos)
            ViewData["RegenIntervalMinutes"] = LifeRegenerationIntervalMinutes;

            return View();
        }
        
        // Método para regenerar vidas (1 vida a cada 5 minutos)
        private void RegenerarVidas()
        {
            var lastRegenerationTimeStr = HttpContext.Session.GetString("LastLifeRegenerationTime");
            // Use TryParse com estilo RoundtripKind para garantir compatibilidade com ISO 8601
            if (!string.IsNullOrEmpty(lastRegenerationTimeStr) && DateTime.TryParse(lastRegenerationTimeStr, null, System.Globalization.DateTimeStyles.RoundtripKind, out DateTime lastRegenerationTime))
            {
                var currentLives = HttpContext.Session.GetInt32("UserLives") ?? 5;
                
                // Se já tem o máximo de vidas, apenas atualiza o timestamp para o momento atual se necessário
                if (currentLives >= 5)
                {
                    // Atualiza o timestamp apenas se ele for antigo, para evitar atualizações desnecessárias
                    if (lastRegenerationTime < DateTime.UtcNow.AddMinutes(-LifeRegenerationIntervalMinutes))
                    {
                         HttpContext.Session.SetString("LastLifeRegenerationTime", DateTime.UtcNow.ToString("o"));
                    }
                    return;
                }
                
                // Calcula quantas vidas devem ser regeneradas
                var elapsedMinutes = (DateTime.UtcNow - lastRegenerationTime).TotalMinutes;
                var livesToRegenerate = (int)(elapsedMinutes / LifeRegenerationIntervalMinutes);
                
                if (livesToRegenerate > 0)
                {
                    // Adiciona as vidas regeneradas (até o máximo de 5)
                    var newLives = Math.Min(currentLives + livesToRegenerate, 5);
                    HttpContext.Session.SetInt32("UserLives", newLives);
                    
                    // Atualiza o timestamp de regeneração para o momento da última regeneração efetiva
                    // Isso garante que o próximo ciclo de 5 minutos comece corretamente
                    var timeOfLastEffectiveRegen = lastRegenerationTime.AddMinutes(livesToRegenerate * LifeRegenerationIntervalMinutes);
                    HttpContext.Session.SetString("LastLifeRegenerationTime", timeOfLastEffectiveRegen.ToString("o"));
                }
            }
            else
            {
                // Se não há timestamp, define um agora (pode acontecer na primeira vez ou se a sessão for perdida)
                 HttpContext.Session.SetString("LastLifeRegenerationTime", DateTime.UtcNow.ToString("o"));
            }
        }
        
        // Método para decrementar vidas
        private bool DecrementarVida()
        {
            var currentLives = HttpContext.Session.GetInt32("UserLives") ?? 5;
            if (currentLives > 0)
            {
                // Se estava com vidas cheias, marca o início do tempo de regeneração
                if (currentLives == 5)
                {
                    HttpContext.Session.SetString("LastLifeRegenerationTime", DateTime.UtcNow.ToString("o"));
                }
                HttpContext.Session.SetInt32("UserLives", currentLives - 1);
                return true; // Ainda tem vidas
            }
            return false; // Sem vidas
        }

        // Método auxiliar para obter o ícone com base no ID da lição (NÃO MAIS USADO PARA FONT AWESOME)
        // Este método foi mantido caso seja usado em outro lugar para ícones de imagem, mas não é mais chamado pela action Trilhas para os ícones Font Awesome.
        private string GetIconForLicao(int licaoId)
        {
            // Mapeamento simples de ID para ícone de IMAGEM. Ajuste conforme necessário.
            switch (licaoId)
            {
                case 1: 
                    return "~/img/logica.png";
                case 2: 
                    return "~/img/html5.png";
                case 3: 
                    return "~/img/css3.png";
                case 4: 
                    return "~/img/react.png";
                default:
                    return "~/img/default_icon.png"; // Ícone padrão
            }
        }

        public IActionResult Trilhas()
        {
            // Verificar se o usuário está autenticado
            if (User.Identity.IsAuthenticated)
            {
                // Usuário logado - usar dados do Identity
                var userName = User.Identity.Name;
                ViewData["Nickname"] = userName;
                ViewData["IsAuthenticated"] = true;
            }
            else
            {
                // Usuário convidado - usar sistema de sessões
                var nickname = HttpContext.Session.GetString("UserNickname");
                if (string.IsNullOrEmpty(nickname))
                {
                    return RedirectToAction("Nickname");
                }
                ViewData["Nickname"] = nickname;
                ViewData["IsAuthenticated"] = false;
            }
            
            // Buscar as lições do módulo de Lógica de Programação (ModuloId = 1)
            // Inclui o campo Icon diretamente da entidade Licao
            var licoes = _context.Licaos
                                 .Where(l => l.ModuloId == 1)
                                 .Select(l => new {
                                     Id = l.Id,
                                     Nome = l.Titulo,
                                     Status = "unlocked", // Por padrão, todas as lições estão desbloqueadas
                                     Icon = l.Icon // Usa o campo Icon diretamente do banco de dados
                                 })
                                 .ToList();
            
            ViewData["LicoesLogica"] = licoes; // Passa a lista com os ícones do banco
            return View();
        }

        public IActionResult Questionario(int licaoId)
        {
            string nickname;
            bool isAuthenticated = User.Identity.IsAuthenticated;
            
            if (isAuthenticated)
            {
                // Usuário logado
                nickname = User.Identity.Name;
            }
            else
            {
                // Usuário convidado
                nickname = HttpContext.Session.GetString("UserNickname");
                if (string.IsNullOrEmpty(nickname))
                {
                    return RedirectToAction("Nickname");
                }
                
                // Verificar e regenerar vidas apenas para convidados
                RegenerarVidas();
                
                // Verificar se o usuário tem vidas suficientes
                var currentLives = HttpContext.Session.GetInt32("UserLives") ?? 5;
                if (currentLives <= 0)
                {
                    TempData["ErrorMessage"] = "Você não tem vidas suficientes para iniciar esta lição. Aguarde a regeneração de vidas.";
                    return RedirectToAction("Convidado");
                }
                ViewData["UserLives"] = currentLives;
            }

            var licaoAtual = _context.Licaos.FirstOrDefault(l => l.Id == licaoId);
            var questoesDaLicao = _context.Questaos.Where(q => q.LicaoId == licaoId).ToList();

            ViewData["Nickname"] = nickname;
            ViewData["IsAuthenticated"] = isAuthenticated;
            ViewData["LicaoId"] = licaoId;
            ViewData["NomeLicao"] = licaoAtual?.Titulo ?? "Lição Desconhecida";
            ViewData["Explicacao"] = licaoAtual?.Explicacao ?? "Explicação não disponível para esta lição.";
            ViewData["Questoes"] = questoesDaLicao;
            
            return View();
        }

        [HttpPost]
        public IActionResult ProcessarRespostas([FromBody] ConvidadoRankingInfo parametros)
        {
            Console.WriteLine(parametros.scoreObtido);
            
            bool isAuthenticated = User.Identity.IsAuthenticated;
            string nickname;
            
            if (isAuthenticated)
            {
                // Usuário logado - não usa sistema de vidas nem ranking
                nickname = User.Identity.Name;
                return Json(new { 
                    success = true, 
                    message = "Progresso salvo com sucesso!", 
                    isAuthenticated = true
                });
            }
            else
            {
                // Usuário convidado - usar sistema de sessões
                nickname = HttpContext.Session.GetString("UserNickname");
                if (string.IsNullOrEmpty(nickname))
                {
                    return Json(new { success = false, message = "Sessão expirada ou inválida." });
                }

                // Verificar e regenerar vidas antes de processar
                RegenerarVidas();

                var currentScore = HttpContext.Session.GetInt32("UserScore") ?? 0;
                var currentLessons = HttpContext.Session.GetInt32("UserCompletedLessons") ?? 0;
                var currentLives = HttpContext.Session.GetInt32("UserLives") ?? 5;

                currentScore += parametros.scoreObtido;
                currentLessons += 1;

                // Calcular quantas respostas erradas houve
                int totalQuestoes = parametros.totalQuestoes;
                int acertos = parametros.scoreObtido / 100; // Cada acerto vale 100 pontos
                int erros = totalQuestoes - acertos;
                
                // Decrementar vidas com base nos erros
                bool perdeuVida = false;
                if (erros > 0)
                {
                    int vidasAntes = currentLives;
                    int novasVidas = Math.Max(0, currentLives - erros);
                    if (novasVidas < vidasAntes) perdeuVida = true;
                    HttpContext.Session.SetInt32("UserLives", novasVidas);
                }

                // Se perdeu vida e estava com 5 vidas, marca o início da contagem
                if (perdeuVida && currentLives == 5)
                {
                     HttpContext.Session.SetString("LastLifeRegenerationTime", DateTime.UtcNow.ToString("o"));
                }

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

                // Incluir informações de vidas na resposta
                return Json(new { 
                    success = true, 
                    message = "Progresso salvo com sucesso!", 
                    currentLives = HttpContext.Session.GetInt32("UserLives") ?? 0,
                    isAuthenticated = false
                });
            }
        }
        
        public IActionResult Ranking()
        {
            ViewData["UserNickname"] = HttpContext.Session.GetString("UserNickname");
            ViewData["UserScore"] = HttpContext.Session.GetInt32("UserScore") ?? 0;
            ViewData["UserCompletedLessons"] = HttpContext.Session.GetInt32("UserCompletedLessons") ?? 0;

            var rankingParaView = new List<ConvidadoRankingInfo>(_convidadosRanking);
            
            if (!rankingParaView.Any(r => r.Nickname == "PlayerOne")) rankingParaView.Add(new ConvidadoRankingInfo { Nickname = "Admin", Score = 20000, CompletedLessons = 1000 });

            ViewData["RankingData"] = rankingParaView.OrderByDescending(r => r.Score).ToList();
            return View();
        }

        public IActionResult SairDaSessao()
        {
            HttpContext.Session.Remove("UserNickname");
            HttpContext.Session.Remove("SessionStartTime");
            HttpContext.Session.Remove("UserScore");
            HttpContext.Session.Remove("UserCompletedLessons");
            HttpContext.Session.Remove("UserLives");
            HttpContext.Session.Remove("LastLifeRegenerationTime");
            return RedirectToAction("Index");
        }

        public IActionResult ModulosLogado()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewData["Nickname"] = User.Identity.Name;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}