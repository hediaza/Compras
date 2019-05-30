using BusinessLogic.INVENTARIOS;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SqlServerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers;

namespace Web.Areas.INVENTARIOS.Controllers
{
    public class ProductoController : BaseController
    {
        #region INIT

        private ProductoBL _bl;

        public ProductoController()
        {
            _db = new DapperConnector();
            _bl = new ProductoBL(_db);
        }
        #endregion

        #region READ
        /// <summary>
        /// Metodo para visualizar el listado de productos en el inventario
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Metodo que trae la lista de los productos de invetarioi
        /// </summary>
        /// <returns></returns>
        public JsonResult ListarGrid([DataSourceRequest]DataSourceRequest request)
        {
            var listarDropDown = _bl.ListarGrid();
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

        #region CREATE
        [HttpGet]
        
        }
        #endregion
    }
}