using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.TravelAgency
{
    public class ServiceType : Auditable
    {
        [Key]
        public int IdServiceType { get; set; }



        [Column(TypeName = "nvarchar(50)")]
        public required string ServiceTypeName { get; set; }


        public ICollection<Service> Services { get; set; } = new List<Service>();

    }
}
