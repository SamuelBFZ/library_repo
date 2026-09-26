using sb.api.Library.Application;
using sb.api.Library.Persistence;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

await DatabaseInitializer.MigrateAndSeedAsync(app.Services);

app.UseHttpsRedirection();

app.Run();
