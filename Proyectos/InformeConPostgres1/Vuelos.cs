using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformeConPostgres1
{
    public class Vuelos
    {

        public Vuelos(string vuelo_id,string origen,string destino,string costo) {
            
            this.vuelo_id = vuelo_id;
            this.origen = origen;
            this.destino = destino;
            this.costo = costo;

        }
        public string vuelo_id {  get; set; }
        public string origen {  get; set; }
        public string destino {  get; set; }
        public string costo { get; set; }
    }
}
