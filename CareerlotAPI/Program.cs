var builder = WebApplication.CreateBuilder(args);

// 1. Add Controller Support
builder.Services.AddControllers();

// 2. Enable CORS so your React app (port 5173) can talk to this API
builder.Services.AddCors(options =>
{
    options.AddPolicy("VitePolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddOpenApi();

var app = builder.Build();

// 3. Use the CORS policy
app.UseCors("VitePolicy");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 4. Map the Controller routes
app.MapControllers();

// You can keep or delete the weatherforecast MapGet logic below
app.MapGet("/weatherforecast", () => { /* ... */ }).WithName("GetWeatherForecast");

app.Run();