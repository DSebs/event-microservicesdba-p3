using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_eventmng_p3.Modelo
{
    public class Organizador
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double presupuesto { get; set; }
        public DateTime fundacion { get; set; }
        public string ceo { get; set; }

        public Organizador(int id, string nombre, double presupuesto, DateTime fundacion, string ceo)
        {
            this.id = id;
            this.nombre = nombre;
            this.presupuesto = presupuesto;
            this.fundacion = fundacion;
            this.ceo = ceo;
        }
    }
}
