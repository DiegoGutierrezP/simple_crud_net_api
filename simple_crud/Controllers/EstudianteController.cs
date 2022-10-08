using Microsoft.AspNetCore.Mvc;
using simple_crud.Context;
using simple_crud.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace simple_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly AppDbContext context;
        public EstudianteController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<EstudianteController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Estudiante> estudiantes = context.estudiante.ToList();

            return Ok(new
            {
                result = true,
                data = estudiantes
            });
        }

        // GET api/<EstudianteController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Estudiante estudiante = context.estudiante.Where(c => c.id == id).FirstOrDefault();

            return Ok(new
            {
                result = true,
                data = estudiante
            });
        }

        // POST api/<EstudianteController>
        [HttpPost]
        public IActionResult Post([FromBody] EstudianteRequest request)
        {
            Colegio col = context.colegio.FirstOrDefault(c => c.id == request.colegioId);

            if(col == null)
            {
                return BadRequest(new
                {
                    result = false,
                    msg = "el colegio no existe"
                });
            }

            Estudiante est = new Estudiante()
            {
                nombre = request.nombreEstudiante,
                apellidos = request.apellidos,
                numDoc = request.numDoc,
                estado = request.estado,
                colegioId = request.colegioId
            };
            context.estudiante.Add(est);
            context.SaveChanges();

            return Ok(new
            {
                result = true,
                msg = "estudiante creado correctamente"
            });
        }

        // PUT api/<EstudianteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EstudianteRequest request)
        {
            var est = context.estudiante.FirstOrDefault(es => es.id == id);

            if(est == null)
            {
                return NotFound(new
                {
                    result = false,
                    msg = "estudiante NO ENCONTRADO"
                });
            }

            est.nombre = request.nombreEstudiante;
            est.numDoc = request.numDoc;
            est.apellidos = request.apellidos;
            est.estado = request.estado;
            est.colegioId = request.colegioId;

            context.SaveChanges();

            return Ok(new
            {
                result = true,
                msg = "estudiante creado correctamente"
            });
        }

        // DELETE api/<EstudianteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Estudiante estudiante = context.estudiante.FirstOrDefault(c => c.id == id);

            if (estudiante == null)
            {
                return NotFound(new
                {
                    res = false,
                    Message = "El estudiante no existe",
                });
            }

            estudiante.estado = false;
            context.SaveChanges();

            return Ok(new
            {
                res = true,
                msg = "Estudiante Eliminado correctamente"
            });
        }
    }
}
