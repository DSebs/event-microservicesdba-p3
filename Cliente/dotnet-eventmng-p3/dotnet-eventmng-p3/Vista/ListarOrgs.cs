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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace dotnet_eventmng_p3.Vista
{
    public partial class ListarOrgs : Form
    {
        private ServicioOrganizador servicioOrganizador;
        public ListarOrgs(ServicioOrganizador servicioOrganizador)
        {
            InitializeComponent();
            this.servicioOrganizador = servicioOrganizador;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Organizador> listaOrganizador = servicioOrganizador.ListarOrganizadores();
                tblOrganizaciones.DataSource = listaOrganizador;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                string inicial = txtFiltroInicial.Text;
                List<Organizador> listaOrganizador = servicioOrganizador.ListarOrganizadoresInicial(inicial);
                tblOrganizaciones.DataSource = listaOrganizador;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
