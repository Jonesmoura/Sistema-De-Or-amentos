using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using SistemaOrc.Context;
using SistemaOrc.Repositories;
using SistemaOrc.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IClienteRepository,ClienteReposity>();
builder.Services.AddTransient<IOrcamentoRepository,OrcamentoRepository>();
builder.Services.AddTransient<IServicoRepository,ServicoRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
