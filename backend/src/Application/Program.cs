using System.Reflection;
using Application;
using Application.Migrations;
using Application.Services;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

FirebaseApp.Create(
    new AppOptions() { Credential = GoogleCredential.FromFile("firebase_admin_sdk.json") }
);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SupportNonNullableReferenceTypes();
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Receipt Keeper API v1" });
});
builder.Services.AddEndpoints();
builder.Services.AddRepositories();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddPersistences(builder);
builder.Services.AddAuthentications(builder);
builder.Services.AddAuthorizations();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IHttpContextService, HttpContextService>();

var app = builder.Build();

// Run database migrations
app.MigrateDatabase<Program>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "Receipt Keeper API v1";
    });
    Console.WriteLine("http://localhost:5103/swagger");
}

// Don't redirect to HTTPS, we'll be using a reverse proxy in production
// app.UseHttpsRedirection();

// This is required for the Firebase authentication scheme
app.UseAuthentication();
app.UseAuthorization();

// Health check endpoint
app.MapGet("/health", () => "Ok!").WithTags("Health Check");
app.MapEndpoints();

app.Run();
