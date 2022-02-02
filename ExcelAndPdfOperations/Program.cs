using ExcelAndPdfOperations.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NorthwindContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Excel}/{action=List}/{id?}");

app.Run();
