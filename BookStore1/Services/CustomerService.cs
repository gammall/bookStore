using BookStore1.Dto;
using BookStore1.Entities;
using BookStore1.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace BookStore1.Services;

public class CustomerService(CustomerRepository customerRepository)
{
    private readonly CustomerRepository _customerRepository = customerRepository;


    public bool CreateCustomer(Customer customer)
    {
        if (!_customerRepository.Exists(x => x.CustomerEmail == customer.CustomerEmail))
        {
            var customerEntity = new CustomerEntity
            {
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail,
            };
            var result = _customerRepository.Create(customerEntity);
            if (result != null)
                return true;
        }
        return false;
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        var products = new List<Customer>();
        var result = _customerRepository.GetAll();

        try
        {
            foreach (var customer in result)
                products.Add(new Customer
                {
                    CustomerName = customer.CustomerName,
                    CustomerEmail = customer.CustomerEmail
                });
        }
        catch { }
        return products;
    }

    public CustomerEntity GetOneCustomer(Expression<Func<CustomerEntity, bool>> predicate)
    {
        try
        {
            return _customerRepository.GetOne(predicate);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw; 
        }
    }

    public void UpdateCustomerName(string customerEmail, string newCustomerName)
    {
        try
        {
            var existingCustomer = _customerRepository.GetOne(customer => customer.CustomerEmail == customerEmail);

            if (existingCustomer != null)
            {
                var customerToUpdate = new CustomerEntity { CustomerEmail = customerEmail, CustomerName = newCustomerName };

                _customerRepository.Update(customerToUpdate);
            }
            else
            {
                Console.WriteLine("Could not update customer");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
        }
    }

    public void DeleteCustomer(CustomerEntity customer)
    {
        try
        {
            var existingCustomer = _customerRepository.GetOne(c => c.CustomerEmail == customer.CustomerEmail);

            if (existingCustomer != null)
            {
                _customerRepository.Delete(existingCustomer);
            }
            else
            {
                Console.WriteLine("Could not delete customer");
            }
        }
        catch { }
    }

}

