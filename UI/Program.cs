using Connecter.Client;
using Entity;
using Microsoft.EntityFrameworkCore;
using ServiceReference;
using UI.Repositries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<ServiceSetting>(builder.Configuration.GetSection("HttpClient"));
builder.Services.AddHttpClient<IClientContainer, ClientContainer>();
builder.Services.AddHttpClient<IClientLookup,ClientLookup>();
builder.Services.AddHttpClient<IClientComplaintType,ClientComplaintType>();
builder.Services.AddDbContext<Entity.Repository.MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConn")));
builder.Services.AddScoped<Repository.IUnitofwork, Repository.Unitofwork>();
builder.Services.AddScoped<IRepositoryGeneralRequest, RepositoryGeneralRequest>();
builder.Services.AddScoped<IRepositoryActionHistory, RepositoryActionHistory>();
builder.Services.AddScoped<IRepositoryServices, RepositoryServices>();
builder.Services.AddScoped<IRepositoryAction,RepositoryAction>();
builder.Services.AddSingleton(new TaskActionSoapClient(ServiceReference.TaskActionSoapClient.EndpointConfiguration.TaskActionSoap));
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
