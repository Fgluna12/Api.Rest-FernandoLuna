using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Api.Rest
{
    public class RepoAlumno
    {
        public static string _path = @"C:\Users\Fer\Desktop\Fernando Luna\Instituto Superior Nuestra Señora de La Paz\3ER AÑO LA PAZ\Api.Rest\Api.Rest/Json_Ejemplo.json";
        public string GetAlumnos()
        {
            string AlumnosJson;
            using (var reader = new StreamReader(_path))
            {
                AlumnosJson = reader.ReadToEnd();
            }
            return AlumnosJson;
        }
        public void SerializedJson(List<Alumnos> alumnos)
        {
            var Js = JsonConvert.SerializeObject(alumnos, Formatting.Indented);
            File.WriteAllText(_path, Js);
        }
        public void DeserializeJsonFile(string AlumnosJson)
        {
            JsonConvert.DeserializeObject<List<Alumnos>>(AlumnosJson);
        }
    }
}