using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FACTURAS
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Cabina")]
        public int Cabina { get; set; }

        [Required]
        [Display(Name = "Fecha Embarque")]
        public DateTime FechaEmbarque { get; set; }

        [Required]
        [Display(Name = "Fecha Desembarque")]
        public DateTime FechaDesembarque { get; set; }

        [Required]
        [Display(Name = "Genero")]
        public string Genero { get; set; }

        [Required]
        [Display(Name = "Tarjeta de credito")]
        public string TargetaCredito { get; set; }

    }

}
