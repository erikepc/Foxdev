using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Foxdev.Data;
using Foxdev.Models;
using System.Security.Claims;

namespace Foxdev.Controllers;

[Authorize]
public class LearningController : Controller
{
    private readonly AppDbContext _context;
    private const int MaxVidas = 3;

    public LearningController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Learning
    public async Task<IActionResult> Index()
    {
        var modulos = await _context.Modulos
            .Include(m => m.Licoes)
            .ToListAsync();

        return View(modulos);
    }

    // GET: Learning/Licoes/1
    public async Task<IActionResult> Licoes(int moduloId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var modulo = await _context.Modulos
            .Include(m => m.Licoes)
            .FirstOrDefaultAsync(m => m.Id == moduloId);

        if (modulo == null) return NotFound();

        // Verificar progresso
        foreach (var licao in modulo.Licoes)
        {
            var progresso = await _context.UserProgress
                .FirstOrDefaultAsync(up => up.UserId == userId && up.LicaoId == licao.Id);

            if (progresso == null && licao.Id == modulo.Licoes.Min(l => l.Id))
            {
                // Desbloquear primeira lição
                _context.UserProgress.Add(new UserProgress
                {
                    UserId = userId,
                    LicaoId = licao.Id,
                    Desbloqueada = true,
                    Vidas = MaxVidas
                });
            }
        }
        await _context.SaveChangesAsync();

        return View(modulo);
    }

    // GET: Learning/Questoes/1
    public async Task<IActionResult> Questoes(int licaoId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var progresso = await _context.UserProgress
            .FirstOrDefaultAsync(up => up.UserId == userId && up.LicaoId == licaoId);

        if (progresso == null || !progresso.Desbloqueada || progresso.Vidas < 1)
            return RedirectToAction("Licoes", new { moduloId = progresso?.Licao.ModuloId });

        var licao = await _context.Licaos
            .Include(l => l.Questoes)
            .FirstOrDefaultAsync(l => l.Id == licaoId);

        return View(licao);
    }

    [HttpPost]
    public async Task<IActionResult> VerificarResposta(int licaoId, int respostaIndex)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var progresso = await _context.UserProgress
            .Include(up => up.Licao)
            .FirstOrDefaultAsync(up => up.UserId == userId && up.LicaoId == licaoId);

        if (progresso == null || progresso.Vidas < 1)
            return RedirectToAction("Licoes", new { moduloId = progresso?.Licao.ModuloId });

        var questao = await _context.Questaos
            .FirstOrDefaultAsync(q => q.LicaoId == licaoId);

        bool correta = questao?.RespostaCorreta == respostaIndex;

        if (correta)
        {
            progresso.Concluida = true;
            await DesbloquearProximaLicao(licaoId, userId);
        }
        else
        {
            progresso.Vidas--;
            progresso.UltimaTentativa = DateTime.UtcNow;
        }

        _context.Update(progresso);
        await _context.SaveChangesAsync();

        return RedirectToAction("Resultado", new { 
            sucesso = correta, 
            vidas = progresso.Vidas 
        });
    }

    private async Task DesbloquearProximaLicao(int licaoIdAtual, string userId)
    {
        var licaoAtual = await _context.Licaos.FindAsync(licaoIdAtual);
        var proximaLicao = await _context.Licaos
            .Where(l => l.ModuloId == licaoAtual.ModuloId && l.Id > licaoIdAtual)
            .OrderBy(l => l.Id)
            .FirstOrDefaultAsync();

        if (proximaLicao != null)
        {
            var novoProgresso = new UserProgress
            {
                UserId = userId,
                LicaoId = proximaLicao.Id,
                Desbloqueada = true,
                Vidas = MaxVidas
            };
            _context.UserProgress.Add(novoProgresso);
            await _context.SaveChangesAsync();
        }
    }
}