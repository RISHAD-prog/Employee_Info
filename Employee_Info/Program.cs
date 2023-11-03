using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description=  "Standard Authorization Header using Bearer (\"bearer {token}\" )",
        In =  ParameterLocation.Header,
        Name =  "Authorization",
        Type =  SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddScoped<EmployeeAttendanceService>();
builder.Services.AddScoped<EmpMonthlyAttendanceService>();
builder.Services.AddScoped<AuthSevice>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<DataAccessFactory>();
builder.Services.AddDbContext<EmployeeEntities>(db => db.UseSqlServer(
    builder.Configuration.GetConnectionString("SqlServer") 
    ), ServiceLifetime.Scoped);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
