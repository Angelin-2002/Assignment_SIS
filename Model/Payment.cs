using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Model
{
    internal class Payment
    {
        int payment_id;
        int? student_id;
        decimal? amount;
        DateTime payment_date;

        public int PaymentID
        {
            get { return payment_id; }
            set { payment_id = value; }
        }

        public int? StudentID
        {
            get { return student_id; }
            set { student_id = value; }
        }

        public decimal? Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public DateTime PaymentDate
        {
            get { return payment_date; }
            set { payment_date = value; }
        }
        public Payment()
        {

        }

        public Payment(int paymentID, int studentID, decimal amount, DateTime paymentDate)
        {
            PaymentID = paymentID;
            StudentID = studentID;
            Amount = amount;
            PaymentDate = paymentDate;
        }
        public override string ToString()
        {
            return $"{PaymentID} {StudentID} {Amount} {PaymentDate}";
        }
    }
}
