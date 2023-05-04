
using GhiasAmooz.Core.Convertors;
using GhiasAmooz.Core.Services;
using GhiasAmooz.Core.Services.Interfaces;
using GhiasAmooz.DataLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddMvc();

#region Authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie(options =>
{
    options.LoginPath = "/Login";
    options.LogoutPath = "/Logout";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);

});

#endregion
#region DataBase Context



builder.Services.AddDbContext<GhiasAmoozContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GhiasAmoozConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
        });
    
});

#endregion
#region IoC

    builder.Services.AddTransient<IPermissionService, PermissionService>();
    builder.Services.AddTransient<IUserService, UserService>();
    builder.Services.AddTransient<IViewRenderService, RenderViewToString>();
    builder.Services.AddTransient<ICourseService, CourseService>();
    builder.Services.AddTransient<IOrderService, OrderService>();
    builder.Services.AddTransient<IForumService, ForumService>();

#endregion





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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
