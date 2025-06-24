using Microsoft.EntityFrameworkCore;
using Foxdev.Models;
using Microsoft.AspNetCore.Identity;
using Foxdev.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddDistributedMemoryCache();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
});


string conexao = builder.Configuration.GetConnectionString("FoxdevConn");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(conexao)
);



builder.Services.AddIdentity<Usuario, IdentityRole>(
    options => options.SignIn.RequireConfirmedEmail = false
).AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await context.Database.EnsureCreatedAsync();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    // Criar role Admin se não existir
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    // Verificar se já existe um usuário admin
    var adminUser = await userManager.FindByEmailAsync("admin@foxdev.com");
    if (adminUser == null)
    {
        var user = new Usuario
        {
            UserName = "admin@foxdev.com",
            Email = "admin@foxdev.com",
            Nome = "Administrador",
            Idade = 30,
            DataNascimento = new DateTime(1994, 1, 1),
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, "Admin123!");
        
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseSession();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
