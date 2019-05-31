using Common.Utils;
using Models.TIENDAS;
using Repository.TIENDAS;
using SqlServerDB;
using System;
using System.Collections.Generic;

namespace BusinessLogic.TIENDAS
{
    public class TiendaBL: BaseBL
    {
        #region INIT
        private TiendaRepository _repository;
        
        public TiendaBL(IDbConnector db)
        {
            _db = db;
            _repository = new TiendaRepository(_db);
        }
        #endregion

        public Result<int> Registrar(TiendaDTO tiendaDTO)
        {            
            // Inicializaciones
            var result = new Result<int>();

            // Registra entidad
            try
            {                
                result.Data = _repository.Registrar(tiendaDTO);
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
                return result;
            }

            // Salida satisfcatoria
            result.Success = true;
            result.Message = "La tienda se registro satisfactoriamente.";
            return result;
        }

        public Result<IEnumerable<TiendaGridDTO>> ListarGrid()
        {
            // Inicializaciones
            var result = new Result<IEnumerable<TiendaGridDTO>>();

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

        public Result<IEnumerable<TiendaDTO>> ListarDropDown()
        {
            // Inicializaciones
            var result = new Result<IEnumerable<TiendaDTO>>();

            // Registra entidad
            try
            {
                result.Data = _repository.ListarDropDown();
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

        public Result<TiendaDTO> Obtener(int id)
        {
            // Inicializaciones
            var result = new Result<TiendaDTO>();

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

        public Result Editar(TiendaDTO tiendaDTO)
        {
            // Inicializaciones
            var result = new Result();

            // Editar entidad
            try
            {
                _repository.Editar(tiendaDTO);
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

        public Result Eliminar(int id)
        {
            // Inicializaciones
            var result = new Result();

            // Eliminar entidad
            try
            {
                _repository.Eliminar(id);
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = "No fue posible eliminar el registro seleccionado.";
                return result;
            }

            // Salida satisfcatoria
            result.Success = true;
            result.Message = "La tienda se eliminó satisfactoriamente.";
            return result;
        }
    }
}
