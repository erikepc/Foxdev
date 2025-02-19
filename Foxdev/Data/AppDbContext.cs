using Foxdev.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Foxdev.Data;


public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }

    public DbSet<Modulo> Modulos { get; set; }
    public DbSet<Licao> Licaos { get; set; }
    public DbSet<Questao> Questaos { get; set; }
   
}