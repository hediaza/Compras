using BusinessLogic.TIENDAS;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SqlServerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers;

namespace Web.Areas.TIENDAS.Controllers
{
    public class TipoTiendaController : BaseController
    {
        #region INIT
        private TipoTiendaBL _bl;

        public TipoTiendaController()
        {
            _db = new DapperSqlServerConnector();
            _bl = new TipoTiendaBL(_db);
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