using Repositories.Implement;
using Repositories.Interface;
using Services.Implement;
using Services.Interface;

namespace HotelMini
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSession();

            // Add repo to container
            builder.Services.AddScoped<IBookingDetailRepo, BookingDetailRepo>();
            builder.Services.AddScoped<IBookingReservationRepo, BookingReservationRepo>();
            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
            builder.Services.AddScoped<IRoomInformationRepo, RoomInformationRepo>();
            builder.Services.AddScoped<IRoomTypeRepo, RoomTypeRepo>();

            // Add service to container
            builder.Services.AddScoped<IBookingDetailSer, BookingDetailSer>();
            builder.Services.AddScoped<IBookingReservationSer, BookingReservationSer>();
            builder.Services.AddScoped<ICustomerSer, CustomerSer>();
            builder.Services.AddScoped<IRoomInformationSer, RoomInformationSer>();
            builder.Services.AddScoped<IRoomTypeSer, RoomTypeSer>();

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

            app.Run();
        }
    }
}
