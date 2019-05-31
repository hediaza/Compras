using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.COMPRAS
{
    public class OrdenCompraDetalleDTO : CompraDTO
    {
        public string Cliente { get; set; }
        public bool Estado { get; set; }


    }
}
