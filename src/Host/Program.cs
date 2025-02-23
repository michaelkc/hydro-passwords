using Hydro.Configuration;
using Host.Utils;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddHostedService<TailwindHostedService>();
}

builder.Services.AddRazorPages();
builder.Services.AddHydro();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.UseHydro(builder.Environment);

app.Run();
