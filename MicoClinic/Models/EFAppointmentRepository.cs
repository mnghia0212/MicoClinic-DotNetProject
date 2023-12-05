using static MicoClinic.Models.EFAppointmentRepository;

namespace MicoClinic.Models
{
    public class EFAppointmentRepository : IAppointmentRepository
    {
        private readonly ClinicDbContext context;

        public EFAppointmentRepository(ClinicDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Appointment> Appointments => context.Appointments;

        public void SaveAppointment(Appointment appointment)
        {
            if (appointment.AppointmentId == 0)
            {
                context.Appointments.Add(appointment);
            }
            else
            {
                // Cập nhật thông tin nếu cần
                var dbEntry = context.Appointments.FirstOrDefault(a => a.AppointmentId == appointment.AppointmentId);
                if (dbEntry != null)
                {
                    // Cập nhật các trường thông tin ở đây
                }
            }
            context.SaveChanges();
        }

        public void DeleteAppointment(int appointmentId)
        {
            var appointment = context.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
            if (appointment != null)
            {
                context.Appointments.Remove(appointment);
                context.SaveChanges();
            }
        }

        public void DeleteAllAppointments()
        {
            foreach (var appointment in context.Appointments)
            {
                context.Appointments.Remove(appointment);
            }
            context.SaveChanges();
        }
    }
}
