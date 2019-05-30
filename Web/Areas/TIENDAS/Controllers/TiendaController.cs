using BusinessLogic.TIENDAS;
using Common.Utils;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Models.TIENDAS;
using SqlServerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers;

namespace Web.Areas.TIENDAS.Controllers
{
    public class TiendaController : BaseController
    {
        #region INIT
        private TiendaBL _bl;        

        public TiendaController() {
            _db = new DapperConnector();
            _bl = new TiendaBL(_db);
        }
        #endregion

        #region READ

        /// <summary>
        /// Metodo para visualizar el listado de tiendas disponibles
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

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
        public ActionResult Registrar()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult Registrar(TiendaDTO tiendaDTO)
        {
            // Inicializaciones
            var result = new Result<int>();

            // Validaciones
            if (!ModelState.IsValid)
            {
                result.Success = false;
                result.Message = "Verifique la información registrada previmente.";
                return Json(result);
            }

            // Acceso a logicas de negocio
            var registrar = _bl.Registrar(tiendaDTO);
            if (!registrar.Success)
            {
                result.Message = registrar.Message;
                result.Success = false;
                return Json(result);
            }

            // Salida
            result.Success = true;
            result.Message = registrar.Message;
            result.Data = registrar.Data;

            return Json(result);
        }

        #endregion

        #region UPDATE

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var obtener = _bl.Obtener(id);
            if (!obtener.Success) {
                ModelState.AddModelError("Error", obtener.Message);
                return PartialView();
            }

            return PartialView(obtener.Data);
        }

        [HttpPost]
        public JsonResult Editar(TiendaDTO tiendaDTO)
        {
            // Inicializaciones
            var result = new Result();

            // Validaciones
            if (!ModelState.IsValid)
            {
                result.Success = false;
                result.Message = "Verifique la información registrada previmente.";
                return Json(result);
            }

            // Acceso a logicas de negocio
            var editar = _bl.Editar(tiendaDTO);
            if (!editar.Success)
            {
                result.Success = false;
                result.Message = editar.Message;                
                return Json(result);
            }

            // Salida
            result.Success = true;
            result.Message = editar.Message;

            return Json(result);
        }

        #endregion

        #region DELETE
        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            // Inicializaciones
            var result = new Result();

            // Validaciones
            if (!ModelState.IsValid)
            {
                result.Success = false;
                result.Message = "Verifique la información registrada previmente.";
                return Json(result);
            }

            // Acceso a logicas de negocio
            var eliminar = _bl.Eliminar(id);
            if (!eliminar.Success)
            {
                result.Success = false;
                result.Message = eliminar.Message;
                return Json(result);
            }

            // Salida
            result.Success = true;
            result.Message = eliminar.Message;

            return Json(result);
        }
        #endregion

        #region OTROS
       
        #endregion
    }
}