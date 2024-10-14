
using HospitalManagementSystem.Data;

namespace HospitalManagementSystem.Business.Services
{
    public class DeletingExpiredAppointmentsService : IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private Timer _timer;
        public DeletingExpiredAppointmentsService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DeleteAppointments, null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }
        private void DeleteAppointments(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var expiredAppointments= context.Appointments.Where(x=>x.AppointmentDate<DateTime.UtcNow.Date).ToList();
                if(expiredAppointments.Count>0)
                {
                    context.Appointments.RemoveRange(expiredAppointments);
                    context.SaveChanges();
                }
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
