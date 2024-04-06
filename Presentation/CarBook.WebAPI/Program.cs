using Autofac.Extensions.DependencyInjection;
using Autofac;
using CarBook.Persistence.IoC.DependencyInjection;
using CarBook.Application.Services;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using CarBook.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CarBookCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarBookContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("CarBookDatabase"));
});

//Add Identity
builder.Services.AddIdentityEx();

//Config Identity
builder.Services.ConfigIdentityEx();

//Add Auth and Jwt Bearer
builder.Services.AddAuthAndJwtBearerEx(builder.Configuration);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddApplicationService(builder.Configuration);
// Configure Autofac container
builder.Host.ConfigureContainer<ContainerBuilder>(
    builder =>
    {
        builder.RegisterModule(new AutofacApplicationModule());
        builder.RegisterModule(new AutofacPersistanceModule());
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseCors("CarBookCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
