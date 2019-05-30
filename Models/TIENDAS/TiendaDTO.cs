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
        [Display(Name = "Hora de apertura")]
        public int HorarioAperturaId { get; set; }

        [Required]
        [Display(Name = "Hora de cierre")]
        public int HorarioCierreId { get; set; }
    }
}
