var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

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
builder.Services.AddScoped<MoviesClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
