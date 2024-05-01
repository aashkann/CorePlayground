using CorePlayground.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Supabase;

using CorePlayground.Models;
using CorePlayground.Contracts;
using Playground.Contracts;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<Supabase.Client>(_ =>
    new Supabase.Client(
        builder.Configuration["Supabase:Url"],
        builder.Configuration["Supabase:Key"],
        new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        }));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;// JsonNamingPolicy.CamelCase;
    });
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Add your API endpoints here
app.MapPost("/sessions", async (CreateSessionRequest request, Supabase.Client client) =>
{
    var session = new Session
    {
        User = request.User,
        Duration = request.Duration,
        AreaInteractions = request.AreaInteractions,
        AreaDuration = request.AreaDuration,
        SunlightInteractions = request.SunlightInteractions,
        SunlightDuration = request.SunlightDuration,
        FilePath = request.FilePath
    };

    var response = await client.From<Session>().Insert(session);
    var newSession = response.Models.First();

    return Results.Ok(newSession.Id);
});

app.MapGet("/sessions/{id}", async (long id, Supabase.Client client) =>
{
    var response = await client.From<Session>().Where(s => s.Id == id).Get();
    var session = response.Models.FirstOrDefault();

    if (session is null)
    {
        return Results.NotFound();
    }

    var sessionResponse = new SessionResponse
    {
        Id = session.Id,
        User = session.User,
        Duration = session.Duration,
        AreaInteractions = session.AreaInteractions,
        AreaDuration = session.AreaDuration,
        SunlightInteractions = session.SunlightInteractions,
        SunlightDuration = session.SunlightDuration,
        FilePath = session.FilePath
    };

    return Results.Ok(sessionResponse);
});

app.MapDelete("/sessions/{id}", async (long id, Supabase.Client client) =>
{
    await client.From<Session>().Where(n => n.Id == id).Delete();
    return Results.NoContent();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
