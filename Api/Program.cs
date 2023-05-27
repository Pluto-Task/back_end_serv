
using Api.Configuration;
using Api.Middlewares;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure()
    .AddApplication()
    .AddDatabase(builder.Configuration)
    .AddPresentation()
    .AddAuthenticationAndAuthorization();

builder.Services.AddTransient<GlobalExceptionHandlingException>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseMiddleware<GlobalExceptionHandlingException>();

app.MapControllers();

app.MigrateDatabase();
app.UseSeedData();

app.Run();
