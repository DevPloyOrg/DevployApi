using DevPloyApiApi;
using DevPloyApiApi.Services.FormServices;
using DevPloyApiApi.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//HINT: Injecting DB Contextext With Azure DB Connection
var cnnString = builder.Configuration.GetConnectionString("DevelopmentConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(cnnString));

//HINT: ADDING INTERNAL SERVICES VIA DI
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFormServices, FormServices>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "DevPloy.com API",
        Version = "v1",
        Description =   "Basic Api System",
        Contact = new OpenApiContact
        {
            Name = "Nicola Montanari",
            Email = "nicoladotmontanari@yahoo.com"
        }
    });
    // Optional: Include XML comments if you want to use them
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin());
});

var app = builder.Build();



//HINT: Logging Enviroment
//var logger = app.Services.GetRequiredService<ILogger<Program>>();
//logger.LogInformation("Application started in environment: {Environment}", app.Environment.EnvironmentName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
