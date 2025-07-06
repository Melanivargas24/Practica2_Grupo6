using EmpresaVBLL.Servicios.Cliente;
using EmpresaVBLL.Servicios.Telefono;
using EmpresaVDAL;
using EmpresaVDAL.Repositorios.Cliente;
using EmpresaVDAL.Repositorios.Telefono;
using Microsoft.EntityFrameworkCore;
using EmpresaVObjetos.Mapping;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmpresaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<ITelefonoRepositorio, TelefonoRepositorio>();

builder.Services.AddScoped<IClienteServicio, ClienteServicio>();
builder.Services.AddScoped<ITelefonoServicio, TelefonoServicio>();



// Replace the problematic line with the correct usage
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();


app.Run();