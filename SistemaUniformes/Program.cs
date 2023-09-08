using Microsoft.AspNetCore.Localization;
using SistemaUniformes.Business;
using SistemaUniformes.Data;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAccessInfo, AccessInfo>();
builder.Services.AddTransient<IUpdateInfo, UpdateInfo>();
builder.Services.AddTransient<IDeleteInfo, DeleteInfo>();
builder.Services.AddTransient<IAddInfo, AddInfo>();
builder.Services.AddDbContext<Context>();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


builder.Services.AddControllersWithViews();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("es-MX"); // Cultura para México
    options.SupportedCultures = new[] { new CultureInfo("es-MX") }; // Cultura para México
    options.SupportedUICultures = new[] { new CultureInfo("es-MX") }; // Cultura para México
    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
