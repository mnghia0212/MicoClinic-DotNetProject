using Microsoft.EntityFrameworkCore;

namespace MicoClinic.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ClinicDbContext context = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<ClinicDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Doctors.Any())
            {
                context.Doctors.AddRange(
                    new Doctor
                    {
                       
                        Name = "John",
                        Age = 31,
                        Gender = "Male",
                        Department = "Otolaryngology",
                        Experience = 3,
                        Email = "JohnWithoutCena@gmail.com"
                    },
                    new Doctor
                    {
                    
                        Name = "Todd",
                        Age = 25,
                        Gender = "Male",
                        Department = "Otolaryngology",
                        Experience = 2,
                        Email = "ToddHandsomeaf@gmail.com"
                    },
                    new Doctor
                    {
                        
                        Name = "Jenny",
                        Age = 23,
                        Gender = "Female",
                        Department = "Pediatrics",
                        Experience = 3,
                        Email = "JennyNotInBlackPink@gmail.com"
                    },
                    new Doctor
                    {
                        
                        Name = "Robert",
                        Age = 43,
                        Gender = "Male",
                        Department = "Pediatrics",
                        Experience = 10,
                        Email = "RobertLoveMico@gmail.com"
                    },
                    new Doctor
                    {
                        
                        Name = "Maeve",
                        Age = 25,
                        Gender = "Female",
                        Department = "Gynecology",
                        Experience = 2,
                        Email = "PickMeMaeve@gmail.com"
                    },
                    new Doctor
                    {
                        
                        Name = "Otis",
                        Age = 25,
                        Gender = "Male",
                        Department = "Gynecology",
                        Experience = 2,
                        Email = "OMyTis@gmail.com"
                    },
                    new Doctor
                    {
                        
                        Name = "Adam",
                        Age = 33,
                        Gender = "Male",
                        Department = "Neurology",
                        Experience = 4,
                        Email = "WhereIsMyEva@gmail.com"
                    },
                    new Doctor
                    {
                        
                        Name = "Ruby",
                        Age = 30,
                        Gender = "Female",
                        Department = "Neurology",
                        Experience = 3,
                        Email = "ImNotAProgrammingLanguage@gmail.com"
                    },
                    new Doctor
                    {
                        
                        Name = "Will",
                        Age = 38,
                        Gender = "Male",
                        Department = "Pulmonology",
                        Experience = 9,
                        Email = "ImSorryChrisRock@gmail.com"
                    },
                    new Doctor
                    {
                        
                        Name = "Selena",
                        Age = 36,
                        Gender = "Female",
                        Department = "Pulmonology",
                        Experience = 7,
                        Email = "IMissYouJustin@gmail.com"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
