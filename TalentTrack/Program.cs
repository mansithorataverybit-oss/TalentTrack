using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using TalentTrack.Data;
using TalentTrack.Models;
using TalentTrack.Services;

// Enable legacy timestamp behavior for PostgreSQL
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// Configure dynamic Port binding for Render / Cloud hosting
var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrEmpty(port))
{
    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
}

// Register PDFSharp Font Resolver
try
{
    PdfSharp.Fonts.GlobalFontSettings.FontResolver = new WindowsFontResolver();
}
catch (System.Exception)
{
    // Ignore if already set
}

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database Connection (PostgreSQL)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? builder.Configuration["DefaultConnection"]
                       ?? builder.Configuration["DATABASE_URL"];

// Support Render's postgres:// URI format if provided
if (!string.IsNullOrEmpty(connectionString) && (connectionString.StartsWith("postgres://") || connectionString.StartsWith("postgresql://")))
{
    try
    {
        var uri = new Uri(connectionString);
        var userInfo = uri.UserInfo.Split(':');
        var npgsqlBuilder = new Npgsql.NpgsqlConnectionStringBuilder
        {
            Host = uri.Host,
            Port = uri.Port > 0 ? uri.Port : 5432,
            Database = uri.AbsolutePath.TrimStart('/'),
            Username = userInfo[0],
            Password = userInfo.Length > 1 ? Uri.UnescapeDataString(userInfo[1]) : string.Empty,
            SslMode = Npgsql.SslMode.Prefer
        };
        connectionString = npgsqlBuilder.ConnectionString;
    }
    catch (Exception)
    {
        // Fallback to raw string if parsing fails
    }
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString)
           .UseSnakeCaseNamingConvention());

// Configure Email Settings
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

// Register Email Service
builder.Services.AddTransient<IEmailService, EmailService>();

// Configure Forwarded Headers for reverse proxies (Render / Cloud hosting)
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

// Add Session support
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Automatically apply migrations if AUTO_MIGRATE=true is set
if (builder.Configuration.GetValue<bool>("AutoMigrate", false) || 
    Environment.GetEnvironmentVariable("AUTO_MIGRATE") == "true")
{
    try
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while automatically applying migrations on startup.");
    }
}

// Enable Forwarded Headers before routing/auth
app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseSession();   // must be before UseAuthorization

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Landing}/{id?}")
    .WithStaticAssets();

app.Run();