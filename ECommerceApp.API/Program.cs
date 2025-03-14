var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructureServices(builder.Configuration)
    .AddApplicationServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureSwagger();

builder.Services.AddAppCors();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseMiddleware<AuthMiddleware>();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();

try
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();

    await DbSeeder.SeedData(dbContext);
}
catch (Exception ex)
{
    //TODO: use serilog to log the errors here
    throw;
}

app.Run();
