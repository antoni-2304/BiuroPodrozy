using BiuroPodrozyAPI.CMS;
using BiuroPodrozyAPI.DTOs;
using BiuroPodrozyAPI.TravelAgency;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiuroPodrozyAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TripsController : ControllerBase
	{
		private readonly BiuroPodrozyContext _context;
		public TripsController(BiuroPodrozyContext context)
		{
			_context = context;
		}

		// GET: api/Trips
		[HttpGet]
		public async Task<ActionResult<IEnumerable<TripDTO>>> GetTrip()
		{
			ICollection<TripDTO> trips = new List<TripDTO>();

			foreach (var item in await _context.Trip.ToListAsync())
			{
				TripDTO tripDTO = new TripDTO()
				{
					IdTrip = item.IdTrip,
					TripName = item.TripName,
					TripCode = item.TripCode,
					TripCostPerAdult = item.TripCostPerAdult,
					TripCostPerChild = item.TripCostPerChild,
					TripType = item.TripType,
					TripDescription = item.TripDescription,
					IdDestinationCity = item.IdDestinationCity,
					DestinationCityName = item.DestinationCity?.CityName ?? " ",
					IdHotel = item.IdHotel,
					HotelName = item.Hotel?.HotelName ?? " ",
					Photos = item.TripPhotos.Select(p => p.PhotoPath.ToString()).ToList()

				};
				trips.Add(tripDTO);
			}

			return Ok(trips);
		}

		// GET: api/Trips/5
		[HttpGet("{id}")]
		public async Task<ActionResult<TripDTO>> GetTrip(int id)
		{
			var trip = await _context.Trip.FirstOrDefaultAsync(i => i.IdTrip == id);

			if (trip == null)
			{
				return NotFound();
			}

			return new TripDTO()
			{
				IdTrip = trip.IdTrip,
				TripName = trip.TripName,
				TripCode = trip.TripCode,
				TripCostPerAdult = trip.TripCostPerAdult,
				TripCostPerChild = trip.TripCostPerChild,
				TripType = trip.TripType,
				TripDescription = trip.TripDescription,
				IdDestinationCity = trip.IdDestinationCity,
				DestinationCityName = trip.DestinationCity?.CityName ?? " ",
				IdHotel = trip.IdHotel,
				HotelName = trip.Hotel?.HotelName ?? " ",
				Photos = trip.TripPhotos.Select(p => p.PhotoPath.ToString()).ToList()
			};
		}

		// PUT: api/Trips/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTrip(int id, TripDTO trip)
		{
			var entity = await _context.Trip.FindAsync(trip.IdTrip);

			if (entity == null)
			{
				return BadRequest();
			}
			try
			{
				entity.TripName = trip.TripName;
				entity.TripCode = trip.TripCode;
				entity.TripCostPerAdult = trip.TripCostPerAdult;
				entity.TripCostPerChild = trip.TripCostPerChild;
				entity.TripType = trip.TripType;
				entity.TripDescription = trip.TripDescription;
				entity.IdDestinationCity = trip.IdDestinationCity;
				entity.DestinationCity = await _context.City.FirstOrDefaultAsync(c => c.IdCity == trip.IdDestinationCity);
				entity.IdHotel = trip.IdHotel;
				entity.Hotel = await _context.Hotel.FirstOrDefaultAsync(h => h.IdHotel == trip.IdHotel);


				foreach (var photo in entity.TripPhotos)
				{
					photo.Trips.Remove(entity);
				}
				entity.TripPhotos.Clear();

				foreach (var photo in trip.Photos ?? new List<string>())
				{
					if (photo != null)
					{
						Uri uri = new Uri(photo, UriKind.Relative);
						var photoFound = _context.TripPhoto.FirstOrDefault(e => e.PhotoPath == uri);
						if (photoFound != null)
						{
							photoFound.Trips.Add(entity);
							entity.TripPhotos.Add(photoFound);
						}
						else
						{
							var newPhoto = new TripPhoto()
							{
								Trips = new List<Trip>() { entity },
								PhotoPath = new Uri(photo, UriKind.Relative)
							};

							_context.Add(newPhoto);
							entity.TripPhotos.Add(newPhoto);
						}
					};
				}

				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TripExists(trip.IdTrip))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return Ok();
		}

		// POST: api/Cities
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<TripDTO>> PostTrip(TripDTO trip)
		{
			try
			{
				var entity = new Trip()
				{
					TripName = trip.TripName,
					TripCode = trip.TripCode,
					TripCostPerAdult = trip.TripCostPerAdult,
					TripCostPerChild = trip.TripCostPerChild,
					TripType = trip.TripType,
					TripDescription = trip.TripDescription,
					IdDestinationCity = trip.IdDestinationCity,
					DestinationCity = await _context.City.FirstOrDefaultAsync(c => c.IdCity == trip.IdDestinationCity),
					IdHotel = trip.IdHotel,
					Hotel = await _context.Hotel.FirstOrDefaultAsync(h => h.IdHotel == trip.IdHotel)
				};
				foreach (var photo in trip.Photos ?? new List<string>())
				{
					if (photo != null)
					{
						Uri uri = new Uri("Photos/" + photo, UriKind.Relative);
						var photoFound = _context.TripPhoto.FirstOrDefault(e => e.PhotoPath == uri);
						if (photoFound != null)
						{
							photoFound.Trips.Add(entity);
						}
						else
						{
							_context.Add(new TripPhoto()
							{
								Trips = new List<Trip>() { entity },
								PhotoPath = new Uri("Photos/" + photo, UriKind.Relative)
							});
						}
					};
				}
				_context.Add(entity);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (TripExists(trip.IdTrip))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return Ok(trip);
		}

		// DELETE: api/Trips/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTrip(int id)
		{
			var trip = await _context.Trip.FindAsync(id);
			if (trip == null)
			{
				return NotFound();
			}

			_context.Trip.Remove(trip);
			await _context.SaveChangesAsync();

			return Ok();
		}

		private bool TripExists(int id)
		{
			return _context.Trip.Any(e => e.IdTrip == id);
		}
	}
}
