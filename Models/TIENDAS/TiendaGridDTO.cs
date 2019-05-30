using System;
using System.ComponentModel.DataAnnotations;

namespace Models.TIENDAS
{
    public class TiendaGridDTO : TiendaDTO
    {

        public string Tipo { get; set; }

        [Display(Name = "Hora de apertura")]
        public string HorarioApertura { get; set; }

        [Display(Name = "Hora de cierre")]
        public string HorarioCierre { get; set; }
        
    }
}
