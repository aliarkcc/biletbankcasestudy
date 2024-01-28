using BiletBankCaseStudy.WebApp.ApiServices;
using WebAPIWithCoreMvc.ApiServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddHttpContextAccessor();

string url = builder.Configuration.GetValue<string>("BaseUrl");

builder.Services.AddHttpClient<IHttpClientService, HttpClientService>(opt =>
     {
         opt.BaseAddress = new Uri(url);

     });


builder.Services.AddTransient<IAirportApiService, AirportApiService>();
builder.Services.AddTransient<IFlightApiService, FlightApiService>();

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
