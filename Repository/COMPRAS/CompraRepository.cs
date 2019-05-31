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
    public interface ICompraRepository
    {
        int Registrar(CompraDTO tiendaDTO, IDbTransaction atom);
        IEnumerable<CompraGridDTO> ListarGrid();
        CompraDTO Obtener(int id);
    }

    public class CompraRepository : BaseRepository, ICompraRepository
    {
        #region INIT
        public CompraRepository(IDbConnector db)
        {
            _db = db;
        }
        #endregion

        #region CREATE
        public int Registrar(CompraDTO compraDTO, IDbTransaction atom = null)
        {
            int id = _db.GetConnection()
                        .QuerySingle<int>(@"???", compraDTO, atom);

            return id;
        }
        #endregion

        #region READ
        public IEnumerable<CompraGridDTO> ListarGrid()
        {
            var list = _db.GetConnection()
                          .Query<CompraGridDTO>(@"???");

            return list;
        }

        public CompraDTO Obtener(int id)
        {
            var compraDTO = _db.GetConnection()
                               .QuerySingle<CompraDTO>(@"???", new { Id = id });

            return compraDTO;
        }
        #endregion

    }
}
