var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();


// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("VitePolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://careerlot.vercel.app")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("VitePolicy");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
} 
else
{
    app.UseHttpsRedirection();
}

app.MapControllers();


app.Run();