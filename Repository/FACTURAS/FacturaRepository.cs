using System;
using System.Collections.Generic;
using Models.FACTURAS;
using System.Data;
using Dapper;
using DbConnector;

namespace Repository.FACTURAS
{
    public interface IFacturaRepository
    {
        IEnumerable<FacturaGridDTO> ListarGrid();
        int Registrar( FacturaDTO facturaDTO, IDbTransaction atom = null);
    }

    public class FacturaRepository : BaseRepository, IFacturaRepository
    {

        #region INIT
        public FacturaRepository(IDbConnector db)
        {
            _db = db;
        }
        #endregion

        #region READ
        public IEnumerable<FacturaGridDTO> ListarGrid()
        {
            var list = _db.GetConnection()
                          .Query < FacturaGridDTO>(@"SELECT  p.Id, p.Codigo, p.Total, t.nombre as Cliente FROM dbo.Facturas p INNER JOIN dbo.Clientes t ON ( p.ClienteId = t.Id  );");
            return list;
        }
        #endregion

        #region READ
        public IEnumerable<ClienteDTO> ListarCliente()
        {
            var list = _db.GetConnection()
                          .Query<ClienteDTO>(@"SELECT  p.Id, 
                                                            p.Nombre, 
                                                            p.Cabina, 
                                                            p.FechaEmbarque, 
                                                            p.FechaDesembarque, 
                                                            p.Genero, 
                                                            p.TargetaCredito
                                                          FROM dbo.Clientes p;");
            return list;
        }
        #endregion

        #region READ
        public IEnumerable<OrdenesCompraDTO> ListarOrdenesCompra(int id)
        {
            var list = _db.GetConnection()
                          .Query<OrdenesCompraDTO>(@"select Id, ClienteId,Total,Estado,TiendaId from OrdenesCompras where Estado=0 AND ClienteId=@Id;",new { @Id = id });
            return list;
        }
        #endregion


        #region CREATE
        public int Registrar(FacturaDTO facturaDTO, IDbTransaction atom = null)
        {
            int id = _db.GetConnection()
                        .QuerySingle<int>(@"INSERT INTO dbo.Facturas (Codigo, 
                                                                      Total, 
                                                                      ClienteId) 
                                                                OUTPUT Inserted.ID
                                                                VALUES( @Codigo, 
                                                                        @Total, 
                                                                        @ClienteId);", facturaDTO, atom);
            

            foreach (var orden in facturaDTO.Ordenes)
            {
                _db.GetConnection()
                        .Query<int>(@"INSERT INTO dbo.OrdenesFacturas (OrdenId, 
                                                                      FacturaId) 
                                                                VALUES( @OrdenId, 
                                                                        @FacturaId);", new { OrdenId = orden.Id, FacturaId = id }, atom);
            }
            return id;
        }
        #endregion

        IEnumerable<FacturaGridDTO> IFacturaRepository.ListarGrid()
        {
            throw new NotImplementedException();
        }


    }
}
