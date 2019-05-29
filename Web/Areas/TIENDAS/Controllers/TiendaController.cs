using BusinessLogic.TIENDAS;
using Common.Utils;
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
        public ActionResult Actualizar()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public JsonResult Actualizar(TiendaDTO tiendaDTO) {
            throw new NotImplementedException();
        }

        #endregion

        #region DELETE
        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region OTROS
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}