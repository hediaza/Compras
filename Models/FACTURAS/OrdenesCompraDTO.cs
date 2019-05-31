using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FACTURAS
{
    public class OrdenesCompraDTO
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Required]
        [Display(Name = "Valor")]
        public int Total { get; set; }

        [Required]
        [Range(0, 1)]
        [Display(Name = "Estado")]
        public int Estado { get; set; }

        [Required]
        [Display(Name = "Tienda")]
        public int TiendaId { get; set; }

    }
}
