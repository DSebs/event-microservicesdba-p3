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
    public partial class AgregarOrganizador : Form
    {
        private ServicioOrganizador servicioOrganizador;
        public AgregarOrganizador(ServicioOrganizador servicioOrganizador)
        {
            InitializeComponent();
            this.servicioOrganizador = servicioOrganizador;
        }

        private void AgregarOrganizador_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                string nombre = txtNombre.Text;
                double presupuesto = Convert.ToDouble(txtPresupuesto.Text);
                DateTime fundacion = dtpFundacion.Value;
                string ceo = txtCeo.Text;

                servicioOrganizador.AgregarOrganizador(id, nombre, presupuesto, fundacion, ceo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
