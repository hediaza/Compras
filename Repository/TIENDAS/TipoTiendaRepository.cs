using Dapper;
using Models.GLOBAL;
using Models.TIENDAS;
using SqlServerDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.TIENDAS
{
    public interface ITipoTiendaRepository
    {
        IEnumerable<SelectListItem2> ListarDropDown();
    }

    public class TipoTiendaRepository : BaseRepository, ITipoTiendaRepository
    {
        public TipoTiendaRepository(IDbConnector db) {
            _db = db;
        }

        public IEnumerable<SelectListItem2> ListarDropDown() {
            throw new NotImplementedException();
        }
    }
}
