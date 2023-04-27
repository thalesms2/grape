using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using restApi.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration["dbContextSettings:ConnectionString"];

builder.Services.AddDbContext<GrapeContext>(options => options.UseLazyLoadingProxies().UseNpgsql(connectionString));

builder.Services.AddMvc();

builder.Services.
    AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GrapeApi", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
