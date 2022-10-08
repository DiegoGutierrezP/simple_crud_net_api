using Microsoft.AspNetCore.Mvc;
using simple_crud.Context;
using simple_crud.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace simple_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColegioController : ControllerBase
    {
        private readonly AppDbContext context;
        public ColegioController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<ColegioController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Colegio> colegios = context.colegio.ToList();

            return Ok(new { 
                result = true, 
                data = colegios
            }) ; 
        }

        // GET api/<ColegioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Colegio colegio = context.colegio.Where(c => c.id == id).FirstOrDefault();

            return Ok(new
            {
                result = true,
                data = colegio
            });
        }

        // POST api/<ColegioController>
        [HttpPost]
        public IActionResult Post([FromBody] ColegioRequest request)
        {
            Colegio col = new Colegio()
            {
                nombreColegio = request.nombre,
                codUbigeo = request.codUbigeo,
                estado = request.estado
            };
            context.colegio.Add(col);
            context.SaveChanges();

            return Ok(new
            {
                result = true,
                msg = "colegio creado correctamente"
            });
        }

        // PUT api/<ColegioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ColegioRequest request)
        {
            Colegio col = context.colegio.FirstOrDefault(c => c.id == id);

            if(col == null)
            {
                return NotFound(new
                {
                    res = false,
                    Message = "El colegio no existe",
                });
            }

            col.nombreColegio = request.nombre;
            col.codUbigeo = request.codUbigeo;
            col.estado = request.estado;
            context.SaveChanges();

            return Ok(new
            {
                res = true,
                msg = "Colegio Actualizado correctamente"
            });

        }

        // DELETE api/<ColegioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Colegio col = context.colegio.FirstOrDefault(c => c.id == id);

            if (col == null)
            {
                return NotFound(new
                {
                    res = false,
                    Message = "El colegio no existe",
                });
            }

            col.estado = false;
            context.SaveChanges();

            return Ok(new
            {
                res = true,
                msg = "Colegio Eliminado correctamente"
            });

        }
    }
}
