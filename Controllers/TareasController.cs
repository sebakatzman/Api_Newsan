using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")] //Marca la clase con el [ApiController]atributo. Este atributo indica que el controlador responde a las solicitudes de API web
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly TareaContext _context; //Inyecta el contexto de la BDD en el controlador.

        public TareasController(TareaContext context)
        {
            _context = context;
        }

        // GET: api/Tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTarea(string description = null, string state = null)
        {
          if (_context.Tarea == null)
          {
              return NotFound();
          }
            IQueryable<Tarea> query = _context.Tarea;
            if (description != "nada") //Lo hao de esta forma por que no puedo encontrar como enviar null o vacio los parametros !
                query = query.Where(d => d.description.Contains(description));
            if (state != "nada")
                query = query.Where(d => d.state == state);
            return await query.ToListAsync();
        }

        // GET: api/Tareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetTarea(long id)
        {
          if (_context.Tarea == null)
          {
              return NotFound();
          }
            var tarea = await _context.Tarea.FindAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            return tarea;
        }

        // PUT: api/Tareas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarea(long id, Tarea tarea)
        {
            if (id != tarea.id)
            {
                return BadRequest();
            }

            _context.Entry(tarea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TareaExists(id))
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

        // POST: api/Tareas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tarea>> PostTarea(Tarea tarea)
        {
          if (_context.Tarea == null)
          {
              return Problem("Entity set 'TareaContext.Tarea'  is null.");
          }
            _context.Tarea.Add(tarea);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTarea", new { id = tarea.id }, tarea);
            //nameof se usa para evitar codificar el nombre de la acción en la CreatedAtActionllamada.
            return CreatedAtAction(nameof(GetTarea), new { id = tarea.id}, tarea); //Esto retorna un codigo de estado http 201(Resupuesta estandar para exito en POST) si tiene exito.
        }

        // DELETE: api/Tareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(long id)
        {
            if (_context.Tarea == null)
            {
                return NotFound();
            }
            var tarea = await _context.Tarea.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            _context.Tarea.Remove(tarea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TareaExists(long id)
        {
            return (_context.Tarea?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
