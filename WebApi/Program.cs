using LogicaConexion.EntityFramework;
using Microsoft.EntityFrameworkCore;
using LogicaAplicacion.CasosDeUso.Usuarios;
using LogicaAplicacion.CasosDeUso.Tipos;
using LogicaAplicacion.CasosDeUso.Cabanas;
using LogicaAplicacion.CasosDeUso.Mantenimientos;
using System.Text.Json.Serialization;
using AutoMapper;
using WebApi.Mapper;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApi.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.WebSockets;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(
    option =>
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );



var mapper = new MapperConfiguration(option => option.AddProfile(new MapperProfile()));
builder.Services.AddSingleton(mapper.CreateMapper());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "ToDo API",
            Description = "An ASP.NET Core Web API for managing ToDo items",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "Shayne Boyer",
                Email = string.Empty,
                Url = new Uri("https://twitter.com/spboyer"),
            },
        });
        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    }

);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

///<summary> Configuración de autenticación jwtToken</summary>
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("jwTokenConfig.json")
                .Build();

    var secretKey = configuration.GetSection("JwtSettings:SecretKey").Value;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "Obligatorio2P3",
        ValidAudience = "localHost",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});




///<summary>
///</summary>
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(
    option =>
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//LogicaConexion Context
builder.Services.AddDbContext<HotelContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("conexionHotel"))
);

//LogicaConexion Repositorios
builder.Services.AddScoped<RepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<RepositorioTipo, RepositorioTipo>();
builder.Services.AddScoped<RepositorioMantenimiento, RepositorioMantenimiento>();
builder.Services.AddScoped<RepositorioCabana, RepositorioCabana>();

//LogicaAplicacion
//LogicaAplicacion Usuarios
builder.Services.AddScoped<AltaUsuarios, AltaUsuarios>();
builder.Services.AddScoped<EliminarUsuarios, EliminarUsuarios>();
builder.Services.AddScoped<InicioSesion, InicioSesion>();
//builder.Services.AddScoped<ObtenerListaUsuarios, ObtenerListaUsuarios>();
//builder.Services.AddScoped<ObtenerUsuarios, ObtenerUsuarios>();
builder.Services.AddScoped<JWToken, JWToken>();

//LogicaAplicacion Tipos
builder.Services.AddScoped<AltaTipos, AltaTipos>();
builder.Services.AddScoped<EliminarTipos, EliminarTipos>();
builder.Services.AddScoped<EncontrarTipo, EncontrarTipo>();
builder.Services.AddScoped<ListarPorNombre, ListarPorNombre>();
builder.Services.AddScoped<ListarTiposTodos, ListarTiposTodos>();
builder.Services.AddScoped<ModificarTipos, ModificarTipos>();
builder.Services.AddScoped<ObtenerCostoPorPersona, ObtenerCostoPorPersona>();
//LogicaAplicacion Mantenimientos
builder.Services.AddScoped<GetBetweenDates, GetBetweenDates>();
builder.Services.AddScoped<AltaMantenimiento, AltaMantenimiento>();
builder.Services.AddScoped<GetAll,GetAll>();
builder.Services.AddScoped<MantenimientoCabanaId,MantenimientoCabanaId>();
builder.Services.AddScoped<GetLastId,GetLastId>();
builder.Services.AddScoped<VerificarMantenimiento,VerificarMantenimiento>();
builder.Services.AddScoped<MantenimientoEntreCostos,MantenimientoEntreCostos>();

//LogicaAplicacion Cabanas
builder.Services.AddScoped<AltaCabanas, AltaCabanas>();
builder.Services.AddScoped<BuscarNumeroHabitacion, BuscarNumeroHabitacion>();
builder.Services.AddScoped<BuscarTipoCabana, BuscarTipoCabana>();
builder.Services.AddScoped<ListaCabanaPorAlquiler, ListaCabanaPorAlquiler>();
builder.Services.AddScoped<ListaCabanaPorNombre, ListaCabanaPorNombre>();
builder.Services.AddScoped<ListaPorNumeroPersonas, ListaPorNumeroPersonas>();
builder.Services.AddScoped<ListarCabanaPorTipo, ListarCabanaPorTipo>();
builder.Services.AddScoped<ListarCabanasTodas, ListarCabanasTodas>();
builder.Services.AddScoped<Ultimo_Id, Ultimo_Id>();

//


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
