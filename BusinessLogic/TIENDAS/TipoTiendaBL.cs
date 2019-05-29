using Common.Utils;
using Models.GLOBAL;
using Models.TIENDAS;
using Repository.TIENDAS;
using SqlServerDB;
using System;
using System.Collections.Generic;

namespace BusinessLogic.TIENDAS
{
    public class TipoTiendaBL: BaseBL
    {
        private TipoTiendaRepository _repository;
        
        public TipoTiendaBL(IDbConnector db)
        {
            _db = db;
            _repository = new TipoTiendaRepository(_db);
        }

        public Result<IEnumerable<SelectListItem2>> ListarDropDown()
        {
            // Inicializaciones
            var result = new Result<IEnumerable<SelectListItem2>>();
            IEnumerable<SelectListItem2> list;

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
