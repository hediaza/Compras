using System.ComponentModel.DataAnnotations;

namespace Models.TIENDAS
{
    public class TiendaDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public int TipoId { get; set; }

        [Required]
        [Display(Name = "Hora de pertura")]
        public int HoraAperturaId { get; set; }

        [Required]
        [Display(Name = "Hora de cierre")]
        public int HoraCierreId { get; set; }
    }
}
