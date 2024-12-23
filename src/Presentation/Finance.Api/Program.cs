using Finance.Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

await MigrateDatabase(app);

app.Run();

async Task MigrateDatabase(WebApplication app)
{
    await using var scope = app.Services.CreateAsyncScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<FinanceTrackerDbContext>();
    await dbContext.Database.MigrateAsync();
}