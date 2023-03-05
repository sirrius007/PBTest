using DataAccess;
using PBTestAPI;
using PBTestServices;
using Common.JWTAuth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddJWTAuth();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseJWTAuth();

app.ConfigureApi();

app.Run();