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
    public partial class AgregarFeria : Form
    {
        private ServicioFeriaGastro servicioFeriaGastro;
        public AgregarFeria(ServicioFeriaGastro servicioFeriaGastro)
        {
            InitializeComponent();
            this.servicioFeriaGastro = servicioFeriaGastro;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AgregarFeria_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                string nombre = txtNombre.Text;
                double precio = Convert.ToDouble(txtPrecio.Text);
                DateTime fecha = dtpFecha.Value;
                string tipo = txtTipo.Text;

                List<int> organizadorIds;

                if (string.IsNullOrWhiteSpace(txtOrganizadores.Text))
                {
                    organizadorIds = new List<int>();
                }
                else
                {
                    organizadorIds = txtOrganizadores.Text
                                    .Split(',')
                                    .Select(int.Parse)
                                    .ToList();
                }

                servicioFeriaGastro.AgregarFeria(id, nombre, precio, fecha, tipo, organizadorIds);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
