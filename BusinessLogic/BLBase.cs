using SqlServerDB;

namespace BusinessLogic
{
    public class BLBase
    {
        protected DapperConnector Db { get; set; }

        public BLBase() {
            Db = new DapperConnector();
        }
    }
}
