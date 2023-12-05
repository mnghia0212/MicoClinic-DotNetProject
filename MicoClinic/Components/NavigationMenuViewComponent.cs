using Microsoft.AspNetCore.Mvc;
using MicoClinic.Models;

namespace MicoClinic.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IClinicRepository _repo;

        public NavigationMenuViewComponent(IClinicRepository repo)
        {
            _repo = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedDepartment = RouteData?.Values["department"];
            return View(_repo.Doctor
                .Select(x => x.Department)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}