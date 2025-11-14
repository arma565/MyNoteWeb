using Microsoft.EntityFrameworkCore;
using Note.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NoteDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("NoteConnection") ?? throw new InvalidOperationException("Connection string 'NoteDbContext' not found."));
});

var app = builder.Build();

if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();