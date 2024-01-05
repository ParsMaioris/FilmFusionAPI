var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer(); // Optional, but recommended for API exploration
builder.Services.AddSwaggerGen();

// Bind MoviesApi from appsettings.json and register it
var MoviesApiSection = builder.Configuration.GetSection("MoviesApi");
var MoviesApi = MoviesApiSection.Get<MoviesApiSetting>();
if (MoviesApi == null)
{
    throw new InvalidOperationException("Failed to bind MoviesApi.");
}

builder.Services.AddSingleton(MoviesApi);

// Register with DI container
builder.Services.AddSingleton<ILoggerService, LoggerService>();
builder.Services.AddSingleton<IHttpClientWrapper, HttpClientWrapper>();
builder.Services.AddScoped<IMoviesClient, MoviesClient>();
builder.Services.AddScoped<MovieService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
