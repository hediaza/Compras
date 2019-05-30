using Dapper;
using Models.TIENDAS;
using SqlServerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.TIENDAS
{
    public interface ITipoHorarioRepository
    {
        IEnumerable<HorarioDTO> ListarDropDown();
    }

    public class HorarioRepository : BaseRepository, ITipoHorarioRepository
    {
        #region INIT
        public HorarioRepository(IDbConnector db)
        {
            _db = db;
        }
        #endregion

        public IEnumerable<HorarioDTO> ListarDropDown() {
            var list = _db.GetConnection().Query<HorarioDTO>(@"SELECT h.Id, 
                                                                    h.Nombre 
                                                               FROM dbo.Horarios h ;");

            return list;
        }
    }
}
