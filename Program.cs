using HospitalManagementSystem.Business.Interfaces;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Helpers.Mapper;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Business.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>(); 
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddHostedService<DeletingExpiredAppointmentsService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"));
});
var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
