using MicoClinic.Models;
using Microsoft.AspNetCore.Mvc;
using MicoClinic.Models.ViewModels;
using MicoClinic.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MicoClinic.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IClinicRepository _repo;
        private readonly IAppointmentRepository _repository;
        public int PageSize = 4;

        public HomeController(IClinicRepository repo, IAppointmentRepository repository)
        {
            _repo = repo;
            _repository = repository;
          
        }

       

        [HttpPost]
        public IActionResult Index(Appointment appointment)
        {
            if (ModelState.IsValid)
            {

                _repository.SaveAppointment(appointment);
                return RedirectToPage("/completed", new { appointmentId = appointment.AppointmentId });
            }
            else
            {
                // Lấy lại dữ liệu cho ViewBag
                var doctors = _repo.Doctor.ToList();
                var departments = doctors.Select(d => d.Department).Distinct().ToList();

                ViewBag.Doctors = new SelectList(doctors, "DoctorId", "Name");
                ViewBag.Departments = new SelectList(departments);

                // Trả về view với thông báo lỗi
                return View(appointment);
           
            }
        }


        public IActionResult Index(string? department, string? doctorName)
        {
            var doctors = _repo.Doctor.ToList();
            var departments = doctors.Select(d => d.Department).Distinct().ToList();

            ViewBag.Doctors = new SelectList(doctors, "DoctorId", "Name");
            ViewBag.Departments = new SelectList(departments);

            var model = new Appointment
            {
                DepartmentName = department,
                DoctorName = doctorName
            };

            return View(model);
        }

        public IActionResult GetDoctorsByDepartment(string department)
        {
            var doctors = _repo.Doctor
              .Where(p => p.Department == department)
              .Select(p => new { id = p.DoctorId, name = p.Name })
              .ToList();

            return Json(new { doctors });
        }

        public IActionResult Doctor(string? department, int doctorPage = 1)
        {
            return View(
                new DoctorsListViewModel
                {
                    Doctors = _repo.Doctor
                        .Where(p => department == null || p.Department == department)
                        .OrderBy(p => p.DoctorId)
                        .Skip((doctorPage - 1) * PageSize)
                        .Take(PageSize),

                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = doctorPage,
                        ItemsPerpage = PageSize,

                        //filter category null or not null
                        TotalItems = department == null
                            ? _repo.Doctor.Count()
                            : _repo.Doctor.Where(e => e.Department == department).Count()
                    },
                    CurrentDepartment = department

                }); 
        }


        public IActionResult About() 
        { 
            return View(); 
        }

        public IActionResult Testimonial()
        {
            return View();
        }

        public IActionResult Treatment()
        {
            return View();
        }
    }
}
