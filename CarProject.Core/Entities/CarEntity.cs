using CarProject.Core.Entities.Base;

namespace CarProject.Core.Entities
{
    public class CarEntity : VehicleBaseEntity
    {
        public int Wheels { get; set; }
        public bool IsHeadlightsOn { get; set; }
    }
}
