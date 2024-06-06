using AgentBuilderApi;
using AgentBuilderApi.Services.UserServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//HINT: Injecting DB Contextext With Azure DB Connection
var cnnString = builder.Configuration.GetConnectionString("DevelopmentConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(cnnString));

//HINT: ADDING INTERNAL SERVICES VIA DI
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
