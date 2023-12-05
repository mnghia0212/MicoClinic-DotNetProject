using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MicoClinic.Models
{
    public class Appointment
    {
        [BindNever]
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string? PatientName { get; set; }

        [Required(ErrorMessage = "Please enter a department")]
        public string? DepartmentName { get; set; }

        [Required(ErrorMessage = "Please enter a doctor")]
        public string? DoctorName { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your symptoms")]
        public string? Symptoms { get; set; }


        [Required(ErrorMessage = "Please select the appointment's date and time")]
        public DateTime? AppointmentDateTime { get; set; }

    }

   
}
