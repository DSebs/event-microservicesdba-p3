using dotnet_eventmng_p3.Modelo;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_eventmng_p3.Servicio
{
  
    public class ServicioFeriaGastro
    {
        private readonly RestClient _client;

        public ServicioFeriaGastro(RestClient client)
        {
            _client = client;
        }

        public void AgregarFeria(int id, string nombre, double precio, DateTime fecha, string tipo, List<int> organizadorIds)
        {
            FeriaGastro feriaGastro = new FeriaGastro(id,nombre,precio,fecha,tipo,organizadorIds);
            var jsonBody = JsonConvert.SerializeObject(feriaGastro);
            var request = new RestRequest("/crear", Method.Post);

            request.AddHeader("Content-Type", "application/json");
            request.AddStringBody(jsonBody, DataFormat.Json);

            var response = _client.Execute(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error al agregar feria: {response.ErrorMessage}");
            }
            else
            {
                MessageBox.Show("Feria creada exitosamente");
            }
        }


        public FeriaGastro BuscarFeriaPorId(int id)
        {
            var request = new RestRequest($"/buscar/{id}", Method.Get);
            var response = _client.Execute<FeriaGastro>(request);
            if (response.IsSuccessful)
            {
                FeriaGastro feria = JsonConvert.DeserializeObject<FeriaGastro>(response.Content);
                return feria;
            }
            else
            {
                throw new Exception("Error al obetener los datos del concierto");
            }
        }

        public FeriaGastro BuscarFeriaPorNomrbe(string nombre)
        {
            var request = new RestRequest($"/buscar/nombre/{nombre}", Method.Get);
            var response = _client.Execute<FeriaGastro>(request);
            if (response.IsSuccessful)
            {
                FeriaGastro feria = JsonConvert.DeserializeObject<FeriaGastro>(response.Content);
                return feria;
            }
            else
            {
                throw new Exception("Error al obetener los datos del concierto");
            }
        }

        public void ActualizarFeria(int idFeriaExistente, int id, string nombre, double precio, DateTime fecha, string tipo, List<int> organizadorIds)
        {
            FeriaGastro feria = new FeriaGastro(id, nombre, precio, fecha, tipo, organizadorIds);
            var jsonBody = JsonConvert.SerializeObject(feria);

            var request = new RestRequest($"/{idFeriaExistente}", Method.Put);

            request.AddHeader("Content-Type", "application/json");
            request.AddStringBody(jsonBody, DataFormat.Json);

            var response = _client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error al actualizar concierto: {response.ErrorMessage}");
            }
            else
            {
                MessageBox.Show("Concierto actualizado con éxito");
            }
        }



        public void EliminarFeria(int id)
        {
            var request = new RestRequest($"/eliminar/{id}", Method.Delete);
            var response = _client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error al eliminar feria: {response.ErrorMessage}");
            }
            else
            {
                MessageBox.Show("Feria eliminado exitosamente");
            }
        }

        public List<FeriaGastro> ListarFerias()
        {
            var request = new RestRequest("/listar", Method.Get);
            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                List<FeriaGastro> ferias = JsonConvert.DeserializeObject<List<FeriaGastro>>(response.Content);
                return ferias;
            }
            else
            {
                throw new Exception($"Error al listar ferias: {response.ErrorMessage}");
            }
        }

        public List<FeriaGastro> ListarConciertosMax(string precioMiax)
        {
            var request = new RestRequest($"/listar/precio/{precioMiax}", Method.Get);
            var response = _client.Execute(request);
            if (response.IsSuccessful)
            {
                List<FeriaGastro> ferias = JsonConvert.DeserializeObject<List<FeriaGastro>>(response.Content);
                return ferias;
            }
            else
            {
                throw new Exception($"Error al listar ferias con precio mínimo {precioMiax}: {response.ErrorMessage}");
            }
        }
    }
}
