using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

const string appTitle = "Tagged World WebAPI";
const string appVersion = "v1";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<WebApiTaggedWorld.Data.DataContext>();

// https://stackoverflow.com/questions/65261654/how-do-you-implement-system-text-json-serialization-referencehandler-preserve-in
builder.Services.AddMvc().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(appVersion, new OpenApiInfo
    {
        Title = appTitle,
        Version = appVersion,
        Description = $"Testing {appTitle}",
        Contact = new OpenApiContact { Name = "BV", Email = "bv.net@outlook.com", Url = new Uri("https://github.com/bvujovic/") }
    });

    var filePath = Path.Combine(AppContext.BaseDirectory, "WebApiTaggedWorld.xml");
    c.IncludeXmlComments(filePath);

    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<Swashbuckle.AspNetCore.Filters.SecurityRequirementsOperationFilter>();

    c.CustomOperationIds(apiDesc =>
        apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null);
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // https://stackoverflow.com/questions/52379848/asp-net-core-jwt-authentication-allows-expired-tokens
            // https://stackoverflow.com/questions/43045035/jwt-token-authentication-expired-tokens-still-working-net-core-web-api
            // https://stackoverflow.com/questions/47153080/clock-skew-and-tokens
            ClockSkew = TimeSpan.Zero,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = "JwtIssuer",
            ValidAudience = "JwtAudience",
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes("JwtKeySomethingWeirdReally123"))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    // app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(appVersion + "/swagger.json", appTitle + " " + appVersion);
        c.DisplayOperationId();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
