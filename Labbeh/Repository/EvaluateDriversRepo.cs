using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Microsoft.EntityFrameworkCore;

namespace Labbeh.Repository
{
    public class EvaluateDriversRepo : IEvaluateDriversRepo
    {
        private readonly DBContext context;
        private string _errors = "";
        public EvaluateDriversRepo(DBContext context)
        {
            this.context = context;
        }

        public bool Create(EvaluateDrivers evaluateDrivers)
        {
            try
            {
                context.EvaluateDrivers.Add(evaluateDrivers);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                _errors = "Create Failed -sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }

        public bool Edit(EvaluateDrivers evaluateDrivers)
        {
            try
            {
                context.EvaluateDrivers.Attach(evaluateDrivers);
                context.Entry(evaluateDrivers).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Update Failed - sql Exeception Occured , Error Info : " + ex.Message;
                return false;
            }
        }

        public string GetErrors()
        {
            return _errors;
        }

        public List<EvaluateDrivers> GitAllEvaluateDrivers()
        {
            var evaluateDrivers = context.EvaluateDrivers.ToList();
            return evaluateDrivers;
        }

        public EvaluateDrivers GitVEvaluateDriversByID(int id)
        {
            EvaluateDrivers evaluateDrivers = context.EvaluateDrivers.Where(x => x.ID == id).FirstOrDefault();
            return evaluateDrivers;
        }
       
        
    }
}
