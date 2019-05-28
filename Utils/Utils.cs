using System.IO;
using System.Web;

namespace Common.Utils
{
    public static class Utils {
        /// <summary>
        /// Metodo que retorna la ubicación del archivo javascript basado en el nombre de la vista donde se esta invocando
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns>path de archivo javascript</returns>
        public static string GetJsFilePath(string virtualPath) {
            var path = (string)(Path.GetDirectoryName(virtualPath).Replace("Views", "Scripts") + "\\" + Path.GetFileNameWithoutExtension(virtualPath) + ".js").Replace("\\", "/");
            path = string.Format("{0}", path);
            return path;
        }

        /// <summary>
        /// Retorna ubicacion de almacenamiento temporal
        /// </summary>
        /// <returns></returns>
        public static string GetUploadFilesTmpPath()
        {
            var path = HttpContext.Current.Server.MapPath("~/App_Data/Storage/TEMP");
            return path;
        }

        /// <summary>
        /// Retorna ubicacion de almacenamiento segun el area dada
        /// </summary>
        /// <param name="area">Area</param>
        /// <returns>Retorna ubicacion de almacenamiento segun el area dada</returns>
        public static string GetStorageFilesPathByArea(string area)
        {
            var path = HttpContext.Current.Server.MapPath("~/App_Data/Storage/" + area);
            return path;
        }
  
    }
}
