using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.TravelAgency
{
    public class Service : Auditable
    {
        [Key]
        public int IdService { get; set; }



        [Column(TypeName = "nvarchar(50)")]
        public required string ServiceName { get; set; }


        [ForeignKey("ServiceType")]
        public int IdServiceType { get; set; }
        public required ServiceType ServiceType { get; set; }



        [Column(TypeName = "nvarchar(2000)")]
        public string? ServiceDescription { get; set; }



        [Column(TypeName = "nvarchar(7)")]
        [AllowedValues("procent", "wartosc")]
        public required string ServiceChargingType { get; set; }



        [Column(TypeName = "money")]
        public decimal ServiceCost { get; set; }


        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
