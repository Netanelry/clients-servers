using MongoDB.Driver;
using WebApplication3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// <summary>
/// Boydem 
/// </summary>

// Save mongo client to boydem
string mongoUri = builder.Configuration["MongoUri"];
string mongoSecret = builder.Configuration["MongoSecret"];
string mongoConnectionString = $"mongodb://{mongoSecret}@{mongoUri}";

MongoClient mc = new MongoClient(mongoConnectionString);

// Save dal to boydem
Dal dal = new Dal(mc);
Dal2 dal2 = Dal2.GetInstance();

builder.Services.AddSingleton<Dal>(dal);
builder.Services.AddSingleton<Dal2>(dal2);

builder.Services.AddSingleton<MongoClient>(mc);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
