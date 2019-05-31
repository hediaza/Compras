using Common.Utils;
using Models.GLOBAL;
using Models.TIENDAS;
using Repository.TIENDAS;
using DbConnector;
using System;
using System.Collections.Generic;

namespace BusinessLogic.TIENDAS
{
    public class TipoTiendaBL: BaseBL
    {
        #region INIT
        private TipoTiendaRepository _repository;

        public TipoTiendaBL(IDbConnector db)
        {
            _db = db;
            _repository = new TipoTiendaRepository(_db);
        }
        #endregion

        public Result<IEnumerable<TipoTiendaDTO>> ListarDropDown()
        {
            // Inicializaciones
            var result = new Result<IEnumerable<TipoTiendaDTO>>();
            IEnumerable<TipoTiendaDTO> list;

            // Acceso al repositorio
            try
            {
                list = _repository.ListarDropDown();
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = "No fue posible listar la información solicitada.";
                return result;
            }

            // Salida SUCCESS
            result.Success = true;
            result.Data = list;
            return result;
        }

    }
}
