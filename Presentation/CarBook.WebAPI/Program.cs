using Autofac.Extensions.DependencyInjection;
using Autofac;
using CarBook.Persistence.IoC.DependencyInjection;
using CarBook.Application.Services;

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

app.UseCors("CarBookCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
