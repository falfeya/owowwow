
using CRM.API.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiaryController : ControllerBase
    {
        private readonly DiaryContext _db;

        public DiaryController(DiaryContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<Application>> Get()
        {
            var notes = await _db.Application.ToListAsync();

            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> Get(int id)
        {
            var note = await _db.Application.FirstOrDefaultAsync(x => x.Id == id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpPost]
        public async Task<ActionResult<Application>> Post(Application note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Application.Add(note);
            await _db.SaveChangesAsync();

            return Ok(note);
        }

        [HttpPut]
        public async Task<ActionResult<Application>> Put(Application note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_db.Application.Any(x => x.Id == note.Id))
            {
                return NotFound();
            }

            _db.Update(note);
            await _db.SaveChangesAsync();

            return Ok(note);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Application>> Delete(int id)
        {
            var note = await _db.Application.FirstOrDefaultAsync(x => x.Id == id);

            if (note == null)
            {
                return NotFound();
            }

            _db.Application.Remove(note);
            await _db.SaveChangesAsync();

            return Ok(note);
        }


    }
}
