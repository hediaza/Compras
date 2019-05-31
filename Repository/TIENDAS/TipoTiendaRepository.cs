using Dapper;
using Models.GLOBAL;
using Models.TIENDAS;
using DbConnector;
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
        IEnumerable<TipoTiendaDTO> ListarDropDown();
    }

    public class TipoTiendaRepository : BaseRepository, ITipoTiendaRepository
    {
        #region INIT
        public TipoTiendaRepository(IDbConnector db) {
            _db = db;
        }
        #endregion

        public IEnumerable<TipoTiendaDTO> ListarDropDown() {
            var list = _db.GetConnection()
                          .Query<TipoTiendaDTO>(@"SELECT t.Id, 
                                                         t.Nombre, 
                                                         t.Codigo
                                                  FROM dbo.TipoTienda t;");

            return list;
        }
    }
}
