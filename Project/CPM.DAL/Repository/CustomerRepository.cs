using CPM.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPM.Models;
using AutoMapper;

namespace CPM.DAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TestingAssignmentEntities db;
        public CustomerRepository()
        {
            db = new TestingAssignmentEntities();
        }

        public IList<Customer> GetCustomerList()
        {
            var entities = db.Customers.ToList();
            List<Customer> list = new List<Customer>();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Customer customer = new Customer();
                    customer.Customer_First_Name = item.Customer_First_Name;
                    customer.Customer_Last_Name = item.Customer_Last_Name;
                    customer.Customer_Phone_Number = item.Customer_Phone_Number;
                    list.Add(customer);
                }
            }
            return list;
        }

        public Customer AddNewCustomer(Customer model)
        {

            Customers customers = new Customers();
            customers.Customer_First_Name = model.Customer_First_Name;
            customers.Customer_Last_Name = model.Customer_Last_Name;
            customers.Customer_Phone_Number = model.Customer_Phone_Number;
            db.Customers.Add(customers);
            db.SaveChanges();
            return model;
        }

        public Customer UpdateCustomer(Customer model, int id)
        {
            var customer = db.Customers.Find(id);

            customer.Customer_First_Name = model.Customer_First_Name;
            customer.Customer_Last_Name = model.Customer_Last_Name;
            customer.Customer_Phone_Number = model.Customer_Phone_Number;
            db.SaveChanges();
            return model;
        }

        public bool DeleteCustomer(int id)
        {
            var data = db.Customers.Find(id);
            if (data != null)
            {
                db.Customers.Remove(data);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
