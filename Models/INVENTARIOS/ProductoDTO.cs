using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.INVENTARIOS
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name ="Valor")]
        public int Valor { get; set; }

        [Required]
        [Range(0, 100)]
        [Display(Name = "Descuento")]
        public int Descuento { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        [Display (Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Required]
        [Display (Name = "Tienda")]
        public int TiendaId { get; set; }
    }
}
