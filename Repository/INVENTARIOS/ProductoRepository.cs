using Dapper;
using Models.INVENTARIOS;
using DbConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.INVENTARIOS
{
    public interface IProductoRepository
    {
        IEnumerable<ProductoGridDTO> ListarGrid();
        int Registrar(ProductoDTO productoDTO, IDbTransaction atom = null);
    }

    public class ProductoRepository : BaseRepository, IProductoRepository
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
                                                                        @Valor,
                                                                        @Codigo);", productoDTO, atom);
            return id;

        }
        #endregion

        #region UPDATE
        public ProductoDTO Obtener(int id)
        {
            var productoDTO = _db.GetConnection()
                               .QuerySingle<ProductoDTO>(@"SELECT   p.Id, 
                                                                    p.Nombre, 
                                                                    p.Cantidad,  
                                                                    p.Descuento,  
                                                                    p.TiendaId,  
                                                                    p.Valor,  
                                                                    p.Codigo
                                                        FROM dbo.Productos p
                                                        WHERE p.Id = @id;", new { Id = id });



            return productoDTO;
        }

        public void Editar(ProductoDTO productoDTO, IDbTransaction atom = null)
        {
            _db.GetConnection()
               .Execute(@"UPDATE dbo.Productos 
                            SET Nombre          = @Nombre,
                                Cantidad        = @Cantidad,
                                Descuento       = @Descuento,
                                TiendaId        = @TiendaId,
                                Valor           = @Valor,
                                Codigo          = @Codigo
                            WHERE Id = @Id;", productoDTO, atom);

        }
        #endregion

        #region DELETE
        public void Eliminar(int id, IDbTransaction atom = null)
        {
            _db.GetConnection()
               .Execute(@"DELETE FROM dbo.Productos
                          WHERE Id = @Id;", new { Id = id }, atom);        }
        #endregion
    }
}

