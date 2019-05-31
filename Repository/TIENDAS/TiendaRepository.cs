using Dapper;
using Models.TIENDAS;
using SqlServerDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.TIENDAS
{
    public interface ITiendasRepository
    {
        int Registrar(TiendaDTO tiendaDTO, IDbTransaction atom);
        IEnumerable<TiendaGridDTO> ListarGrid();
        TiendaDTO Obtener(int id);
        void Editar(TiendaDTO tiendaDTO, IDbTransaction atom = null);
        void Eliminar(int id, IDbTransaction atom = null);
    }

    public class TiendaRepository : BaseRepository, ITiendasRepository
    {
        #region INIT
        public TiendaRepository(IDbConnector db) {
            _db = db;
        }
        #endregion

        #region CREATE
        public int Registrar(TiendaDTO tiendaDTO, IDbTransaction atom = null) {           
            int id = _db.GetConnection()
                        .QuerySingle<int>(@"INSERT INTO dbo.Tiendas (Nombre, 
                                                                    TipoId, 
                                                                    HorarioAperturaId, 
                                                                    HorarioCierreId) 
                                                            OUTPUT Inserted.ID
                                                            VALUES (@Nombre, 
                                                                    @TipoId, 
                                                                    @HorarioAperturaId, 
                                                                    @HorarioCierreId);", tiendaDTO, atom);

            return id;
        }
        #endregion

        public IEnumerable<TiendaGridDTO> ListarGrid() {
            var list = _db.GetConnection()
                          .Query<TiendaGridDTO>(@"SELECT t.Id, 
	                                                     t.Nombre, 
                                                         t1.Nombre as Tipo, 
	                                                     h.Nombre as HorarioApertura, 
	                                                     h1.Nombre as HorarioCierre
                                                FROM dbo.Tiendas t 
	                                                INNER JOIN dbo.TipoTienda t1 ON ( t.TipoId = t1.Id  )  
	                                                INNER JOIN dbo.Horarios h ON ( t.HorarioAperturaId = h.Id  )  
	                                                INNER JOIN dbo.Horarios h1 ON ( t.HorarioCierreId = h1.Id  );");

            return list;
        }

        public IEnumerable<TiendaDTO> ListarDropDown()
        {
            var list = _db.GetConnection()
                          .Query<TiendaDTO>(@"SELECT t.Id, 
                                                     t.Nombre
                                             FROM dbo.Tiendas t;");

            return list;
        }

        public TiendaDTO Obtener(int id) {
            var tiendaDTO = _db.GetConnection()
                               .QuerySingle<TiendaDTO>(@"SELECT t.Id, 
                                                                t.Nombre, 
                                                                t.TipoId, 
                                                                t.HorarioAperturaId, 
                                                                t.HorarioCierreId
                                                        FROM dbo.Tiendas t
                                                        WHERE t.Id = @Id;", new { Id = id });

            return tiendaDTO;
        }

        #region UPDATE
        public void Editar(TiendaDTO tiendaDTO, IDbTransaction atom = null)
        {
            _db.GetConnection()
               .Execute(@"UPDATE dbo.Tiendas
                            SET Nombre = @Nombre,
                                TipoId = @TipoId,
                                HorarioAperturaId = @HorarioAperturaId,
                                HorarioCierreId = @HorarioCierreId
                            WHERE Id = @Id;", tiendaDTO, atom);
        }
        #endregion

        #region DELETE
        public void Eliminar(int id, IDbTransaction atom = null)
        {
            _db.GetConnection()
               .Execute(@"DELETE FROM dbo.Tiendas
                          WHERE Id = @Id;", new { Id = id }, atom);
        }
        #endregion
    }
}
