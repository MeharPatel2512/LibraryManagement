using Microsoft.AspNetCore.Authentication.JwtBearer;
using Library.Exceptions;
using Library.Filters;
using Library.Repository;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Library.Middleware;
using Microsoft.OpenApi.Models;
using Library.Business.Interface;
using Library.Business.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<IExecuteStoredProcedure, ExecuteStoredProcedure>();
builder.Services.AddScoped<IRegisterUserBusiness, RegisterUserBusiness>();
builder.Services.AddScoped<ILoginUserBusiness, LoginUserBusiness>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IOtherUserBusiness, OtherUserBusiness>();
builder.Services.AddScoped<ISubscriptionBusiness, SubscriptionBusiness>();
builder.Services.AddScoped<IAdminBusiness, AdminBusiness>();
builder.Services.AddScoped<IBookBusiness, BookBusiness>();
builder.Services.AddHttpContextAccessor();

// builder.Services.AddControllers();
// builder.Services.AddControllers()
//     .AddNewtonsoftJson(options =>
//     {
//         options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
//         options.SerializerSettings.Formatting = Formatting.Indented; // Pretty print the JSON response
//     });

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateModelAttribute>(); // Add global model validation filter
})
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.Formatting = Formatting.Indented; // Pretty print the JSON response
});

// builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(Options => {
    var JwtSecurityScheme = new OpenApiSecurityScheme{
        BearerFormat = "JWT",
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description="add token and use api",
        Name ="Jwt Token ",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Reference = new OpenApiReference{
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type= ReferenceType.SecurityScheme
        }
    };
    Options.AddSecurityDefinition("Bearer", JwtSecurityScheme);
    Options.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {JwtSecurityScheme, Array.Empty<string>()}
    });
});

builder.Services.AddAuthentication(Options => {
    Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    Options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
    });

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<UserIdMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
