using DostavaHrane.Data;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IAdresaRepozitorijum, AdresaRepozitorijum>();
builder.Services.AddScoped<IAdresaServis, AdresaServis>();

builder.Services.AddScoped<IMusterijaRepozitorijum, MusterijaRepozitorijum>();
builder.Services.AddScoped<IMusterijaServis, MusterijaServis>();

builder.Services.AddScoped<IJeloRepozitorijum, JeloRepozitorijum>();
builder.Services.AddScoped<IJeloServis, JeloServis>();

builder.Services.AddScoped<IRestoranRepozitorijum, RestoranRepozitorijum>();
builder.Services.AddScoped<IRestoranServis, RestoranServis>();

builder.Services.AddScoped<INarudzbinaRepozitorijum, NarudzbinaRepozitorijum>();
builder.Services.AddScoped<INarudzbinaServis, NarudzbinaServis>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowAll");

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
