using dotnet_eventmng_p3.Modelo;
using dotnet_eventmng_p3.Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotnet_eventmng_p3.Vista
{
    public partial class EliminarFeria : Form
    {
        private ServicioFeriaGastro servicioFeriaGastro;
        public EliminarFeria(ServicioFeriaGastro servicioFeriaGastro)
        {
            InitializeComponent();
            this.servicioFeriaGastro = servicioFeriaGastro;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBuscarID.Text);

                FeriaGastro feriaGastro = servicioFeriaGastro.BuscarFeriaPorId(id);
                txtId.Text = feriaGastro.id.ToString();
                txtNombre.Text = feriaGastro.nombre;
                txtPrecio.Text = feriaGastro.precio.ToString();
                txtFecha.Text = feriaGastro.fechaRealizacion.ToString();
                txtTipo.Text = feriaGastro.tipo;
                txtOrganizadores.Text = string.Join(", ", feriaGastro.organizadorIds);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBuscarID.Text);
                servicioFeriaGastro.EliminarFeria(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
