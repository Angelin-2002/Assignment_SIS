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
    internal class StudentRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public StudentRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public void InsertRecords(Student students)
        {
            cmd.CommandText = "Insert into Students values(@fname,@lname,@dob,@email,@phno)";
            cmd.Parameters.AddWithValue("@fname", students.FirstName);
            cmd.Parameters.AddWithValue("@lname", students.LastName);
            cmd.Parameters.AddWithValue("@dob", students.DateOfBirth);
            cmd.Parameters.AddWithValue("@email", students.Email);
            cmd.Parameters.AddWithValue("@phno", students.PhoneNumber);
            connect.Open();
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public void EnrollInCourse(Course course, int studentId)
        {
            cmd.CommandText = "Insert into Enrollments values(@s_id,@c_id,@date)";
            cmd.Parameters.AddWithValue("@s_id", studentId);
            cmd.Parameters.AddWithValue("@c_id", course.CourseID);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            connect.Open();
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public void UpdateStudentInfo(Student students)
        {
            cmd.CommandText = "Update Students set first_name=@fname,last_name=@lname,date_of_birth=@dob,email=@email,phone_number=@phno where student_id=@id";
            cmd.Parameters.AddWithValue("@id", students.StudentID);
            cmd.Parameters.AddWithValue("@fname", students.FirstName);
            cmd.Parameters.AddWithValue("@lname", students.LastName);
            cmd.Parameters.AddWithValue("@dob", students.DateOfBirth);
            cmd.Parameters.AddWithValue("@email", students.Email);
            cmd.Parameters.AddWithValue("@phno", students.PhoneNumber);
            connect.Open();
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public void MakePayment(int studentId, decimal amount)
        {
            cmd.CommandText = "Insert into Payments values(@s_id,@amount,@date)";
            cmd.Parameters.AddWithValue("@s_id", studentId);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            connect.Open();
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public void GetEnrolledCourses(int stud_id)
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            cmd.CommandText = "Select * from Enrollments where student_id=@studentid";
            cmd.Parameters.AddWithValue("@studentid", stud_id);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Enrollment enrollment = new Enrollment();
                enrollment.EnrollmentID = (int)reader["enrollment_id"];
                enrollment.StudentID = (int)reader["student_id"];
                enrollment.CourseID = (int)reader["course_id"];
                enrollment.EnrollmentDate = (DateTime)reader["enrollment_date"];
                enrollments.Add(enrollment);
            }
            foreach (Enrollment enrollment in enrollments)
            {
                Console.WriteLine(enrollment);
            }
            connect.Close();
        }

        public void GetPaymentHistory(int stud_id)
        {
            List<Payment> payments = new List<Payment>();
            cmd.CommandText = "Select * from Payments where student_id=@sid";
            cmd.Parameters.AddWithValue("@sid", stud_id);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Payment payment = new Payment();
                payment.PaymentID = (int)reader["payment_id"];
                payment.StudentID = (int)reader["student_id"];
                payment.Amount = (int)reader["amount"];
                payment.PaymentDate = (DateTime)reader["payment_date"];
                payments.Add(payment);
            }
            foreach (Payment payment in payments)
            {
                Console.WriteLine(payment);
            }
            connect.Close();
        }
        public void DisplayStudentInfo()
        {
            List<Student> students = new List<Student>();
            cmd.CommandText = "Select * from Students";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student();
                student.StudentID = (int)reader["student_id"];
                student.FirstName = (string)reader["first_name"];
                student.LastName = (string)reader["last_name"];
                student.DateOfBirth = (DateTime)reader["date_of_birth"];
                student.Email = (string)reader["email"];
                student.PhoneNumber = (string)reader["phone_number"];
                students.Add(student);
            }
            foreach (Student name in students)
            {
                Console.WriteLine(name);
            }
            connect.Close();
        }

        public bool StudentExists(int studentId)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as total from Students where student_id=@s_id";
            cmd.Parameters.AddWithValue("@s_id", studentId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = (int)reader["total"];
            }
            connect.Close();
            if (count > 0)
            {
                return true;
            }
            return false;

        }
    }
}
