using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MinimalContextDb>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MinimalApi v1"));
   
}

app.MapGet("/fornecedor", async (MinimalContextDb context) =>
{
    var fornecedores = await context.Fornecedores.ToListAsync();
    return Results.Ok(fornecedores);
}).Produces<List<Fornecedor>>(StatusCodes.Status200OK)
.WithName("GetFornecedores").WithTags("Fornecedores");

app.MapGet("/fornecedor/{id}", async (MinimalContextDb context, Guid id) =>
{
    var fornecedor = await context.Fornecedores.FindAsync(id);
    if (fornecedor == null)
        return Results.NotFound();

    return Results.Ok(fornecedor);
}).Produces<Fornecedor>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithName("GetFornecedor").WithTags("Fornecedores");

app.MapPost("/fornecedor", async (MinimalContextDb context, Fornecedor fornecedor) =>
{
    fornecedor.Id = Guid.NewGuid();
    context.Fornecedores.Add(fornecedor);
    await context.SaveChangesAsync();
    return Results.Created($"/fornecedor/{fornecedor.Id}", fornecedor);
}).Produces<Fornecedor>(StatusCodes.Status201Created)
.WithName("PostFornecedor").WithTags("Fornecedores");

app.Run();
