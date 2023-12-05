using System.ComponentModel.DataAnnotations.Schema;

namespace MicoClinic.Models
{
    public class Doctor
    {
        public long DoctorId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public long Experience { get; set; }

        public string Email { get; set; } = string.Empty;

    }
}
