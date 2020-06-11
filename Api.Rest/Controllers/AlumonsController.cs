using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumonsController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            try
            {

                RepoAlumno _alumno = new RepoAlumno();
                var alumno = _alumno.GetAlumnos();
                _alumno.DeserializeJsonFile(alumno);
                return Ok(alumno.ToString());
            }
            catch
            {
                return BadRequest("Error");
            }
        }
            [HttpGet("{DNI}")]
            public ActionResult<string> Get(string DNI)
        {
            return "value";
        }
        [HttpPost]
        public void Post([FromBody]Alumnos _alumnos)
        {
            RepoAlumno _RepoAlumno = new RepoAlumno();
            var alumnos = _RepoAlumno.GetAlumnos();
            _RepoAlumno.DeserializeJsonFile(alumnos);

            var list = JsonConvert.DeserializeObject<List<Alumnos>>(alumnos);
            list.Add(new Alumnos
            {
                DNI = _alumnos.DNI,
                Nombre = _alumnos.Nombre,
                Apellido = _alumnos.Apellido,
                Curso = _alumnos.Curso,
                Año = _alumnos.Año
            });
            _RepoAlumno.SerializedJson(list);
        }
    }
}