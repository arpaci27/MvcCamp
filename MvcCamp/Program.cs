using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.Name = "UserLoginCookie";
        options.LoginPath = "/Login/Index";  // Genel giri� sayfas�
        options.LogoutPath = "/Login/Logout";
        options.AccessDeniedPath = "/Home/AccessDenied";

        // Kullan�c�n�n eri�meye �al��t��� sayfaya g�re farkl� bir giri� sayfas�na y�nlendirme
        options.Events.OnRedirectToLogin = context =>
        {
            var path = context.Request.Path;

            // Belirli sayfalarda farkl� giri� sayfas�na y�nlendirme
            if (path.StartsWithSegments("/WriterPanel") ||
                path.StartsWithSegments("/WriterPanelContext") ||
                path.StartsWithSegments("/WriterPanelMessage"))
            {
                context.Response.Redirect("/Login/WriterLogin");
            }
            else
            {
                context.Response.Redirect(context.RedirectUri);
            }

            return Task.CompletedTask;
        };
    });

builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();