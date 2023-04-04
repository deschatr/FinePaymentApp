using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Net.Http.Headers;
using FinePaymentApp.Data;
using FinePaymentManagement;

const string baseAddress = "https://v1a4g2.azurewebsites.net/api/finepayments/";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddHttpClient<IFinePaymentService,FinePaymentService>("FinePaymentAPI", httpClient =>
{
    httpClient.BaseAddress = new Uri(baseAddress);
    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept,"application/json");
    httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent,"FinePaymentApp/0.0");
});

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

