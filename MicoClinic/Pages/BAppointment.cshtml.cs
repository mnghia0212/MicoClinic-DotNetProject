using Microsoft.AspNetCore.Mvc.RazorPages;
using MicoClinic.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MicoClinic.Pages
{
    public class AppointmentModel : PageModel
    {
        private readonly IAppointmentRepository _repository;

        public List<Appointment> Appointments { get; set; }

        public AppointmentModel(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
            Appointments = _repository.Appointments.ToList();
        }

        public IActionResult OnPostDelete(int appointmentId)
        {
            _repository.DeleteAppointment(appointmentId);
            return RedirectToPage();
        }

        public IActionResult OnPostDeleteAll()
        {
            _repository.DeleteAllAppointments();
            return RedirectToPage();
        }
    }
}