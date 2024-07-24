using Microsoft.EntityFrameworkCore;
using FuncionarioApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddDbContext<FuncionarioContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("FuncionarioDb"),
        new MySqlServerVersion(new Version(8, 0, 25))));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
