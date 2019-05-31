using Common.Utils;
using Models.INVENTARIOS;
using Repository.INVENTARIOS;
using SqlServerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.INVENTARIOS
{
   public class ProductoBL: BaseBL
    {
        #region INIT
        private ProductoRepository _repository;

        public ProductoBL(IDbConnector db)
        {
            _db = db;
            _repository = new ProductoRepository(_db);
        }
        #endregion

        #region READ
        public Result<IEnumerable<ProductoGridDTO>> ListarGrid()
        {
            // Inicializaciones
            var result = new Result<IEnumerable<ProductoGridDTO>>();

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
        public Result<int> Registrar(ProductoDTO productoDTO)
        {
            // Inicializaciones
            var result = new Result<int>();

            // Registra entidad
            try
            {
                result.Data = _repository.Registrar(productoDTO);
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

        #region UPDATE
        public Result<ProductoDTO> Obtener(int id)
        {
            // Inicializaciones
            var result = new Result<ProductoDTO>();

            // Registra entidad
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

        public Result Editar(ProductoDTO procutoDTO)
        {
            // Inicializaciones
            var result = new Result();

            // Editar entidad
            try
            {
                _repository.Editar(procutoDTO);
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
                return result;
            }

            // Salida satisfcatoria
            result.Success = true;
            result.Message = "La tienda se actualizó satisfactoriamente.";
            return result;
        }
        #endregion



    }
}
