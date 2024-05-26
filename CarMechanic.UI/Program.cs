using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CarMechanic.UI;
using CarMechanic.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:8080") });
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IWorkService, WorkService>();
builder.Services.AddScoped<WorkEstimationService>();

await builder.Build().RunAsync();