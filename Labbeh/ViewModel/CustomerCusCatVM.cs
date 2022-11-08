using Labbeh.Models;

namespace Labbeh.ViewModel
{
    public class CustomerCusCatVM
    {
        public List<CustomerCategory> customerCategories { get; set; }
        public List<Customers> customers { get; set; }
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int CustomerCatID { get; set; }
        public string CurrentDate { get; set; }
        
    }
}
