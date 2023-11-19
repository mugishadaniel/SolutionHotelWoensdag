using HotelProject.BL.Exceptions;
using HotelProject.BL.Interfaces;
using HotelProject.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BL.Managers
{
    public class CustomerManager
    {
        private ICustomerRepository _customerRepository;
        private object customerRepositoryMock;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerManager(object customerRepositoryMock)
        {
            this.customerRepositoryMock = customerRepositoryMock;
        }

        public List<Customer> GetCustomers(string filter)
        {
            try
            {
                return _customerRepository.GetCustomers(filter);
            }
            catch(Exception ex)
            {
                throw new CustomerManagerException("GetAllCustomer",ex);
            }
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                _customerRepository.AddCustomer(customer);
            }
            catch (Exception ex)
            {
                throw new CustomerManagerException("AddCustomer", ex);
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                _customerRepository.UpdateCustomer(customer);
            }
            catch (Exception ex)
            {
                throw new CustomerManagerException("UpdateCustomer", ex);
            }
        }

        public void DeleteCustomer(int id)
        {
            try
            {
                _customerRepository.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                throw new CustomerManagerException("DeleteCustomer", ex);
            }
        }
    }
}
