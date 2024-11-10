using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeDatos;
using CapaDeEntidad;
using CapaDeNegocio;

namespace Capa_de_Presentacion
{
    public partial class Form1 : Form
    {
        private Negocio negocio = new Negocio();

        public Form1()
        {
            InitializeComponent();
            CargarChoferes();  
            CargarAutobuses(); 
            CargarRutas();
        }

        private void RegistrarChofer_Click(object sender, EventArgs e)
        {
            Chofer chofer = new Chofer
            {
                Nombre = txtNombreChofer.Text,
                Apellido = txtApellidoChofer.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Cedula = txtCedulaChofer.Text
            };
            negocio.RegistrarChofer(chofer);
        }

        private void RegistrarAutobus_Click(object sender, EventArgs e)
        {
            Autobus autobus = new Autobus
            {
                Marca = txtMarca.Text,
                Modelo = txtModelo.Text,
                Placa = txtPlaca.Text,
                Color = txtColor.Text,
                Año = int.Parse(txtAño.Text)
            };
            negocio.RegistrarAutobus(autobus);
        }

        private void RegistrarRuta_Click(object sender, EventArgs e)
        {
            Ruta ruta = new Ruta
            {
                Nombre = txtRuta.Text
            };
            negocio.RegistrarRuta(ruta);
        }

        private void Asignar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (cboChoferes.SelectedValue == null || cboAutobuses.SelectedValue == null || cboRutas.SelectedValue == null)
                {
                    MessageBox.Show("Asignacion Realizada con Exito");
                    return;
                }

                
                string choferNombre = (string)cboChoferes.SelectedValue;
                string marcaAutobus = (string)cboAutobuses.SelectedValue;
                string rutaNombre = (string)cboRutas.SelectedValue;

                
                if (!negocio.EsChoferDisponible(choferNombre))
                {
                    MessageBox.Show("El chofer seleccionado ya esta asignado a otro autobus.");
                    return;
                }

                if (!negocio.EsAutobusDisponible(marcaAutobus))
                {
                    MessageBox.Show("El autobus seleccionado ya esta asignado a otra ruta.");
                    return;
                }

                if (!negocio.EsRutaDisponible(rutaNombre))
                {
                    MessageBox.Show("La ruta seleccionada ya tiene un autobus asignado.");
                    return;
                }

               
                Asignacion asignacion = new Asignacion
                {
                    ChoferNombre = choferNombre,
                    AutobusMarca = marcaAutobus,
                    RutaNombre = rutaNombre
                };

               
                negocio.AsignarChoferAutobusRuta(asignacion);

                
                MessageBox.Show("Asignacion realizada con exito.");

                
                cboChoferes.SelectedIndex = -1;
                cboAutobuses.SelectedIndex = -1;
                cboRutas.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Ocurrio un error al intentar realizar la asignacion: " + ex.Message);
            }
        }




        private void CargarChoferes()
        {
            List<Chofer> choferes = negocio.ObtenerChoferesDisponibles();

            cboChoferes.DataSource = choferes; 
            cboChoferes.DisplayMember = "Nombre"; 
            cboChoferes.ValueMember = "Nombre"; 
        }

        

       
        private void CargarAutobuses()
        {
            List<Autobus> autobuses = negocio.ObtenerAutobusesDisponibles();

            cboAutobuses.DataSource = autobuses; 
            cboAutobuses.DisplayMember = "Marca"; 
            cboAutobuses.ValueMember = "Marca"; 
        }



       
        private void CargarRutas()
        {
            List<Ruta> rutas = negocio.ObtenerRutasDisponibles();

            cboRutas.DataSource = rutas; 
            cboRutas.DisplayMember = "Nombre"; 
            cboRutas.ValueMember = "Nombre"; 
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }

}
