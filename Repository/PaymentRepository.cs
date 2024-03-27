using StudentInformationSystem.Model;
using StudentInformationSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    internal class PaymentRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public PaymentRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public void GetStudent(int paymentId)
        {
            cmd.CommandText = "Select * from Payments where payment_id=@p_id";
            cmd.Parameters.AddWithValue("@p_id", paymentId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Payment payment = new Payment();
                payment.PaymentID = (int)reader["payment_id"];
                payment.StudentID = Convert.IsDBNull(reader["student_id"]) ? null : (int)reader["student_id"];
                payment.Amount = Convert.IsDBNull(reader["amount"]) ? null : (decimal)reader["amount"];
                payment.PaymentDate = (DateTime)reader["payment_date"];
                Console.WriteLine(payment);
            }
            connect.Close();
        }

        public void GetPaymentAmount(int paymentId)
        {
            cmd.CommandText = "Select amount from Payments where payment_id=@pid";
            cmd.Parameters.AddWithValue("@pid", paymentId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                decimal amount = (decimal)reader["amount"];
                Console.WriteLine($"Amount : {amount}");
            }
            connect.Close();
        }

        public void GetPaymentdate(int paymentId)
        {
            cmd.CommandText = "Select payment_date from Payments where payment_id=@payment_id";
            cmd.Parameters.AddWithValue("@payment_id", paymentId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = (DateTime)reader["payment_date"];
                Console.WriteLine($"Payment Date : {date}");
            }
            connect.Close();
        }
    }
}
