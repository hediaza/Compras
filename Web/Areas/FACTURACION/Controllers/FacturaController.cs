using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.FACTURAS;
using Models.FACTURAS;
using DbConnector;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Common.Utils;

namespace Web.Areas.FACTURACION.Controllers
{
    public class FacturaController : Web.Controllers.BaseController
    {
        private FacturaBL _bl;

        public FacturaController()
        {
            _db = new DapperSqlServerConnector();
            _bl = new FacturaBL(_db);
        }

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


        [HttpGet]
        public ActionResult Registrar()
        {
            var modelo = new FacturaDTO();
            return PartialView(modelo);
        }

        [HttpGet]
        public ActionResult TraerOrdenes(int id)
        {
            ViewBag.id = id;
            return null;
        }


        public JsonResult ListarCliente([DataSourceRequest]DataSourceRequest request)
        {

            var listarDropDown = _bl.ListarCliente();
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

        

        public JsonResult ListarOrdenes([DataSourceRequest]DataSourceRequest request, int id)
        {

            var listarDropDown = _bl.ListarOrdenes(id);
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



        [HttpPost]
        public JsonResult Registrar(FacturaDTO facturaDTO)
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

            facturaDTO.Codigo = Guid.NewGuid().ToString();

            // Acceso a logicas de negocio
            var registrar = _bl.Registrar(facturaDTO);
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


    }
}
