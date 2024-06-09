using BiuroPodrozyAPI.CMS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.TravelAgency
{
    public class Trip : Auditable
    {
        [Key]
        public int IdTrip { get; set; }


        [Column(TypeName = "nvarchar(80)")]
        public required string TripName { get; set; }


        [Column(TypeName = "nvarchar(40)")]
        public required string TripCode { get; set; }



        [Column(TypeName = "money")]
        public required decimal TripCostPerAdult { get; set; }



        [Column(TypeName = "money")]
        public required decimal TripCostPerChild { get; set; }



        public int IdDestinationCity { get; set; }
        public City? DestinationCity { get; set; }



        [Column(TypeName = "nvarchar(20)")]
        public required string TripType { get; set; }


        public int? IdHotel { get; set; }
        public Hotel? Hotel { get; set; }


        [Column(TypeName = "nvarchar(2000)")]
        public required string TripDescription { get; set; }

        public ICollection<TripPhoto> TripPhotos { get; set; } = new List<TripPhoto>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
