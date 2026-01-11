using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Reflection.Metadata;
using WebApplication1.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("all", new OpenApiInfo { Title = "All APIs", Version = "v1" });
    options.SwaggerDoc("persons", new OpenApiInfo { Title = "Persons API", Version = "v1" });
    options.SwaggerDoc("accounts", new OpenApiInfo { Title = "Accounts API", Version = "v1" });

    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        //var area = apiDesc.ActionDescriptor.RouteValues["area"]?.ToString();
        if (docName == "all") return true;

        if (apiDesc.TryGetMethodInfo(out MethodInfo method))
        {
            var controllerType = method.DeclaringType;

            if (controllerType.Name.StartsWith("Persons") && docName == "persons")
                return true;

            if (controllerType.Name.StartsWith("Accounts") && docName == "accounts")
                return true;
        }

        return false;
    });

    options.TagActionsBy(api =>
    {
        var controllerName = api.ActionDescriptor.RouteValues["controller"];
        return new[] { controllerName };
    });

    //options.SwaggerDoc("v1", new OpenApiInfo
    //{
    //    Title = "Main API",
    //    Version = "v1"
    //});

    //options.SwaggerDoc("persons", new OpenApiInfo
    //{
    //    Title = "Persons API",
    //    Version = "v1"
    //});

    //options.DocInclusionPredicate((docName, apiDesc) =>
    //{
    //    if (docName == "persons")
    //    { return apiDesc.GroupName == "Persons"; }

    //    return true;
    //});
});

//builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/all/swagger.json", "All APIs");
        c.SwaggerEndpoint("/swagger/persons/swagger.json", "Persons APIs");
        c.SwaggerEndpoint("/swagger/accounts/swagger.json", "Accounts APIs");

        c.ConfigObject.DisplayRequestDuration = true;
        c.ConfigObject.DocExpansion = DocExpansion.None;
    });
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

//app.MapAreaControllerRoute(
//    name: "area",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id}"
//    );

//app.MapAreaControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{Id}"
//    );

app.MapControllers();

app.UseMiddleware<GlobalExeptionHandlingMiddleware>();

app.Run();
