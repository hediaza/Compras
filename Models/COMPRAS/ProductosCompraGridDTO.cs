using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.COMPRAS
{
    public class ProductosCompraGridDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int ValorUnitario { get; set; }
        public int ValorTotal { get; set; }
    }
}
