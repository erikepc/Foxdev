using Foxdev.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Foxdev.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Modulo> Modulos { get; set; }
    public DbSet<Licao> Licaos { get; set; }
    public DbSet<Questao> Questaos { get; set; }
    public DbSet<UserProgress> UserProgress { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Configuração do Identity
        builder.Entity<Usuario>().ToTable("usuario");
        builder.Entity<IdentityRole>().ToTable("perfil");
        builder.Entity<IdentityUserRole<string>>().ToTable("usuario_perfil");
        builder.Entity<IdentityUserToken<string>>().ToTable("usuario_token");
        builder.Entity<IdentityUserClaim<string>>().ToTable("usuario_regra");
        builder.Entity<IdentityUserLogin<string>>().ToTable("usuario_login");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("perfil_regra");
        #endregion

        #region Configurações Customizadas
        // Conversão de Respostas para JSON
        builder.Entity<Questao>()
            .Property(q => q.Respostas)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v) ?? new List<string>());

        // Relacionamentos
        builder.Entity<Licao>()
            .HasOne(l => l.Modulo)
            .WithMany(m => m.Licoes)
            .HasForeignKey(l => l.ModuloId);

        builder.Entity<UserProgress>()
            .HasOne(up => up.User)
            .WithMany(u => u.Progressos)
            .HasForeignKey(up => up.UserId);

        builder.Entity<UserProgress>()
            .HasIndex(up => new { up.UserId, up.LicaoId })
            .IsUnique();
        #endregion

        new AppDbSeed(builder).Seed();
    }
}