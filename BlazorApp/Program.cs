using BlazorApp;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add Http Service
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://api.escuelajs.co/") });
builder.Services.AddScoped<IUserService, UserService>();

await builder.Build().RunAsync();
