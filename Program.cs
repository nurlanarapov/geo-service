using geo_service.Extensions;
using geo_service.Middlewares;
using geo_service.Services;
using geo_service.Services.Clients.DaDataClient;
using geo_service.Services.Clients.OpenStreetMapClient;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
config.SetBasePath(Path.GetDirectoryName(path: Assembly.GetEntryAssembly().Location));

// Add services to the container.
builder.Services.AddLogger(config, builder.Logging); 
builder.Services.AddHttpClient<OpenStreetMapClient>(httpClient => {
    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
    httpClient.BaseAddress = new Uri(config.GetValue<string>("httpClients:OpenStreetMapClient"));
});
builder.Services.AddHttpClient<DaDataClient>(httpClient => {
    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
    httpClient.BaseAddress = new Uri(config.GetValue<string>("httpClients:dadata:url"));
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.GetValue<string>("httpClients:dadata:access_token"));
});

builder.Services.AddScoped<IGeoCodingService, GeoCodingService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
