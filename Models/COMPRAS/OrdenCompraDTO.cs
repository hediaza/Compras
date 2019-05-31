using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.COMPRAS
{
    public class OrdenCompraDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int Total { get; set; }
        public int TiendaId { get; set; }
    }
}
