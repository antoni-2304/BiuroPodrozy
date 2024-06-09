using BiuroPodrozyAPI.CMS;
using BiuroPodrozyAPI.DTOs;
using BiuroPodrozyAPI.TravelAgency;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiuroPodrozyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly BiuroPodrozyContext _context;

        public HotelsController(BiuroPodrozyContext context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotel()
        {
            ICollection<HotelDTO> hotels = new List<HotelDTO>();

            foreach (var item in await _context.Hotel.ToListAsync())
            {
                HotelDTO hotelDTO = new HotelDTO()
                {
                    IdHotel = item.IdHotel,
                    HotelName = item.HotelName,
                    HotelStars = item.HotelStars,
                    HotelRating = item.HotelRating,
                    Phone = item.Phone,
                    Email = item.Email,
                    Description = item.Description ?? " ",
                    HotelPricePerUnit = item.HotelPricePerUnit,
                    IdAddress = item.IdAddress,
                    Street = item.Address?.Street ?? " ",
                    HomeNr = item.Address?.HomeNr ?? " ",
                    IdCity = item.Address?.IdCity ?? -1,
                    CityName = item.Address?.City?.CityName ?? " ",
                    Latitude = item.Address?.Latitude ?? 0,
                    Longitude = item.Address?.Longitude ?? 0

                };
                hotels.Add(hotelDTO);
            }
            return Ok(hotels);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
            var hotel = await _context.Hotel.FirstOrDefaultAsync(i => i.IdHotel == id);

            if (hotel == null)
            {
                return NotFound();
            }

            return new HotelDTO()
            {
                IdHotel = hotel.IdHotel,
                HotelName = hotel.HotelName,
                HotelStars = hotel.HotelStars,
                HotelRating = hotel.HotelRating,
                Phone = hotel.Phone,
                Email = hotel.Email,
                Description = hotel.Description ?? " ",
                HotelPricePerUnit = hotel.HotelPricePerUnit,
                IdAddress = hotel.IdAddress,
                Street = hotel.Address?.Street ?? " ",
                HomeNr = hotel.Address?.HomeNr ?? " ",
                IdCity = hotel.Address?.IdCity ?? -1,
                CityName = hotel.Address?.City?.CityName ?? " ",
                Latitude = hotel.Address?.Latitude ?? 0,
                Longitude = hotel.Address?.Longitude ?? 0,
                Photos = _context.HotelPhoto.Where(p => p.IdHotel == id).Select(p => p.PhotoPath.ToString()).ToList()
            };
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDTO hotel)
        {

            var entity = await _context.Hotel.FindAsync(hotel.IdHotel);
            var entityAddress = entity.Address;
            _context.HotelPhoto.RemoveRange(await _context.HotelPhoto.Where(p => p.IdHotel == id).ToListAsync());
            if (entity == null)
            {
                return BadRequest();
            }

            try
            {
                entity.HotelName = hotel.HotelName;
                entity.HotelStars = hotel.HotelStars;
                entity.HotelRating = hotel.HotelRating;
                entity.Phone = hotel.Phone;
                entity.Email = hotel.Email;
                entity.Description = hotel.Description ?? " ";
                entity.HotelPricePerUnit = hotel.HotelPricePerUnit;
                entityAddress.Street = hotel.Street;
                entityAddress.HomeNr = hotel.HomeNr;
                entityAddress.IdCity = hotel.IdCity;
                entityAddress.City = await _context.City.FirstOrDefaultAsync(c => c.IdCity == hotel.IdCity);
                entityAddress.Latitude = hotel.Latitude;
                entityAddress.Longitude = hotel.Longitude;
                foreach (var photo in hotel.Photos ?? new List<string>())
                {
                    if (photo != null)
                    {
                        _context.Add(new HotelPhoto()
                        {
                            IdHotel = hotel.IdHotel,
                            Hotel = entity,
                            PhotoPath = new Uri(photo, UriKind.Relative)
                        });
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelDTO>> PostHotel(HotelDTO hotel)
        {
            try
            {
                var entityAddress = new Address()
                {
                    Street = hotel.Street,
                    HomeNr = hotel.HomeNr,
                    IdCity = hotel.IdCity,
                    City = await _context.City.FirstOrDefaultAsync(c => c.IdCity == hotel.IdCity),
                };
                var entity = new Hotel()
                {
                    HotelName = hotel.HotelName,
                    HotelStars = hotel.HotelStars,
                    HotelRating = hotel.HotelRating,
                    Phone = hotel.Phone,
                    Email = hotel.Email,
                    Description = hotel.Description ?? " ",
                    HotelPricePerUnit = hotel.HotelPricePerUnit,
                    IdAddress = hotel.IdAddress,
                    Address = entityAddress
                };
                foreach (var photo in hotel.Photos ?? new List<string>())
                {
                    if (photo != null)
                    {
                        _context.Add(new HotelPhoto()
                        {
                            IdHotel = hotel.IdHotel,
                            Hotel = entity,
                            PhotoPath = new Uri("Photos/" + photo, UriKind.Relative)
                        });
                    }
                }
                _context.Add(entityAddress);
                _context.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HotelExists(hotel.IdHotel))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Address.Remove(hotel.Address);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool HotelExists(int id)
        {
            return _context.Hotel.Any(e => e.IdHotel == id);
        }
    }
}
