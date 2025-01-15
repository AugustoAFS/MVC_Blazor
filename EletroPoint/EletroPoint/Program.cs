using EletroPoint.Components;
using EletroPoint.data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Verifica se a BaseAddress está configurada corretamente
var baseAddress = builder.Configuration.GetValue<string>("BaseAddress");

if (string.IsNullOrEmpty(baseAddress))
{
    throw new InvalidOperationException("A BaseAddress não foi configurada corretamente.");
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

// Configura o DbContext com a string de conexão
builder.Services.AddDbContext<EletroPointDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Registra os controladores da API
builder.Services.AddControllers();

// Adiciona Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configura o pipeline de requisições
app.UseRouting();

// Registra as rotas dos controladores da API
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(EletroPoint.Client._Imports).Assembly);

app.Run();
