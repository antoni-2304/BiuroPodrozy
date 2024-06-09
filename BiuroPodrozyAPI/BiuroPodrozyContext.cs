
using BiuroPodrozyApi.Models;
using BiuroPodrozyAPI.CMS;
using BiuroPodrozyAPI.TravelAgency;
using Microsoft.EntityFrameworkCore;

namespace BiuroPodrozyAPI
{
    public class BiuroPodrozyContext : DbContext
    {
        public BiuroPodrozyContext(DbContextOptions<BiuroPodrozyContext> options)
            : base(options)
        {
        }

        public DbSet<TravelAgency.Client> Client { get; set; } = default!;
        public DbSet<TravelAgency.City> City { get; set; } = default!;
        public DbSet<TravelAgency.Country> Country { get; set; } = default!;
        public DbSet<TravelAgency.Currency> Currency { get; set; } = default!;
        public DbSet<TravelAgency.Language> Language { get; set; } = default!;
        public DbSet<TravelAgency.Address> Address { get; set; } = default!;
        public DbSet<TravelAgency.AccountInformation> AccountInformation { get; set; } = default!;
        public DbSet<TravelAgency.Employee> Employee { get; set; } = default!;
        public DbSet<TravelAgency.Flight> Flight { get; set; } = default!;
        public DbSet<TravelAgency.Reservation> Reservation { get; set; } = default!;
        public DbSet<TravelAgency.Hotel> Hotel { get; set; } = default!;
        public DbSet<TravelAgency.Trip> Trip { get; set; } = default!;


        public DbSet<User> User { get; set; } = default!;


        public DbSet<CMS.Site> Site { get; set; } = default!;
        public DbSet<CMS.Page> Page { get; set; } = default!;
        public DbSet<CMS.CountryPhoto> CountryPhoto { get; set; } = default!;
        public DbSet<CMS.HotelPhoto> HotelPhoto { get; set; } = default!;
        public DbSet<CMS.TripPhoto> TripPhoto { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasMany(p => p.Cities).WithOne(d => d.Country).HasForeignKey(d => d.IdCountry).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Country>().HasOne(e => e.CapitalCity).WithOne().HasForeignKey<Country>(e => e.IdCapitalCity).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>().HasOne(e => e.DepartureCity).WithMany(e => e.FlightsDep).HasForeignKey(e => e.IdDepartureCity).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Flight>().HasOne(e => e.ArrivalCity).WithMany(e => e.FlightsArr).HasForeignKey(e => e.IdArrivalCity).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>().HasOne(e => e.DepartureFlight).WithMany(e => e.ReservationsDep).HasForeignKey(e => e.IdDepartureFlight).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>().HasOne(e => e.ArrivalFlight).WithMany(e => e.ReservationsArr).HasForeignKey(e => e.IdArrivalFlight).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Card>().HasOne(e => e.Author).WithMany(e => e.Cards).HasForeignKey(e => e.IdAuthor).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trip>().HasOne(e => e.DestinationCity).WithMany(e => e.Trips).HasForeignKey(e => e.IdDestinationCity).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Trip>().HasOne(e => e.Hotel).WithMany(e => e.Trips).HasForeignKey(e => e.IdHotel).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trip>().HasMany(e => e.TripPhotos).WithMany(e => e.Trips).UsingEntity(j => j.ToTable("Trip_TripPhoto"));
            modelBuilder.Entity<Reservation>().HasMany(e => e.Services).WithMany(e => e.Reservations).UsingEntity(j => j.ToTable("Reservation_Service"));

            modelBuilder.Entity<City>().Navigation(e => e.Country).AutoInclude();
            modelBuilder.Entity<Country>().Navigation(e => e.Currency).AutoInclude();
            modelBuilder.Entity<Country>().Navigation(e => e.Language).AutoInclude();
            modelBuilder.Entity<Country>().Navigation(e => e.CountryPhotos).AutoInclude();
            modelBuilder.Entity<Hotel>().Navigation(e => e.Address).AutoInclude();
            modelBuilder.Entity<Hotel>().Navigation(e => e.Photos).AutoInclude();
            modelBuilder.Entity<Address>().Navigation(e => e.City).AutoInclude();
            modelBuilder.Entity<Trip>().Navigation(e => e.DestinationCity).AutoInclude();

            modelBuilder.Entity<Trip>().Navigation(e => e.TripPhotos).AutoInclude();


            base.OnModelCreating(modelBuilder);
        }

    }
}
