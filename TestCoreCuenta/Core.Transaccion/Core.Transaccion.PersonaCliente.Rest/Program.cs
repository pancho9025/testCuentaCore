using Core.Transaccion.Application.Contracts.Persintence;
using Core.Transaccion.Application.Feautures.Cliente.Command.CrearCliente;
using Core.Transaccion.Application.Shared;
using Core.Transaccion.Domain.Entities.Cliente;
using Core.Transaccion.Infrastructure.Context;
using Core.Transaccion.Infrastructure.Repositories.Cliente;
using Core.Transaccion.Infrastructure.Repositories.Cuenta;
using Core.Transaccion.Infrastructure.Repositories.Movimiento;
using Core.Transaccion.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDbContext<CoreCuentaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CoreCuentaConnectionString")),
    ServiceLifetime.Transient);

builder.Services.AddScoped<ITransaccionUnitOfWork, TransaccionUnitOfWorkRepository>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<ICuentaRepository, CuentaRepository>();

builder.Services.AddScoped<IMovimientoRepository, MovimientoRepository>();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
