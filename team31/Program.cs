using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using team31;
using Prometheus;

const string livenessCheckRouteName = "liveness";
const string readinessCheckRouteName = "readiness";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddCheck<LivenessHealthCheck>(livenessCheckRouteName)
    .AddCheck<ReadinessHealthCheck>(readinessCheckRouteName);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHealthChecks($"health/{livenessCheckRouteName}", new HealthCheckOptions
{
    Predicate = h => h.Name == livenessCheckRouteName
});

app.MapHealthChecks($"health/{readinessCheckRouteName}", new HealthCheckOptions
{
    Predicate = h => h.Name == readinessCheckRouteName
});

app.UseMetricServer();

app.Run();