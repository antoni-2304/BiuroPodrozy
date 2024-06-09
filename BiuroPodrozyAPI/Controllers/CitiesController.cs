using BiuroPodrozyAPI.DTOs;
using BiuroPodrozyAPI.TravelAgency;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiuroPodrozyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly BiuroPodrozyContext _context;

        public CitiesController(BiuroPodrozyContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDTO>>> GetCity()
        {
            ICollection<CityDTO> cities = new List<CityDTO>();

            foreach (var item in await _context.City.ToListAsync())
            {
                CityDTO cityDTO = new CityDTO()
                {
                    IdCity = item.IdCity,
                    CityName = item.CityName,
                    PostalCode = item.PostalCode,
                    Population = item.Population,
                    IdCountry = item.IdCountry,
                    CountryName = item.Country?.CountryName ?? " "
                };
                cities.Add(cityDTO);
            }

            return Ok(cities);
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDTO>> GetCity(int id)
        {
            var city = await _context.City.FirstOrDefaultAsync(i => i.IdCity == id);

            if (city == null)
            {
                return NotFound();
            }

            return new CityDTO()
            {
                IdCity = city.IdCity,
                CityName = city.CityName,
                PostalCode = city.PostalCode,
                Population = city.Population,
                IdCountry = city.IdCountry,
                CountryName = city.Country?.CountryName ?? " "
            };
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, CityDTO city)
        {
            var entity = await _context.City.FindAsync(city.IdCity);

            if (entity == null)
            {
                return BadRequest();
            }

            try
            {
                entity.CityName = city.CityName;
                entity.PostalCode = city.PostalCode;
                entity.Population = city.Population;
                entity.IdCountry = city.IdCountry;
                entity.Country = await _context.Country.FirstOrDefaultAsync(c => c.IdCountry == city.IdCountry);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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
        public async Task<ActionResult<CityDTO>> PostCity(CityDTO city)
        {
            try
            {
                var entity = new City()
                {
                    CityName = city.CityName,
                    PostalCode = city.PostalCode,
                    Population = city.Population,
                    IdCountry = city.IdCountry,
                    Country = await _context.Country.FirstOrDefaultAsync(c => c.IdCountry == city.IdCountry)
                };
                _context.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CityExists(city.IdCity))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _context.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.City.Remove(city);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.IdCity == id);
        }
    }
}
