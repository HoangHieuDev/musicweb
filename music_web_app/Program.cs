using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using music_web_app.Data;
using System.Data.SqlClient;
using System.Security.Principal;

namespace music_web_app;
class Program
{
    public static SqlConnection Sql { get; private set; } = default!;
    public static Cloudinary cloudinary { get; private set; } = default!;
    public const string CLOUD_NAME = "dabdclkhv";
    public const string API_KEY = "323928918551213";
    public const string API_SECRET = "oMDKltLdVGXubTGxxcJb4l8hq4g";
    public static IConfiguration Config { get; private set; } = default!;
    public static string RootPath { get; set; } = null!;
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddServerSideBlazor();
        builder.Services.AddDbContext<music_web_app_DBContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddRazorPages();
        builder.Services.AddDistributedMemoryCache();

        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(1000);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });



        var app = builder.Build();
        Config = app.Configuration;
        Sql = new SqlConnection(Config["ConnectionStrings:SQL"]);

        //Connect account Cloudnary

        cloudinary = new Cloudinary("cloudinary://" + API_KEY + ":" + API_SECRET + "@" + CLOUD_NAME + "");
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var db = scope.ServiceProvider.GetRequiredService<music_web_app_DBContext>();
                db.Database.EnsureCreated();
                DbInitializer.Initialize(db);
                Sql.Open();
            }
            catch (Exception ex)
            {
                var logger = app.Services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }

        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession();
        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}