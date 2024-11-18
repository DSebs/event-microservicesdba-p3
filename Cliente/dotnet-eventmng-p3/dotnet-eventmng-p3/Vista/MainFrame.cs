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
            AgregarFeria agregarFeria = new AgregarFeria();
            agregarFeria.Show();
        }

        private void buscarFeriaPorIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarFeriaId buscarFeriaId = new BuscarFeriaId();
            buscarFeriaId.Show();
        }

        private void buscarFeriaPorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarFeriaNombre buscarFeriaNombre = new BuscarFeriaNombre();
            buscarFeriaNombre.Show();
        }

        private void actualizarFeriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizarFeria actualizarFeria = new ActualizarFeria();
            actualizarFeria.Show();
        }

        private void eliminarFeriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarFeria eliminarFeria = new EliminarFeria();
            eliminarFeria.Show();
        }

        private void listarFeriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarFerias listarFerias = new ListarFerias();
            listarFerias.Show();
        }
    }
}
