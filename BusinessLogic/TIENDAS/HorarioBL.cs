using Common.Utils;
using Models.TIENDAS;
using Repository.TIENDAS;
using SqlServerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.TIENDAS
{
    public class HorarioBL : BaseBL
    {
        #region INIT
        private HorarioRepository _repository;

        public HorarioBL(IDbConnector db)
        {
            _db = db;
            _repository = new HorarioRepository(_db);
        }
        #endregion

        public Result<IEnumerable<HorarioDTO>> ListarDropDown()
        {
            // Inicializaciones
            var result = new Result<IEnumerable<HorarioDTO>>();
            IEnumerable<HorarioDTO> list;

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
