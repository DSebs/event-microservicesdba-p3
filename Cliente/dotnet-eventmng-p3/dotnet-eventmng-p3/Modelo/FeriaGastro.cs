using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_eventmng_p3.Modelo
{
    public class FeriaGastro
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public DateTime fechaRealizacion { get; set; }
        public string tipo { get; set; }
        public List<int> organizadorIds { get; set; }

        public FeriaGastro(int id, string nombre, double precio, DateTime fechaRealizacion, string tipo, List<int> organizadorIds)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.fechaRealizacion = fechaRealizacion;
            this.tipo = tipo;
            this.organizadorIds = organizadorIds;
        }
    }
}
