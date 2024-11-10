using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad
{
    public class ClaseEntidad
    {
    }

    public class Chofer
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Cedula { get; set; }
    }

    public class Autobus
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }
        public int Año { get; set; }
    }

    public class Ruta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class Asignacion
{
    public string ChoferNombre { get; set; }
    public string AutobusMarca { get; set; }
    public string RutaNombre { get; set; }
}

}
