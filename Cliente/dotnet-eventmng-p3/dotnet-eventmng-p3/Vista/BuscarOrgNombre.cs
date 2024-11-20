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
    public partial class BuscarOrgNombre : Form
    {
        private ServicioOrganizador servicioOrganizador;
        public BuscarOrgNombre(ServicioOrganizador servicioOrganizador)
        {
            InitializeComponent();
            this.servicioOrganizador = servicioOrganizador;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreABuscar = (txtBuscarNombre.Text);
                Organizador organizador = servicioOrganizador.BuscarOrganizadorPorNombre(nombreABuscar);
                txtId.Text = organizador.id.ToString();
                txtNombre.Text = organizador.nombre;
                txtPresupuesto.Text = organizador.presupuesto.ToString();
                txtFundacion.Text = organizador.fundacion.ToString();
                txtCeo.Text = organizador.ceo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
