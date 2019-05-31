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
    public class ClienteBL: BaseBL
    {
        #region INIT
        private ClienteRepository _repository;
        
        public ClienteBL(IDbConnector db)
        {
            _db = db;
            _repository = new ClienteRepository(_db);
        }
        #endregion

        #region READ
        public Result<IEnumerable<ClienteDTO>> ListarDropDown()
        {
            // Inicializaciones
            var result = new Result<IEnumerable<ClienteDTO>>();

            // Acceso al repositorio
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
        

        #endregion
    }
}
