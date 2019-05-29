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
        private TiendaBL tiendaBL;        

        public TiendaController() {
            db = new DapperConnector();
            tiendaBL = new TiendaBL(db);
        }
     
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
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
            var registrar = tiendaBL.Registrar(tiendaDTO);
            if (!registrar.Success)
            {
                result.Success = false;
                return Json(result);
            }

            // Salida
            result.Success = true;
            result.Message = registrar.Message;
            result.Data = registrar.Data;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}