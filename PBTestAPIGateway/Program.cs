using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using PBTestAPIGateway.BackgroundService;
using PBTestAPIGateway.Middleware;
using static PBTestAPIGateway.SharedConstants;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddJsonFile(OcelotFile, false, true);
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddSwaggerForOcelot(builder.Configuration);
builder.Services.AddHttpClient();
builder.Services.AddJwtBackgoundService();
builder.Services.AddMemoryCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerForOcelotUI(opt => opt.PathToSwaggerGenerator = "/swagger/docs");
}

app.AddJwtPersistance();

app.UseOcelot().Wait();

app.Run();