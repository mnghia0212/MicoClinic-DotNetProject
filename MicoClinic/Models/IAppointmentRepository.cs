namespace MicoClinic.Models
{
    public interface IAppointmentRepository
    {
      
        IQueryable<Appointment> Appointments { get; }
        void SaveAppointment(Appointment appointment);

        void DeleteAppointment(int appointmentId);

        void DeleteAllAppointments();

    }
}
