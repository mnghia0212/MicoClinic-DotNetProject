namespace MicoClinic.Models
{
    public interface IClinicRepository
    {
        IQueryable<Doctor> Doctor { get; }
        

    }
}
