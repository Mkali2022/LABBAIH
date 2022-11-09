using Labbeh.Models;

namespace Labbeh.IRepository
{
    public interface IDriverRepo
    {
        List<Drivers> GitAllDriver();
        public Drivers GitDriver(int id);
        bool Create(Drivers drivers);
        bool Edit(Drivers drivers);
        public string GetErrors();

    }
}
