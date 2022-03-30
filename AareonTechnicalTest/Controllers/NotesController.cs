using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AareonTechnicalTest;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public NotesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notes>>> GetNotes()
        {
            return await _context.Notes.ToListAsync();
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notes>> GetNotes(int id)
        {
            var notes = await _context.Notes.FindAsync(id);

            if (notes == null)
            {
                return NotFound();
            }

            return notes;
        }

        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotes(int id, Notes notes)
        {
            if (id != notes.Id)
            {
                return BadRequest();
            }

            _context.Entry(notes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotesExists(id))
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

        // POST: api/Notes
        [HttpPost]
        public async Task<ActionResult<Notes>> PostNotes(Notes notes)
        {
            _context.Notes.Add(notes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotes", new { id = notes.Id }, notes);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotes(int id)
        {
            var notes = await _context.Notes.FindAsync(id);
            if (notes == null)
            {
                return NotFound();
            }

            var person = _context.Persons.Find(notes.PersonId);

            if (person == null)
            {
                return NotFound();
            }

            if (person.IsAdmin)
            {

                _context.Notes.Remove(notes);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            else
                return Content(String.Format("Can not delete the notes as the user {0} is not an Admin",person.Forename + ' ' + person.Surname));
        }

        private bool NotesExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
    }
}
