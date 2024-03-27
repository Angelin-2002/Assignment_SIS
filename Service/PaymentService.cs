using StudentInformationSystem.Model;
using StudentInformationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Service
{
    internal class PaymentService
    {
        private readonly PaymentRepository _paymentRepository;
        public PaymentService()
        {
            _paymentRepository = new PaymentRepository();
        }

        public void GetStudentByPayment(int paymentId)
        {
            _paymentRepository.GetStudent(paymentId);
        }

        public void GetAmountByPayment(int paymentId)
        {
            _paymentRepository.GetPaymentAmount(paymentId);
        }

        public void GetPaymentDateById(int paymentId)
        {
            _paymentRepository.GetPaymentdate(paymentId);
        }

        public void HandlePaymentMenu()
        {
            Payment payment = new Payment();
            int choice = 0;
            do
            {
                Console.WriteLine("Welcome to Payment Management");
                Console.WriteLine($"1: Get student\n2: Get payment amount\n3. Get payment date\n4: Exit\n");
                Console.WriteLine("What would you like to do: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the payment id: ");
                        int payment_id = int.Parse(Console.ReadLine());
                        GetStudentByPayment(payment_id);
                        break;

                    case 2:
                        Console.WriteLine("Enter the payment id: ");
                        int paymentid = int.Parse(Console.ReadLine());
                        GetAmountByPayment(paymentid);
                        break;

                    case 3:
                        Console.WriteLine("Enter the payment id: ");
                        int paymentId = int.Parse(Console.ReadLine());
                        GetPaymentDateById(paymentId);
                        break;

                    case 4:
                        Console.WriteLine("Exiting from Payment Management");
                        break;

                    default:
                        Console.WriteLine("Wrong choice! Try again!");
                        break;
                }
            } while (choice != 4);
        }
    }
}
