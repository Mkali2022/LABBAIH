using Labbeh.Models;

namespace Labbeh.IRepository
{
    public interface IEvaluateDriversRepo
    {
        List<EvaluateDrivers> GitAllEvaluateDrivers();
        public EvaluateDrivers GitVEvaluateDriversByID(int id);
        bool Create(EvaluateDrivers evaluateDrivers);
        bool Edit(EvaluateDrivers evaluateDrivers);
        public string GetErrors();
    }
}
