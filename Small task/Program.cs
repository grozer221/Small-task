using Microsoft.AspNetCore.Mvc.Razor;
using Small_task.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Conventions.Add(new RouteVitalikPrefixConvention());
});

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationExpanders.Add(new ReverseViewFolderLocationExpander());
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Hello/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapHelloControllerVitalikRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hello}/{action=Index}/{id?}");

app.Run();
