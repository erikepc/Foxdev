using Foxdev.Models;
using FoxDev.Models;
using Microsoft.AspNetCore.Identity;
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
    public DbSet<Usuario> Usuarios { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        #region  Renomeação das tabelas do Identity
        builder.Entity<Usuario>().ToTable("usuario");
        builder.Entity<IdentityRole>().ToTable("perfil");
        builder.Entity<IdentityUserRole<string>>().ToTable("usuario_perfil");
        builder.Entity<IdentityUserToken<string>>().ToTable("usuario_token");
        builder.Entity<IdentityUserClaim<string>>().ToTable("usuario_regra");
        builder.Entity<IdentityUserLogin<string>>().ToTable("usuario_login");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("perfil_regra");
        #endregion

        #region popular Modulo
        List<Modulo> modulos = new()
        {
            new Modulo()
            {
                Id = 1,
                Titulo = "Lógica de Programação"
            },
            
        };
        builder.Entity<Modulo>().HasData(modulos);
        #endregion

        #region Lição
        List<Licao> licaos = new()
        {
            new Licao()
            {
            Id = 1,
            Titulo = "Introdução a Lógica de Programação",
            ModuloId = 1,
            }
        };
        builder.Entity<Licao>().HasData(licaos);
        #endregion

        #region Questões
        List<Questao> questaos = new()
        {
            new Questao()
            {
            Id = 1,
            Conteudo = "Qual comando faz aparecer textos no console?",
            Tipo = 0,
            AlternativaA = "Console.write",
            AlternativaB = "Console.log",
            AlternativaC = "Alert('')",
            AlternativaD = "Console.lead",
            RespostaCorreta = 1,
            CodeSnippet = "",
            LicaoId = 1,
            }
        };
        builder.Entity<Questao>().HasData(questaos);
        #endregion

        #region Usuario
        List<Usuario> usuarios = new()
        {
            new Usuario()
            {
                Id = "264f9ee9-055f-48dd-96e8-b0e53751951f",
                UserName = "Usuario1",
                NormalizedUserName = "USUARIO1",
                Email = "erike.cordeiro7@gmail.com",
                NormalizedEmail = "ERIKE.CORDEIRO7@GMAIL.COM",
                EmailConfirmed = true,
                Nome = "Usuario Teste",
                Idade = 22,
            }

        };
        foreach (Usuario usuario in usuarios)
        {
            PasswordHasher<Usuario> password = new();
            usuario.PasswordHash = password.HashPassword(usuario, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Perfil
        List<IdentityRole> perfis = new()
        {
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Funcionário",
                NormalizedName = "FUNCIONÁRIO"
            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Cliente",
                NormalizedName = "CLIENTE"
            }
        };
        builder.Entity<IdentityRole>().HasData(perfis);
        #endregion

        #region Usuário Perfil
        List<IdentityUserRole<string>> usuarioPerfis = new()
        {
            new IdentityUserRole<string>()
            {
                UserId = usuarios[0].Id,
                RoleId = perfis[0].Id,
            },
            new IdentityUserRole<string>()
            {
                UserId = usuarios[0].Id,
                RoleId = perfis[1].Id,
            },
            new IdentityUserRole<string>()
            {
                UserId = usuarios[0].Id,
                RoleId = perfis[2].Id,
            },
        };
        builder.Entity<IdentityUserRole<string>>().HasData(usuarioPerfis);
        #endregion
    }



}