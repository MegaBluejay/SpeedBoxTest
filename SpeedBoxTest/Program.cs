using Flurl.Http;
using Flurl.Serialization.TextJson;
using IdentityModel.Client;
using SpeedBoxTest.CdekApi;

FlurlHttp.Configure(settings =>
    settings.WithTextJsonSerializer());

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddClientAccessTokenManagement(options =>
{
    options.Clients.Add(nameof(CdekService), new ClientCredentialsTokenRequest
    {
        Address = $"{builder.Configuration.GetValue<string>("Cdek:BaseUrl")}/oauth/token",
        ClientId = builder.Configuration.GetValue<string>("Cdek:ClientId"),
        ClientSecret =builder.Configuration.GetValue<string>("Cdek:ClientSecret") 
    });
});
builder.Services.AddClientAccessTokenHttpClient(nameof(CdekService), nameof(CdekService), client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("Cdek:BaseUrl")!);
});
builder.Services.AddScoped<ICdekService, CdekService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
