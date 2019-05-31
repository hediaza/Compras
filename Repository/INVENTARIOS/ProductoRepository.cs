using Dapper;
using Models.INVENTARIOS;
using SqlServerDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.INVENTARIOS
{
    public interface IInventariosRepository
    {

    }

    public class ProductoRepository : BaseRepository, IInventariosRepository
    {

        #region INIT
        public ProductoRepository(IDbConnector db)
        {
            _db = db;
        }
        #endregion

        #region READ
        public IEnumerable<ProductoGridDTO> ListarGrid()
        {
            var list = _db.GetConnection()
                          .Query<ProductoGridDTO>(@"SELECT  p.Id, 
                                                            p.Nombre, 
                                                            p.Cantidad, 
                                                            p.Descuento, 
                                                            p.Valor, 
                                                            p.Codigo, 
                                                            t.Nombre as Producto
                                                     FROM dbo.Productos p 
	                                                        INNER JOIN dbo.Tiendas t ON ( p.TiendaId = t.Id  );");
            return list;
        }
        #endregion

        #region CREATE
        public int Registrar(ProductoDTO productoDTO, IDbTransaction atom = null)
        {
            int id = _db.GetConnection()
                        .QuerySingle<int>(@"INSERT INTO dbo.Productos (Nombre, 
                                                                              Cantidad, 
                                                                              Descuento, 
                                                                              TiendaId, 
                                                                              Valor, 
                                                                              Codigo) 
                                                                        OUTPUT Inserted.ID
                                                                        VALUES( @Nombre, 
                                                                                @Cantidad, 
                                                                                @Descuento,
                                                                                @TiendaId,
                                                                                @Valor
                                                                                @Codigo);", productoDTO, atom);
            return id;

        }
        #endregion

    }
}

