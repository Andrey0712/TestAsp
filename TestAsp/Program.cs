using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using TestAsp.Data;
using TestAsp.Servise;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((SwaggerGenOptions opts) => {
    opts.SwaggerDoc("test", new OpenApiInfo
    {
        Description = "Swagger",
        Version = "test",
        Title = "TestAsp"
    });
});
builder.Services.AddDbContext<EFContext>((DbContextOptionsBuilder opts) =>
{
    opts.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.Seeder();
    app.UseSwagger();
    app.UseSwaggerUI((SwaggerUIOptions opts) => {
        opts.SwaggerEndpoint("/swagger/test/swagger.json", "TestAsp test");
    });
}

app.UseRouting();

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.Run();