using Bearings2000.Portal.Web.Models;

namespace Bearings2000.Portal.Web.Services
{
    public class DataService: IDataService
    {
        private readonly BearingsContext _context;
        public DataService(BearingsContext context)
        {
            _context = context;
        }

        public List<Customer> GetCustomers()
        {
            var customers = _context.Customers
                .Where(c => c.Active == true);

            return customers.ToList();
        }
    }
}
