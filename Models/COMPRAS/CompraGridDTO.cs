using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.COMPRAS
{
    public class CompraGridDTO
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public int Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}
