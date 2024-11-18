﻿using dotnet_eventmng_p3.Modelo;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace dotnet_eventmng_p3.Servicio
{
    public class ServicioOrganizador
    {
        private readonly RestClient _client;

        public ServicioOrganizador(RestClient client)
        {
            _client = client;
        }

        public void AgregarOrganizador(int id, string nombre, double presupuesto, DateTime fundacion, string ceo)
        {
            Organizador organizador = new Organizador(id, nombre, presupuesto, fundacion, ceo);
            var jsonBody = JsonConvert.SerializeObject(organizador);

            var request = new RestRequest("/crear", Method.Post);

            request.AddHeader("Content-Type", "application/json");
            request.AddStringBody(jsonBody, DataFormat.Json);

            var response = _client.Execute(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error al agregar organizador: {response.ErrorMessage}");
            }
            else
            {
                MessageBox.Show("Organizador creado exitosamente");
            }
        }

        public Organizador BuscarOrganizadorPorId(int id)
        {
            var request = new RestRequest($"/buscar/id/{id}", Method.Get);
            var response = _client.Execute<Organizador>(request);
            if (response.IsSuccessful)
            {
                Organizador organizador = JsonConvert.DeserializeObject<Organizador>(response.Content);
                return organizador;
            }
            else
            {
                throw new Exception("Error al obetener los datos de la cancion");
            }
        }

        public Organizador BuscarOrganizadorPorNombre(string nombre)
        {
            var request = new RestRequest($"/buscar/nombre/{nombre}", Method.Get);
            var response = _client.Execute<Organizador>(request);
            if (response.IsSuccessful)
            {
                Organizador organizador = JsonConvert.DeserializeObject<Organizador>(response.Content);
                return organizador;
            }
            else
            {
                throw new Exception("Error al obetener los datos de la cancion");
            }
        }

        public void ActualizarOrganizador(int idOrganizadorExistente, int id, string nombre, double presupuesto, DateTime fundacion, string ceo)
        {
            Organizador organizador = new Organizador(id, nombre, presupuesto, fundacion, ceo);
            var jsonBody = JsonConvert.SerializeObject(organizador);

            var request = new RestRequest($"/{idOrganizadorExistente}", Method.Put);

            request.AddHeader("Content-Type", "application/json");
            request.AddStringBody(jsonBody, DataFormat.Json);

            var response = _client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error al actualizar organizador: {response.ErrorMessage}");
            }
            else
            {
                MessageBox.Show("Organizador actualizado con exito");
            }
        }

        public void EliminarOrganizador(int id)
        {
            Organizador organizador = BuscarOrganizadorPorId(id);
            var jsonBody = JsonConvert.SerializeObject(organizador);
            var request = new RestRequest($"/eliminar", Method.Delete);

            request.AddHeader("Content-Type", "application/json");
            request.AddStringBody(jsonBody, DataFormat.Json);

            var response = _client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error al eliminar organizador: {response.ErrorMessage}");
            }
            else
            {
                MessageBox.Show("Organizador eliminado exitosamente");
            }
        }

        public List<Organizador> ListarOrganizadores()
        {
            var request = new RestRequest("/listar", Method.Get);
            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                List<Organizador> organizadores = JsonConvert.DeserializeObject<List<Organizador>>(response.Content);
                return organizadores;
            }
            else
            {
                throw new Exception($"Error al listar organizadores: {response.ErrorMessage}");
            }
        }

        public List<Organizador> ListarOrganizadoresMin(string duracionMin)
        {
            var request = new RestRequest($"/listar/duracion/{duracionMin}", Method.Get);
            var response = _client.Execute(request);
            if (response.IsSuccessful)
            {
                List<Organizador> organizadores = JsonConvert.DeserializeObject<List<Organizador>>(response.Content);
                return organizadores;
            }
            else
            {
                throw new Exception($"Error al listar organizadores con... {duracionMin}: {response.ErrorMessage}");
            }
        }
    }
}
