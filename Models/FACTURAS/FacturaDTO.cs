using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FACTURAS
{
    public class FacturaDTO
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Cabina { get; set; }

        [Required]
        [Display(Name = "Fecha Embarque")]
        public DateTime FechaEmbarque { get; set; }

        [Required]
        [Display(Name = "Fecha Desembarque")]
        public DateTime FechaDesembarque { get; set; }

        [Required]
        [Display(Name = "Codigo")]
        public int Total { get; set; }

        [Display(Name = "Codigo")]
        public string Codigo { get; set; }

        public IEnumerable<OrdenesCompraDTO> Ordenes { get; set; }
    }
}
