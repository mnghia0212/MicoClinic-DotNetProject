using MicoClinic.Infrastructure;
using MicoClinic.Migrations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MicoClinic.Models
{
    public class SessionAppointment : Appointment
    {
        [JsonIgnore]
        public ISession? Session { get; private set; }

    }
}
