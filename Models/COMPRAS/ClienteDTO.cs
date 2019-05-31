using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.COMPRAS
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cabina { get; set; }
        public DateTime FechaEmbarque { get; set; }
        public DateTime FechaDesembarque { get; set; }
        public string Genero { get; set; }
        public string TarjetaCredito { get; set; }
        public string DocumentoIdentificacion { get; set; }
    }
}
