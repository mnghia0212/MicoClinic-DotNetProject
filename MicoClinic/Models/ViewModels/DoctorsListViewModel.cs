namespace MicoClinic.Models.ViewModels
{
    public class DoctorsListViewModel
    {
        public IEnumerable<Doctor> Doctors { get; set; } = Enumerable.Empty<Doctor>();

        public PagingInfo PagingInfo { get; set; } = new();
        public string? CurrentDepartment { get; set; }
       
    }
}
