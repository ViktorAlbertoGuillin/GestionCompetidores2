using GestionCompetidores.Data;
using GestionCompetidores.Data.EF;
using GestionCompetidores.Data.Interface;
using GestionCompetidores.Servicio;
using GestionCompetidores.Servicio.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<GestionCompetidoresContext>();
builder.Services.AddScoped<IRepositorio, Repositorio>();
builder.Services.AddScoped<ICompetidorServicio, CompetidorServicio>();
builder.Services.AddScoped<IDeporteServicio, DeporteServicio>();

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
