using BiuroPodrozyAPI.CMS;
using BiuroPodrozyAPI.DTOs;
using BiuroPodrozyAPI.TravelAgency;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BiuroPodrozyAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CountriesController : ControllerBase
	{
		private readonly BiuroPodrozyContext _context;

		public CountriesController(BiuroPodrozyContext context)
		{
			_context = context;
		}

		// GET: api/Countries
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CountryDTO>>> GetCountry()
		{
			ICollection<CountryDTO> countries = new List<CountryDTO>();

			foreach (var item in await _context.Country.Include(x => x.CapitalCity).ToListAsync())
			{
				CountryDTO countryDTO = new CountryDTO()
				{
					IdCountry = item.IdCountry,
					CountryName = item.CountryName,
					AbbrCountryName = item.AbbrCountryName,
					Continent = item.Continent,
					Population = item.Population,
					CountrySize = item.CountrySize,
					PhoneCode = item.PhoneCode,
					IdCurrency = item.IdCurrency,
					CurrencyName = item.Currency?.CurrencyName ?? " ",
					IdLanguage = item.IdLanguage,
					LanguageName = item.Language?.LanguageName ?? " ",
					IdCapitalCity = item.IdCapitalCity,
					CapitalCityName = item.CapitalCity?.CityName ?? " ",
					Photos = item.CountryPhotos.Select(p => p.PhotoPath.ToString()).ToList()
				};
				countries.Add(countryDTO);
			}

			return Ok(countries);
		}

		// GET: api/Countries/5
		[HttpGet("{id}")]
		public async Task<ActionResult<CountryDTO>> GetCountry(int id)
		{
			var country = await _context.Country.Include(x => x.CapitalCity).FirstOrDefaultAsync(i => i.IdCountry == id);

			if (country == null)
			{
				return NotFound();
			}

			return new CountryDTO()
			{
				IdCountry = country.IdCountry,
				CountryName = country.CountryName,
				AbbrCountryName = country.AbbrCountryName,
				Continent = country.Continent,
				Population = country.Population,
				CountrySize = country.CountrySize,
				PhoneCode = country.PhoneCode,
				IdCurrency = country.IdCurrency,
				CurrencyName = country.Currency?.CurrencyName ?? " ",
				IdLanguage = country.IdLanguage,
				LanguageName = country.Language?.LanguageName ?? " ",
				IdCapitalCity = country.IdCapitalCity,
				CapitalCityName = country.CapitalCity?.CityName ?? " ",
				Photos = _context.CountryPhoto.Where(p => p.IdCountry == id).Select(p => p.PhotoPath.ToString()).ToList()
			};
		}

		// PUT: api/Countries/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCountry(int id, CountryDTO country)
		{
			var entity = await _context.Country.Include(x => x.CapitalCity).FirstOrDefaultAsync(c => c.IdCountry == id);

			if (entity == null)
			{
				return BadRequest();
			}
			_context.CountryPhoto.RemoveRange(await _context.CountryPhoto.Where(p => p.IdCountry == id).ToListAsync());
			try
			{
				entity.CountryName = country.CountryName;
				entity.AbbrCountryName = country.AbbrCountryName;
				entity.Continent = country.Continent;
				entity.Population = country.Population;
				entity.CountrySize = country.CountrySize;
				entity.PhoneCode = country.PhoneCode;
				entity.IdCurrency = country.IdCurrency;
				entity.Currency = await _context.Currency.FirstOrDefaultAsync(c => c.IdCurrency == country.IdCurrency);
				entity.IdLanguage = country.IdLanguage;
				entity.Language = await _context.Language.FirstOrDefaultAsync(l => l.IdLanguage == country.IdLanguage);
				entity.IdCapitalCity = country.IdCapitalCity;
				entity.CapitalCity = await _context.City.FirstOrDefaultAsync(c => c.IdCity == country.IdCapitalCity);
				foreach (var photo in country.Photos ?? new List<string>())
				{
					if (photo != null)
					{
						_context.Add(new CountryPhoto()
						{
							IdCountry = country.IdCountry,
							Country = entity,
							PhotoPath = new Uri(photo, UriKind.Relative)
						});
					}
				}
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CountryExists(id))
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

		// POST: api/Countries
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<CountryDTO>> PostCountry(CountryDTO country)
		{
			try
			{
				var entity = new Country()
				{
					CountryName = country.CountryName,
					AbbrCountryName = country.AbbrCountryName,
					Continent = country.Continent,
					Population = country.Population,
					CountrySize = country.CountrySize,
					PhoneCode = country.PhoneCode,
					IdCurrency = country.IdCurrency,
					Currency = await _context.Currency.FirstOrDefaultAsync(c => c.IdCurrency == country.IdCurrency),
					IdLanguage = country.IdLanguage,
					Language = await _context.Language.FirstOrDefaultAsync(l => l.IdLanguage == country.IdLanguage),
					IdCapitalCity = country.IdCapitalCity,
					CapitalCity = await _context.City.FirstOrDefaultAsync(c => c.IdCity == country.IdCapitalCity)

				};
				foreach (var photo in country.Photos ?? new List<string>())
				{
					if (photo != null)
					{
						_context.Add(new CountryPhoto()
						{
							IdCountry = country.IdCountry,
							Country = entity,
							PhotoPath = new Uri("Photos/" + photo, UriKind.Relative)
						});
					}
				}
				_context.Add(entity);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (CountryExists(country.IdCountry))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return Ok(country);
		}

		// DELETE: api/Countries/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCountry(int id)
		{
			var country = await _context.Country.Include(x => x.CapitalCity).FirstOrDefaultAsync(c => c.IdCountry == id);
			if (country == null)
			{
				return NotFound();
			}

			_context.Country.Remove(country);
			await _context.SaveChangesAsync();

			return Ok();
		}

		private bool CountryExists(int id)
		{
			return _context.Country.Any(e => e.IdCountry == id);
		}
	}
}
