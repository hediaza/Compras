using System;
using System.ComponentModel.DataAnnotations;

namespace Models.TIENDAS
{
    public class TiendaGridVM : TiendaDTO
    {

        public string Tipo { get; set; }

        [Display(Name = "Hora de pertura")]
        public string HoraApertura { get; set; }

        [Display(Name = "Hora de cierre")]
        public string HoraCierre { get; set; }
        
    }
}
