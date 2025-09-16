using Microsoft.EntityFrameworkCore;
using proyectoWebApi.DataLayer;
using proyectoWebApi.DataLayer.Dapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<WebApiContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("connectionDB")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "angular", build =>
    {
        build.AllowAnyOrigin();//"https://localhost:4200");
        build.AllowAnyMethod();//"PUT", "POST", "GET", "DELETE");
        build.AllowAnyHeader();
    }
                );
}
                        );

var app = builder.Build();

app.UseCors("angular");

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
