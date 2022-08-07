using CarProject.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarProject.Core.Entities.Base
{
    public class VehicleBaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
        public VehicleColor Color { get; set; }
        public string Model { get; set; }
    }
}
