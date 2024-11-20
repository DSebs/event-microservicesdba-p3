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
    public partial class ActualizarFeria : Form
    {
        private ServicioFeriaGastro servicioFeriaGastro;
        public ActualizarFeria(ServicioFeriaGastro servicioFeriaGastro)
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
                dtpFecha.Value = feriaGastro.fechaRealizacion;
                txtTipo.Text = feriaGastro.tipo;
                txtOrganizadores.Text = string.Join(", ", feriaGastro.organizadorIds);

                txtNombre.Enabled = true;
                txtPrecio.Enabled = true;
                dtpFecha.Enabled = true;
                txtTipo.Enabled = true;
                txtOrganizadores.Enabled = true;
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
                servicioFeriaGastro.ActualizarFeria(idABuscar, id, nombre, precio, fecha, tipo, organizadorIds);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

