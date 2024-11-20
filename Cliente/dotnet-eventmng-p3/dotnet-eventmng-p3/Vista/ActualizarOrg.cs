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
    public partial class ActualizarOrg : Form
    {
        private ServicioOrganizador servicioOrganizador;
        public ActualizarOrg(ServicioOrganizador servicioOrganizador)
        {
            InitializeComponent();
            this.servicioOrganizador = servicioOrganizador;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtBuscarID.Text);
                Organizador organizador = servicioOrganizador.BuscarOrganizadorPorId(id);
                txtId.Text = organizador.id.ToString();
                txtNombre.Text = organizador.nombre;
                txtPresupuesto.Text = organizador.presupuesto.ToString();
                dtpFundacion.Value = organizador.fundacion;
                txtCeo.Text = organizador.ceo;

                txtId.Enabled = true;
                txtNombre.Enabled = true;
                txtPresupuesto.Enabled = true;
                dtpFundacion.Enabled = true;
                txtCeo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int idABuscar = Convert.ToInt32(txtBuscarID.Text);
                int id = Convert.ToInt32(txtId.Text);
                string nombre = txtNombre.Text;
                double presupuesto = Convert.ToDouble(txtPresupuesto.Text);
                DateTime fundacion = dtpFundacion.Value;
                string ceo = txtCeo.Text;

                servicioOrganizador.ActualizarOrganizador(idABuscar, id, nombre,presupuesto, fundacion, ceo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
