using CarProject.Core.Enums;

namespace CarProject.Core.Models
{
    public class CarPostModel
    {
        public VehicleColor Color { get; set; }
        public int Wheels { get; set; }
        public bool IsHeadlightsOn { get; set; }
        public string Model { get; set; }
    }
}
