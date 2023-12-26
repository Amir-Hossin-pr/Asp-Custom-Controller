using Identity.Client.Consumer;
using Identity.Client.Model;
using Identity.Client.StartUp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFteamIdentityService();
builder.Services.AddFteamIdentityLives<IdentityConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();

public class IdentityConsumer : IIdentityConsumer
{
    public Task OnInviteAsync(User login, User caller)
    {
        throw new NotImplementedException();
    }

    public Task OnUserLoginAsync(User user)
    {
        throw new NotImplementedException();
    }
}