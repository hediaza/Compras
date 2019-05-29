using Common.Utils;
using Models.TIENDAS;
using Repository.TIENDAS;
using SqlServerDB;
using System;

namespace BusinessLogic.TIENDAS
{
    public class TiendaBL: BaseBL
    {
        private TiendaRepository _repository;
        
        public TiendaBL(IDbConnector db)
        {
            this.db = db;
            _repository = new TiendaRepository(db);
        }

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
    }
}
