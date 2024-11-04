using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_design_pattern
{
    public class OldPaymentService
    {
        public void MakePayment(decimal amount) 
        {
            Console.WriteLine($"Processing Payment of {amount} using old payment service.");
        } 
    }
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);    
    }
    public class PaymentAdapter : IPaymentProcessor
    {
        private readonly OldPaymentService _service;
        public PaymentAdapter(OldPaymentService service)
        {
            _service = service;
        }

        public void ProcessPayment(decimal amount)
        {
            _service.MakePayment(amount);
        }
    }
    public class Client
    {
        private readonly IPaymentProcessor _processor;
        public Client(IPaymentProcessor processor)
        {
            _processor = processor;
        }
        public void MakePayment(decimal amount)
        {
            _processor.ProcessPayment(amount);
        }
    }
}
