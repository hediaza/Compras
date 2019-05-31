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
        OrdenCompraDetalleDTO Obtener(int id);
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

            // Registro de orden de compra
            var ordenCompraDTO = new OrdenCompraDTO
            {
                ClienteId = compraDTO.ClienteId,
                Total = compraDTO.Total,
                TiendaId = compraDTO.TiendaId
            };

            var id = _db.GetConnection()
               .QuerySingle<int>(@"INSERT INTO dbo.OrdenesCompras (
                                     ClienteId, 
                                     Total, 
                                     TiendaId) 
                                   OUTPUT Inserted.ID
                                   VALUES ( 
                                     @ClienteId, 
                                     @Total, 
                                     @TiendaId);", ordenCompraDTO, atom);

            // Registro de ordenes asociadas a la compra
            var compras = compraDTO.ProductosCompra.Select(item => new CompraDTO
            {
                ProductoId = item.Id,
                Cantidad = item.Cantidad,
                ClienteId = compraDTO.ClienteId,
                Total = item.ValorTotal,
                OrdenesCompraId = id
            });

            _db.GetConnection()
               .Execute(@"INSERT INTO dbo.Compras
	                                    (ProductoId, 
	                                     Cantidad, 
                                         ClienteId, 
                                         Total, 
                                         OrdenesCompraId)
                                    VALUES (@ProductoId, 
	                                        @Cantidad, 	                                        
                                            @ClienteId, 
                                            @Total, 
                                            @OrdenesCompraId);", compras, atom);


            return id;
        }
        #endregion

        #region READ
        public IEnumerable<CompraGridDTO> ListarGrid()
        {
            var list = _db.GetConnection()
                          .Query<CompraGridDTO>(@"SELECT o.Id, 
                                                         o.Total, 
                                                         o.Fecha, 
                                                         c.Nombre as Cliente
                                                  FROM dbo.OrdenesCompras o 
	                                                  INNER JOIN dbo.Clientes c ON ( o.ClienteId = c.Id );");

            return list;
        }

        public OrdenCompraDetalleDTO Obtener(int id)
        {
            var ordenCompraDetalleDTO = _db.GetConnection()
                                       .QuerySingle<OrdenCompraDetalleDTO>(@"SELECT o.Id, o.ClienteId, o.Total, o.Estado, o.TiendaId, o.Fecha
                                                                            FROM dbo.OrdenesCompras o
                                                                            WHERE o.Id = @Id;", new { Id = id });

            ordenCompraDetalleDTO.ProductosCompra = _db.GetConnection()
                                 .Query<ProductosCompraGridDTO>(@"SELECT c.Id, c.Cantidad, c.Total as ValorTotal, p.Nombre, p.Valor as ValorUnitario
                                                                FROM dbo.Compras c 
	                                                                INNER JOIN dbo.Productos p ON ( c.ProductoId = p.Id  )  
                                                                WHERE c.OrdenesCompraId = @Id;", new { Id = id });

            return ordenCompraDetalleDTO;
        }
        #endregion

    }
}
