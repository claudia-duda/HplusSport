using HplusSport.IdentityServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
     .AddInMemoryApiResources(Config.Apis)
     .AddInMemoryClients(Config.Clients)
     .AddInMemoryApiScopes(Config.Scopes);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseRouting();
app.UseIdentityServer();
app.MapGet("/", () => "Hello World!");

app.Run();
