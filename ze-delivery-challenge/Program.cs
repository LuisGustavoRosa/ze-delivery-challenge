using Microsoft.EntityFrameworkCore;
using ze_delivery_challenge.Application.Services;
using ze_delivery_challenge.Domain.Interfaces;
using ze_delivery_challenge.Infra;
using ze_delivery_challenge.Infra.Repositories;
using ze_delivery_challenge.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Context>((options) => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPartnerService, PartnerService>();
builder.Services.AddScoped<IPartnerRepository, PartnerRepository>();

var app = builder.Build();

var m_Database = app.Services.CreateScope().ServiceProvider.GetRequiredService<Context>().Database;
m_Database.Migrate();


app.UseSwagger();
app.UseSwaggerUI();


app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
