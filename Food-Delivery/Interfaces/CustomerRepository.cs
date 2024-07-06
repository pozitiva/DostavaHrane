using Food_Delivery.Data;
using Microsoft.EntityFrameworkCore;

namespace Food_Delivery.Interfaces
{
    public class CustomerRepository //: ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext dbContext)
        {
            _context = dbContext;
        }
        //public Task<Customer> AddCustomerAsync(Customer customer)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task DeleteCustomerAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Customer> GetCustomerByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<Customer>> GetCustomersAsync()
        //{
        //    return await _context.Customers.ToListAsync();
        //}

        //public Task UpdateCustomerAsync(Customer customer)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
