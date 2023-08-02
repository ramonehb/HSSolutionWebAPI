using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using HSSolution.Application;
using HSSolution.Application.Interfaces;
using HSSolution.Persistence;
using HSSolution.Persistence.Context;
using HSSolution.Persistence.Interfaces;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region Application
builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();
builder.Services.AddScoped<IAutenticacaoApplication, AutenticacaoApplication>();
builder.Services.AddScoped<IPerfilApplitcation, PerfilApplication>();
#endregion

#region Persist
builder.Services.AddScoped<IUsuarioPersist, UsuarioPersist>();
builder.Services.AddScoped<IAutenticacaoPersist, AutenticacaoPersist>();
builder.Services.AddScoped<IPerfilPersist, PerfilPersist>();
builder.Services.AddScoped<IGeralPersist, GeralPersist>();
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region Connection SQLServer
builder.Services.AddDbContext<BaseDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringSQLServer"),
    options => options.EnableRetryOnFailure()));
#endregion

#region Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "HSSolution.API",
        Contact = new OpenApiContact
        {
            Name = "HSSolution Web Api",
            Email = "webapi@hssolution.com.br"
        }
    });

    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();

    var xmlFile = "HSSolution.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

#endregion

#region JWT

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HSSolution.API"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
