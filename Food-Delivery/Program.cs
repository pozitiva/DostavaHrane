using DostavaHrane.Data;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
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

builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = false,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "static")),
    RequestPath = "/static"
});

app.UseCors("AllowAll");

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();