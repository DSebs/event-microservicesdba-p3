using dotnet_eventmng_p3.Servicio;
using dotnet_eventmng_p3.Vista;
using RestSharp;
using static System.Windows.Forms.Design.AxImporter;

namespace dotnet_eventmng_p3
{
    public partial class MainFrame : Form
    {
        private ServicioFeriaGastro servicioFeriaGastro;
        private ServicioOrganizador servicioOrganizador;

        private RestClientOptions optionsFeria;
        private RestClient clientFeria;

        private RestClientOptions optionsOrg;
        private RestClient clientOrg;
        public MainFrame()
        {
            InitializeComponent();
            optionsFeria = new RestClientOptions("http://localhost:8090/feriagastro");
            clientFeria = new RestClient(optionsFeria);
            servicioFeriaGastro = new ServicioFeriaGastro(clientFeria);

            optionsOrg = new RestClientOptions("http://localhost:8090/organizador");
            clientOrg = new RestClient(optionsOrg);
            servicioOrganizador = new ServicioOrganizador(clientOrg);
        }

        private void agregarFeriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarFeria agregarFeria = new AgregarFeria(servicioFeriaGastro);
            agregarFeria.Show();
        }

        private void buscarFeriaPorIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarFeriaId buscarFeriaId = new BuscarFeriaId(servicioFeriaGastro);
            buscarFeriaId.Show();
        }

        private void buscarFeriaPorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarFeriaNombre buscarFeriaNombre = new BuscarFeriaNombre(servicioFeriaGastro);
            buscarFeriaNombre.Show();
        }

        private void actualizarFeriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizarFeria actualizarFeria = new ActualizarFeria(servicioFeriaGastro);
            actualizarFeria.Show();
        }

        private void eliminarFeriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarFeria eliminarFeria = new EliminarFeria(servicioFeriaGastro);
            eliminarFeria.Show();
        }

        private void listarFeriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarFerias listarFerias = new ListarFerias(servicioFeriaGastro);
            listarFerias.Show();
        }

        private void agregarOrganizadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarOrganizador agregarOrganizador = new AgregarOrganizador(servicioOrganizador);
            agregarOrganizador.Show();
        }

        private void buscarOrganizadorPorIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarOrgId buscarOrgId = new BuscarOrgId(servicioOrganizador);
            buscarOrgId.Show();
        }

        private void buscarOrganizadorPorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarOrgNombre buscarOrgNombre = new BuscarOrgNombre(servicioOrganizador);
            buscarOrgNombre.Show();
        }

        private void actualizarOrganizadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizarOrg actualizarOrg = new ActualizarOrg(servicioOrganizador);
            actualizarOrg.Show();
        }

        private void eliminarOrganizadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarOrg eliminarOrg = new EliminarOrg(servicioOrganizador);
            eliminarOrg.Show();
        }

        private void listarOrganizadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarOrgs listarOrgs = new ListarOrgs(servicioOrganizador);
            listarOrgs.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe acercaDe = new AcercaDe();
            acercaDe.Show();
        }
    }
}
