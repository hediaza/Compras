using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.COMPRAS
{
    public class CompraDTO
    {
        public int Id { get; set; }

        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public DateTime Fecha { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        public int Total { get; set; }

        public int OrdenesCompraId { get; set; }

        public IEnumerable<ProductosCompraGridDTO> ProductosCompra { get; set; }

        public int TiendaId { get; set; }
    }
}
