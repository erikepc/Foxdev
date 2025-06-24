using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Foxdev.Data;
using Foxdev.Models;

namespace Foxdev.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Usuario> _userManager;

        public AdminController(AppDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.TotalUsuarios = _context.Users.Count();
            ViewBag.TotalModulos = _context.Modulos.Count();
            ViewBag.TotalLicoes = _context.Licaos.Count();
            ViewBag.TotalQuestoes = _context.Questaos.Count();
            
            return View();
        }

        // CRUD Usuários
        public async Task<IActionResult> Usuarios()
        {
            var usuarios = await _context.Users.ToListAsync();
            return View(usuarios);
        }

        public IActionResult CriarUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario(Usuario usuario, string senha)
        {
            if (ModelState.IsValid)
            {
                usuario.UserName = usuario.Email;
                var result = await _userManager.CreateAsync(usuario, senha);
                
                if (result.Succeeded)
                {
                    TempData["Success"] = "Usuário criado com sucesso!";
                    return RedirectToAction("Usuarios");
                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            
            return View(usuario);
        }

        public async Task<IActionResult> EditarUsuario(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> EditarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByIdAsync(usuario.Id);
                if (existingUser != null)
                {
                    existingUser.Nome = usuario.Nome;
                    existingUser.Email = usuario.Email;
                    existingUser.UserName = usuario.Email;
                    existingUser.Idade = usuario.Idade;
                    existingUser.DataNascimento = usuario.DataNascimento;
                    existingUser.Descricao = usuario.Descricao;
                    
                    var result = await _userManager.UpdateAsync(existingUser);
                    
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Usuário atualizado com sucesso!";
                        return RedirectToAction("Usuarios");
                    }
                    
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> DeletarUsuario(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario != null)
            {
                var result = await _userManager.DeleteAsync(usuario);
                if (result.Succeeded)
                {
                    TempData["Success"] = "Usuário deletado com sucesso!";
                }
                else
                {
                    TempData["Error"] = "Erro ao deletar usuário.";
                }
            }
            
            return RedirectToAction("Usuarios");
        }

        // CRUD Módulos
        public async Task<IActionResult> Modulos()
        {
            var modulos = await _context.Modulos.Include(m => m.Licoes).ToListAsync();
            return View(modulos);
        }

        public IActionResult CriarModulo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarModulo(Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                _context.Modulos.Add(modulo);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Módulo criado com sucesso!";
                return RedirectToAction("Modulos");
            }
            
            return View(modulo);
        }

        public async Task<IActionResult> EditarModulo(int id)
        {
            var modulo = await _context.Modulos.FindAsync(id);
            if (modulo == null)
            {
                return NotFound();
            }
            
            return View(modulo);
        }

        [HttpPost]
        public async Task<IActionResult> EditarModulo(Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                _context.Modulos.Update(modulo);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Módulo atualizado com sucesso!";
                return RedirectToAction("Modulos");
            }
            
            return View(modulo);
        }

        [HttpPost]
        public async Task<IActionResult> DeletarModulo(int id)
        {
            var modulo = await _context.Modulos.FindAsync(id);
            if (modulo != null)
            {
                _context.Modulos.Remove(modulo);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Módulo deletado com sucesso!";
            }
            
            return RedirectToAction("Modulos");
        }

        // CRUD Lições
        public async Task<IActionResult> Licoes()
        {
            var licoes = await _context.Licaos.Include(l => l.Modulo).ToListAsync();
            return View(licoes);
        }

        public async Task<IActionResult> CriarLicao()
        {
            ViewBag.Modulos = await _context.Modulos.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarLicao(Licao licao)
        {
            if (ModelState.IsValid)
            {
                _context.Licaos.Add(licao);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Lição criada com sucesso!";
                return RedirectToAction("Licoes");
            }
            
            ViewBag.Modulos = await _context.Modulos.ToListAsync();
            return View(licao);
        }

        public async Task<IActionResult> EditarLicao(int id)
        {
            var licao = await _context.Licaos.FindAsync(id);
            if (licao == null)
            {
                return NotFound();
            }
            
            ViewBag.Modulos = await _context.Modulos.ToListAsync();
            return View(licao);
        }

        [HttpPost]
        public async Task<IActionResult> EditarLicao(Licao licao)
        {
            if (ModelState.IsValid)
            {
                _context.Licaos.Update(licao);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Lição atualizada com sucesso!";
                return RedirectToAction("Licoes");
            }
            
            ViewBag.Modulos = await _context.Modulos.ToListAsync();
            return View(licao);
        }

        [HttpPost]
        public async Task<IActionResult> DeletarLicao(int id)
        {
            var licao = await _context.Licaos.FindAsync(id);
            if (licao != null)
            {
                _context.Licaos.Remove(licao);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Lição deletada com sucesso!";
            }
            
            return RedirectToAction("Licoes");
        }

        // CRUD Questões
        public async Task<IActionResult> Questoes()
        {
            var questoes = await _context.Questaos.Include(q => q.Licao).ThenInclude(l => l.Modulo).ToListAsync();
            return View(questoes);
        }

        public async Task<IActionResult> CriarQuestao()
        {
            ViewBag.Licoes = await _context.Licaos.Include(l => l.Modulo).ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarQuestao(Questao questao)
        {
            if (ModelState.IsValid)
            {
                _context.Questaos.Add(questao);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Questão criada com sucesso!";
                return RedirectToAction("Questoes");
            }
            
            ViewBag.Licoes = await _context.Licaos.Include(l => l.Modulo).ToListAsync();
            return View(questao);
        }

        public async Task<IActionResult> EditarQuestao(int id)
        {
            var questao = await _context.Questaos.FindAsync(id);
            if (questao == null)
            {
                return NotFound();
            }
            
            ViewBag.Licoes = await _context.Licaos.Include(l => l.Modulo).ToListAsync();
            return View(questao);
        }

        [HttpPost]
        public async Task<IActionResult> EditarQuestao(Questao questao)
        {
            if (ModelState.IsValid)
            {
                _context.Questaos.Update(questao);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Questão atualizada com sucesso!";
                return RedirectToAction("Questoes");
            }
            
            ViewBag.Licoes = await _context.Licaos.Include(l => l.Modulo).ToListAsync();
            return View(questao);
        }

        [HttpPost]
        public async Task<IActionResult> DeletarQuestao(int id)
        {
            var questao = await _context.Questaos.FindAsync(id);
            if (questao != null)
            {
                _context.Questaos.Remove(questao);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Questão deletada com sucesso!";
            }
            
            return RedirectToAction("Questoes");
        }
    }
}

