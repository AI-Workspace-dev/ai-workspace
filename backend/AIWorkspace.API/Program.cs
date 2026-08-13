using AIWorkspace.API.Configuration;
using AIWorkspace.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApplicationSettings>(
    builder.Configuration.GetSection("Application"));

// Dependency Injection
builder.Services.AddScoped<IWorkspaceService, WorkspaceService>();

// Controllers
builder.Services.AddControllers();

// OpenAPI
builder.Services.AddOpenApi();

// Health Checks
builder.Services.AddHealthChecks();

var app = builder.Build();

// OpenAPI
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "AI Workspace API v1");
    });
}

// HTTPS
app.UseHttpsRedirection();

// Controllers
app.MapControllers();

// Health Check
app.MapHealthChecks("/health");

app.Run();