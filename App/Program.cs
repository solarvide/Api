
using Context.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using App;
using App.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SolarVide App", Version = "v1", Description = "API FSzion Technolic" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below. \r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
        }
    });
});
builder.Services.AddDbContext<ContextApp>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDB")));
builder.Services.AddSingleton(builder.Configuration.GetSection("SettingsApp").Get<SettingsApp>());
builder.Services.ConfigureAuthentication();
builder.Services.ConfigureSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction() || app.Environment.IsStaging())
{

    var context = builder.Services.BuildServiceProvider().GetService<ContextApp>();
    var languageList = context.LanguageTags.ToList();
    AppDomain.CurrentDomain.SetData("langList", languageList);

    //Raise the configurations to the memory like as languages tag
    var configurationSettings = context.ConfigurationTags.ToList();
    AppDomain.CurrentDomain.SetData("configList", configurationSettings);
}
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment() || app.Environment.IsStaging()) {
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllers();
app.UseCors("MyPolicy");


app.Run();

