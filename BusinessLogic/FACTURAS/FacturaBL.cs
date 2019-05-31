using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.FACTURAS;
using Repository.FACTURAS;
using SqlServerDB;
using Common.Utils;

namespace BusinessLogic.FACTURAS
{
    public class FacturaBL: BaseBL
    {
        #region INIT
        private FacturaRepository _repository;

        public FacturaBL(IDbConnector db)
        {
            _db = db;
            _repository = new FacturaRepository(_db);
        }
        #endregion

        #region READ
        public Result<IEnumerable<FacturaGridDTO>> ListarGrid()
        {
            // Inicializaciones
            var result = new Result<IEnumerable<FacturaGridDTO>>();

            // Registra entidad
            try
            {
                result.Data = _repository.ListarGrid();
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
                return result;
            }

            // Salida satisfcatoria
            result.Success = true;
            result.Message = "Transacción realizada satisfactoriamente.";
            return result;
        }
        #endregion

        #region CREATE
        public Result<int> Registrar(FacturaDTO facturaDTO)
        {
            // Inicializaciones
            var result = new Result<int>();

            // Registra entidad
            try
            {
                result.Data = _repository.Registrar(facturaDTO);
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
                return result;
            }

            // Salida satisfcatoria
            result.Success = true;
            result.Message = "El producto se registro satisfactoriamente.";
            return result;
        }
        #endregion

        #region READ
        public Result<IEnumerable<ClienteDTO>> ListarCliente()
        {
            // Inicializaciones
            var result = new Result<IEnumerable<ClienteDTO>>();

            // Registra entidad
            try
            {
                result.Data = _repository.ListarCliente();
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
                return result;
            }

            // Salida satisfcatoria
            result.Success = true;
            result.Message = "Transacción realizada satisfactoriamente.";
            return result;
        }

        #endregion



        #region READ
        public Result<IEnumerable<OrdenesCompraDTO>> ListarOrdenes(int id)
        {
            // Inicializaciones
            var result = new Result<IEnumerable<OrdenesCompraDTO>>();

            // Registra entidad
            try
            {
                result.Data = _repository.ListarOrdenesCompra(id);
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
                return result;
            }

            // Salida satisfcatoria
            result.Success = true;
            result.Message = "Transacción realizada satisfactoriamente.";
            return result;
        }

        #endregion

    }
}
