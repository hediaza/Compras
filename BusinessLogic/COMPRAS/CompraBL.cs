using Common.Utils;
using Models.COMPRAS;
using Models.TIENDAS;
using Repository.COMPRAS;
using Repository.TIENDAS;
using DbConnector;
using System;
using System.Collections.Generic;

namespace BusinessLogic.TIENDAS
{
    public class CompraBL: BaseBL
    {
        #region INIT
        private CompraRepository _repository;
        
        public CompraBL(IDbConnector db)
        {
            _db = db;
            _repository = new CompraRepository(_db);
        }
        #endregion

        #region CREATE
        public Result<int> Registrar(CompraDTO compraDTO)
        {            
            // Inicializaciones
            var result = new Result<int>();
            var atom = _db.GetConnection().BeginTransaction();

            // Acceso al repositorio
            try
            {                

                result.Data = _repository.Registrar(compraDTO, atom);
            }
            catch (Exception e)
            {
                atom.Rollback();
                result.Exception = e;
                result.Message = e.Message;
                return result;
            }

            // Salida satisfcatoria
            atom.Commit();
            result.Success = true;
            result.Message = "La tienda se registro satisfactoriamente.";
            return result;
        }
        #endregion

        #region READ
        public Result<IEnumerable<CompraGridDTO>> ListarGrid()
        {
            // Inicializaciones
            var result = new Result<IEnumerable<CompraGridDTO>>();

            // Acceso al repositorio
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

        public Result<OrdenCompraDetalleDTO> Obtener(int id)
        {
            // Inicializaciones
            var result = new Result<OrdenCompraDetalleDTO>();

            // Acceso al repositorio
            try
            {
                result.Data = _repository.Obtener(id);
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
                return result;
            }

            // Salida satisfcatoria
            result.Success = true;
            result.Message = "Trasacción realizada satisfactoriamente";
            return result;
        }

        #endregion
    }
}
