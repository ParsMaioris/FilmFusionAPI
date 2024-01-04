var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Bind HttpClientSettings from appsettings.json and register it
var httpClientSettingsSection = builder.Configuration.GetSection("HttpClientSettings");
var httpClientSettings = httpClientSettingsSection.Get<HttpClientSettings>();
if (httpClientSettings == null)
{
    throw new InvalidOperationException("Failed to bind HttpClientSettings.");
}

builder.Services.AddSingleton(httpClientSettings);

// Register ILoggerService and HttpClientWrapper with DI container
builder.Services.AddSingleton<ILoggerService, LoggerService>();
builder.Services.AddSingleton<IHttpClientWrapper, HttpClientWrapper>();

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
