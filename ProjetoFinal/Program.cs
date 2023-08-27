using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("pt-BR"),
    SupportedCultures = new[] { new CultureInfo("pt-BR") },
    SupportedUICultures = new[] { new CultureInfo("pt-BR") },
    RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new CustomRequestCultureProvider(async context =>
        {
            return await Task.FromResult(new ProviderCultureResult("pt-BR"));
        })
    }
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
