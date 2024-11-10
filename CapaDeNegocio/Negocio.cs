using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeEntidad;
using CapaDeDatos;

namespace CapaDeNegocio
{
    public class Negocio
    {
        private Datos datos = new Datos();

        public void RegistrarChofer(Chofer chofer)
        {
            datos.RegistrarChofer(chofer);
        }

        public void RegistrarAutobus(Autobus autobus)
        {
            datos.RegistrarAutobus(autobus);
        }

        public void RegistrarRuta(Ruta ruta)
        {
            datos.RegistrarRuta(ruta);
        }

        public List<Chofer> ObtenerChoferesDisponibles()
        {
            return datos.ObtenerChoferesDisponibles();
        }

        public List<Autobus> ObtenerAutobusesDisponibles()
        {
            return datos.ObtenerAutobusesDisponibles();
        }

        public List<Ruta> ObtenerRutasDisponibles()
        {
            return datos.ObtenerRutasDisponibles();
        }

        public void AsignarChoferAutobusRuta(Asignacion asignacion)
        {
            datos.AsignarChoferAutobusRuta(asignacion);
        }

        public bool EsChoferDisponible(string ChoferNombre)
        {
            return datos.EsChoferDisponible(ChoferNombre);
        }

        public bool EsAutobusDisponible(string AutobusMarca)
        {
            return datos.EsAutobusDisponible(AutobusMarca);
        }

        public bool EsRutaDisponible(string RutaNombre)
        {
            return datos.EsRutaDisponible(RutaNombre);
        }
    }
}
