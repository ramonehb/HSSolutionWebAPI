using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using HSSolution.Application;
using HSSolution.Application.Interfaces;
using HSSolution.Persistence;
using HSSolution.Persistence.Context;
using HSSolution.Persistence.Interfaces;

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
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "HSSolution.API",
        Contact = new OpenApiContact
        {
            Name = "HSSolution Web Api",
            Email = "webapi@hssolution.com.br"
        }
    });

    var xmlFile = "HSSolution.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    s.IncludeXmlComments(xmlPath);
    s.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
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
