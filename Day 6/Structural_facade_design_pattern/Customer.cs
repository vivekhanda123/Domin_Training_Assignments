using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Structural_facade_design_pattern
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string Location { get; set; }

        public void GetCustomerDetail()
        {

        }
    }
    public class ValidateCustomer
    {
        public bool IsValid(Customer customer)
        {
            Console.WriteLine("Id Valid");
            Console.WriteLine("Mobile no valid");
            return true;
        }
    }
    public class CustomerDataAccessLayer
    {
        public void SaveCustomer(Customer customer)
        {
            Console.WriteLine("Customer daetails saved in the DB");
        }
    }
    public class Notification
    {
        public bool SendNotification(Customer customer)
        {
            Console.WriteLine("Registration Success");
            return true;
        }
    }
}
