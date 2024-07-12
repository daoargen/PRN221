using BussinessObject;
using HotelMini.Hubs;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Repository.Implement;
using Repository.Interface;
using Service.Implement;
using Service.Interface;
using Service.OtherService;

var builder = WebApplication.CreateBuilder(args);

// ??ng ký SignalR
builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();

// Add background service to container
builder.Services.AddHostedService<BackgroundWorkerService>();

// Add repo to container
builder.Services.AddScoped<IBaseCRUD<BookingDetail>, BookingDetailRepo>();
builder.Services.AddScoped<IBaseCRUD<BookingReservation>, BookingReservationRepo>();
builder.Services.AddScoped<IBaseCRUD<Customer>, CustomerRepo>();
builder.Services.AddScoped<IBaseCRUD<RoomInformation>, RoomInformationRepo>();
builder.Services.AddScoped<IBaseCRUD<RoomType>, RoomTypeRepo>();

// Add service to container
builder.Services.AddScoped<IBookingDetailSer, BookingDetailSer>();
builder.Services.AddScoped<IBookingReservationSer, BookingReservationSer>();
builder.Services.AddScoped<ICustomerSer, CustomerSer>();
builder.Services.AddScoped<IRoomInformationSer, RoomInformationSer>();
builder.Services.AddScoped<IRoomTypeSer, RoomTypeSer>();
builder.Services.AddScoped<EmailService, EmailService>();

builder.Services.AddSingleton<BackgroundTaskService, BackgroundTaskService>();



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

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapHub<BookingDetailHub>("/bookingDetailHub"); // Thay thế BookingDetailHub bằng lớp Hub của bạn
});

app.Run();
