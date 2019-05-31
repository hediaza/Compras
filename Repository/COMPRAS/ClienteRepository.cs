using Common.Utils;
using Dapper;
using Models.COMPRAS;
using DbConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.COMPRAS
{
    public interface IClienteRepository
    {
        IEnumerable<ClienteDTO> ListarDropDown();
    }

    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        #region INIT
        public ClienteRepository(IDbConnector db)
        {
            _db = db;
        }
        #endregion

        #region READ
        public IEnumerable<ClienteDTO> ListarDropDown()
        {
            var list = _db.GetConnection()
                          .Query<ClienteDTO>(@"SELECT c.Id, 
                                                      c.Nombre + ' (' + c.DocumentoIdentificacion + ')' as Nombre
                                               FROM dbo.Clientes c;");

            return list;
        }

        #endregion

    }
}
