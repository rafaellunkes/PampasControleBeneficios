using PampasControleBeneficios.Aplicacao.Extensions;
using PampasControleBeneficios.Infra.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, _) =>
    {
        document.Info.Title = "Projeto Benefícios";
        document.Info.Version = "v1";
        document.Info.Description = "API para gerenciamento de benefícios.";

        return Task.CompletedTask;
    });
});

// Add services to the container.

builder.Services.AddApplication();
builder.Services.AddInfra(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Projeto Benefícios";
        options.Theme = ScalarTheme.BluePlanet;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
