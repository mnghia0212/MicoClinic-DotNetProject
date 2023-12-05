using Microsoft.EntityFrameworkCore;

namespace MicoClinic.Models
{
    public class EFClinicRepository : IClinicRepository
    {
        private readonly ClinicDbContext _ctx;
        public EFClinicRepository(ClinicDbContext ctx)
        {

            _ctx = ctx;

        }

        public IQueryable<Doctor> Doctor => _ctx.Doctors;



    }
}
