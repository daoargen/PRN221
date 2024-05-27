using Repositories;

namespace Services
{
    public class CustomerService
    {
        private CustomerRepository _repository;
        public CustomerService(CustomerRepository Repository)
        {
            _repository = Repository;
        }

    }
}
