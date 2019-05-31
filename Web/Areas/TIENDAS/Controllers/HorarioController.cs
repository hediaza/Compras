using BusinessLogic.TIENDAS;
using Common.Utils;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using DbConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers;

namespace Web.Areas.TIENDAS.Controllers
{
    public class HorarioController : BaseController
    {
        #region INIT
        private HorarioBL _bl;

        public HorarioController()
        {
            _db = new DapperSqlServerConnector();
            _bl = new HorarioBL(_db);
        }
        #endregion

        #region READ
        public JsonResult ListarDropDown([DataSourceRequest]DataSourceRequest request)
        {

            var listarDropDown = _bl.ListarDropDown();
            if (!listarDropDown.Success)
            {
                ModelState.AddModelError("Error", listarDropDown.Message);
                return Json(Enumerable.Empty<object>().ToDataSourceResult(request, ModelState));
            }

            //Salida Success 
            var ds = new DataSourceResult()
            {
                Data = listarDropDown.Data,
                Total = listarDropDown.Data.Count()
            };
            return Json(ds);
        }
        #endregion
    }
}