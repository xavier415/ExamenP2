using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeEntidad;

namespace CapaDeDatos
{
    public class Datos
    {
        private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=ExamenBase;Integrated Security=True";

        public void RegistrarChofer(Chofer chofer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarChofer", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", chofer.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", chofer.Apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", chofer.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Cedula", chofer.Cedula);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RegistrarAutobus(Autobus autobus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarAutobus", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Marca", autobus.Marca);
                cmd.Parameters.AddWithValue("@Modelo", autobus.Modelo);
                cmd.Parameters.AddWithValue("@Placa", autobus.Placa);
                cmd.Parameters.AddWithValue("@Color", autobus.Color);
                cmd.Parameters.AddWithValue("@Año", autobus.Año);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RegistrarRuta(Ruta ruta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarRuta", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", ruta.Nombre);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Chofer> ObtenerChoferesDisponibles()
        {
            List<Chofer> choferes = new List<Chofer>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerChoferesDisponibles", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Chofer chofer = new Chofer
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        FechaNacimiento = reader.GetDateTime(3),
                        Cedula = reader.GetString(4)
                    };
                    choferes.Add(chofer);
                }
            }
            return choferes;
        }

        public List<Autobus> ObtenerAutobusesDisponibles()
        {
            List<Autobus> autobuses = new List<Autobus>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerAutobusesDisponibles", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Autobus autobus = new Autobus
                    {
                        Id = reader.GetInt32(0),
                        Marca = reader.GetString(1),
                        Modelo = reader.GetString(2),
                        Placa = reader.GetString(3),
                        Color = reader.GetString(4),
                        Año = reader.GetInt32(5)
                    };
                    autobuses.Add(autobus);
                }
            }
            return autobuses;
        }

        public List<Ruta> ObtenerRutasDisponibles()
        {
            List<Ruta> rutas = new List<Ruta>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerRutasDisponibles", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ruta ruta = new Ruta
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                    };
                    rutas.Add(ruta);
                }
            }
            return rutas;
        }

        public void AsignarChoferAutobusRuta(Asignacion asignacion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AsociarChoferAutobusRuta", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ChoferNombre", asignacion.ChoferNombre);
                cmd.Parameters.AddWithValue("@AutobusMarca", asignacion.AutobusMarca);
                cmd.Parameters.AddWithValue("@RutaNombre", asignacion.RutaNombre);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool EsChoferDisponible(string ChoferNombre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_VerificarChoferDisponible", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ChoferNombre", ChoferNombre);

                connection.Open();
                return (int)cmd.ExecuteScalar() == 0; 
            }
        }
        public bool EsAutobusDisponible(string AutobusMarca)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_VerificarAutobusDisponible", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AutobusMarca", AutobusMarca);

                connection.Open();
                return (int)cmd.ExecuteScalar() == 0; 
            }
        }

        public bool EsRutaDisponible(string RutaNombre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_VerificarRutaDisponible", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RutaNombre", RutaNombre);

                connection.Open();
                return (int)cmd.ExecuteScalar() == 0; 
            }
        }


    }
}
