using dotnet_eventmng_p3.Modelo;
using dotnet_eventmng_p3.Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotnet_eventmng_p3.Vista
{
    public partial class ListarFerias : Form
    {
        private ServicioFeriaGastro servicioFeriaGastro;

        public ListarFerias(ServicioFeriaGastro servicioFeriaGastro)
        {
            InitializeComponent();
            this.servicioFeriaGastro = servicioFeriaGastro;
        }

        private void txtOrganizadores_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                List<FeriaGastro> listaFerias = servicioFeriaGastro.ListarFerias();
                var feriasModificados = listaFerias.Select(f => new
                {
                    f.id,
                    f.nombre,
                    f.precio,
                    f.fechaRealizacion,
                    f.tipo,
                    OrganizadorIDs = string.Join(", ", f.organizadorIds)
                }).ToList();

                tblFerias.DataSource = feriasModificados;
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
                double precioMax = double.Parse(txtFiltroPrecioMax.Text, CultureInfo.InvariantCulture);
                string precioMaxString = precioMax.ToString(CultureInfo.InvariantCulture);

                List<FeriaGastro> listaFerias = servicioFeriaGastro.ListarConciertosMax(precioMaxString);
                var feriasModificados = listaFerias.Select(f => new
                {
                    f.id,
                    f.nombre,
                    f.precio,
                    f.fechaRealizacion,
                    f.tipo,
                    OrganizadorIDs = string.Join(", ", f.organizadorIds)
                }).ToList();

                tblFerias.DataSource = feriasModificados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
