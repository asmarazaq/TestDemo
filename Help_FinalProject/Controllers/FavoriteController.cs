using Help_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Help_FinalProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly HelpContext _context;

        public FavoriteController(HelpContext context)
        {
            _context = context;
        }

        // GET: api/Favorite
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favorite>>> GetFavorites()
        {
            return await _context.Favorites.ToListAsync();
        }

        // GET: api/Favorite/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Favorite>> GetFavorite(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);

            if (favorite == null)
            {
                return NotFound();
            }

            return favorite;
        }

        // POST: api/Favorite
        [HttpPost]
        public async Task<ActionResult<Favorite>> PostFavorite(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFavorite), new { id = favorite.Id }, favorite);
        }

        // PUT: api/Favorite/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorite(int id, Favorite favorite)
        {
            if (id != favorite.Id)
            {
                return BadRequest();
            }

            _context.Entry(favorite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Favorite/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();

            return Ok(favorite);
        }

        private bool FavoriteExists(int id)
        {
            return _context.Favorites.Any(e => e.Id == id);
        }
    }
}