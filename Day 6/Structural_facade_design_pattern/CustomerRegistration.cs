using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_facade_design_pattern
{
    internal class CustomerRegistration
    {
        public bool RegisterCustomer(Customer customer)
        {
            ValidateCustomer validateCustomer = new ValidateCustomer();
            validateCustomer.IsValid(customer);

            CustomerDataAccessLayer layer = new CustomerDataAccessLayer();
            layer.SaveCustomer(customer);

            Notification notification = new Notification();
            notification.SendNotification(customer);
            return true;    
        }
    }
}
