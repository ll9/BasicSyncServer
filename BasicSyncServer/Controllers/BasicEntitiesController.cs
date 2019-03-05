using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasicSyncServer.Models;

namespace BasicSyncServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicEntitiesController : ControllerBase
    {
        private readonly BasicSyncServerContext _context;

        public BasicEntitiesController(BasicSyncServerContext context)
        {
            _context = context;
        }

        // GET: api/BasicEntities
        [HttpGet]
        public IEnumerable<BasicEntity> GetBasicEntity()
        {
            return _context.BasicEntity;
        }

        // GET: api/BasicEntities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasicEntity([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var basicEntity = await _context.BasicEntity.FindAsync(id);

            if (basicEntity == null)
            {
                return NotFound();
            }

            return Ok(basicEntity);
        }

        // PUT: api/BasicEntities/5
        [HttpPut]
        public async Task<IActionResult> PutBasicEntity([FromBody] BasicEntity basicEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            basicEntity.RowVersion = GetNewMaxRowVersion();
            _context.Entry(basicEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction("GetBasicEntity", new { id = basicEntity.Id }, basicEntity);
        }

        // POST: api/BasicEntities
        [HttpPost]
        public async Task<IActionResult> PostBasicEntity([FromBody] BasicEntity basicEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int maxRowVersion = GetNewMaxRowVersion();

            basicEntity.RowVersion = maxRowVersion;
            _context.BasicEntity.Add(basicEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasicEntity", new { id = basicEntity.Id }, basicEntity);
        }

        private int GetNewMaxRowVersion()
        {
            return _context.BasicEntity
                .Select(b => b.RowVersion)
                .DefaultIfEmpty(0)
                .Max() + 1;
        }

        // DELETE: api/BasicEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasicEntity([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var basicEntity = await _context.BasicEntity.FindAsync(id);
            if (basicEntity == null)
            {
                return NotFound();
            }

            _context.BasicEntity.Remove(basicEntity);
            await _context.SaveChangesAsync();

            return Ok(basicEntity);
        }

        private bool BasicEntityExists(string id)
        {
            return _context.BasicEntity.Any(e => e.Id == id);
        }
    }
}