using Dapper;
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
    public interface ITiendasRepository
    {
        int Registrar(TiendaDTO tiendaDTO, IDbTransaction atom);
    }

    public class TiendaRepository : BaseRepository, ITiendasRepository
    {
        public TiendaRepository(IDbConnector db) {
            _db = db;
        }

        public int Registrar(TiendaDTO tiendaDTO, IDbTransaction atom = null) {           
            int id = _db.GetConnection().QuerySingle<int>(@"INSERT INTO dbo.Tiendas (Nombre, 
                                                                                    TipoId, 
                                                                                    HoraApertura, 
                                                                                    MinApertura, 
                                                                                    HoraCierre, 
                                                                                    MinCierre) 
                                                                            OUTPUT Inserted.ID
                                                                            VALUES (@Nombre, 
                                                                                    @TipoId, 
                                                                                    @HoraApertura, 
                                                                                    @MinApertura, 
                                                                                    @HoraCierre,
                                                                                    @MinCierre);", tiendaDTO, atom);

            return id;
        }
    }
}
