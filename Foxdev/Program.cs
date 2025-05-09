using Microsoft.EntityFrameworkCore;
using Foxdev.Models;
using Microsoft.AspNetCore.Identity;
using Foxdev.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adicionar serviços de cache distribuído em memória (necessário para sessão em memória)
builder.Services.AddDistributedMemoryCache();

// Adicionar serviços de sessão
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Define o tempo limite da sessão
    options.Cookie.HttpOnly = true; // Torna o cookie de sessão acessível apenas por HTTP
    options.Cookie.IsEssential = true; // Marca o cookie de sessão como essencial para o GDPR
});

// Conexão com o banco de dados
string conexao = builder.Configuration.GetConnectionString("FoxdevConn");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(conexao)
);


// Configuração do Identity
builder.Services.AddIdentity<Usuario, IdentityRole>(
    options => options.SignIn.RequireConfirmedEmail = false
).AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var contexto = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await contexto.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Adicionar o middleware de sessão ao pipeline ANTES de UseRouting e UseAuthorization
app.UseSession();

app.UseRouting();

app.UseAuthentication(); // Adicionado para garantir que a autenticação Identity funcione corretamente com a sessão
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
