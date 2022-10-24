using Labbeh.Data;
using Labbeh.Models;

namespace Labbeh.IRepository
{
    public class AzizTestTType : IAzizTestTType<DriverCompany>
    {
        private readonly DBContext _dBContext;
        public AzizTestTType(DBContext dBContext)
        {
                _dBContext= dBContext;
        }
        public bool Add(DriverCompany add)
        {
            try
            {

                //if (IsDriversCompanyExists(driversCompany.CompanyName)) return false;
                // if (IsValid(driversCompany)) return false;
                _dBContext.driverCompanies.Add(add);
                _dBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //_errors = "Create Failed -sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }
    }
}
