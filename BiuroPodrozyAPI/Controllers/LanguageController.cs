using BiuroPodrozyAPI.TravelAgency;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiuroPodrozyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly BiuroPodrozyContext _context;

        public LanguagesController(BiuroPodrozyContext context)
        {
            _context = context;
        }

        // GET: api/Languages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguage()
        {
            if (_context.Language == null)
            {
                return NotFound();
            }
            return await _context.Language.ToListAsync();
        }

        // GET: api/Languages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Language>> GetLanguage(int id)
        {
            if (_context.Language == null)
            {
                return NotFound();
            }
            var language = await _context.Language.FindAsync(id);

            if (language == null)
            {
                return NotFound();
            }

            return language;
        }

        // PUT: api/Languages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage(int id, Language language)
        {
            if (id != language.IdLanguage)
            {
                return BadRequest();
            }

            _context.Entry(language).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(id))
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

        // POST: api/Languages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Language>> PostLanguage(Language language)
        {
            if (_context.Language == null)
            {
                return Problem("Entity set 'OrderDbContext.Items'  is null.");
            }
            _context.Language.Add(language);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LanguageExists(language.IdLanguage))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(language);
        }

        // DELETE: api/Languages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            if (_context.Language == null)
            {
                return NotFound();
            }
            var language = await _context.Language.FindAsync(id);
            if (language == null)
            {
                return NotFound();
            }

            _context.Language.Remove(language);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool LanguageExists(int id)
        {
            return _context.Language.Any(e => e.IdLanguage == id);
        }
    }
}
