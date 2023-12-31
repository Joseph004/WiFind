using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Extensions;
using MudBlazor.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WiFind_Blazor.Configuration;
using WiFind_Blazor.Data;
using WiFind_Blazor.Repositories;



var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

// Adding services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var appSettings = builder.Services.ConfigureAppSettings<AppSettings>(configuration.GetSection("AppSettings"));

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
}
);
builder.Services.AddMudBlazorDialog();

builder.Services.Configure<CookiePolicyOptions>(options =>
                       {
                           options.CheckConsentNeeded = context => true;
                           options.MinimumSameSitePolicy = SameSiteMode.None;
                       });

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
    options.Filters.Add(new RequireHttpsAttribute());
}).AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Program>())
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
});

builder.Services.AddMudServices();
// or this to add only the MudBlazor.Extensions
builder.Services.AddMudExtensions();
builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();

// For Entity Framework  
builder.Services.AddDbContext<WiFindDbContext>(options => options.UseSqlServer(appSettings.ConnectionStrings.Sql));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
