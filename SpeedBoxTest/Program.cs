using IdentityModel.Client;
using SpeedBoxTest.CdekApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAccessTokenManagement(options =>
{
    options.Client.Clients.Add(nameof(CdekService), new ClientCredentialsTokenRequest
    {
        Address = "https://api.edu.cdek.ru/v2/oath/token",
        ClientId = "EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI",
        ClientSecret = "PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG",
    });
});
builder.Services.AddClientAccessTokenHttpClient(nameof(CdekService), nameof(CdekService), client =>
{
    client.BaseAddress = new Uri("https://api.edu.cdek.ru/v2/");
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
