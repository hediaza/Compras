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

    public class TiendaRepository : ITiendasRepository
    {
        private IDbConnector db;

        public TiendaRepository(IDbConnector db) {
            this.db = db;
        }

        public int Registrar(TiendaDTO tiendaDTO, IDbTransaction atom = null) {
            int id = db.GetConnection().QuerySingle<int>(@"INSERT INTO dbo.Tiendas(Nombre)
                                                            OUTPUT Inserted.ID
                                                            VALUES(@Nombre);", tiendaDTO, atom);

            return id;
        }
    }
}
