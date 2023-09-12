using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SendMail.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<MailService>();
builder.Services.AddHttpClient<MailService>(client =>
 client.BaseAddress = new Uri(builder.Configuration["webapi"]));

await builder.Build().RunAsync();
