using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Model
{
    internal class Student
    {
        int student_id;
        String first_name;
        String last_name;
        DateTime date_of_birth;
        String email;
        String phone_number;

        public int StudentID
        {
            get { return student_id; }
            set { student_id = value; }
        }

        public string FirstName
        {
            get { return first_name; }
            set { first_name = value; }

        }
        public string LastName
        {
            get { return last_name; }
            set { last_name = value; }
        }

        public DateTime DateOfBirth
        {
            get { return date_of_birth; }
            set { date_of_birth = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PhoneNumber
        {
            get { return phone_number; }
            set { phone_number = value; }
        }
        public Student() { }

        public Student(int studentID, String firstname, String lastname, DateTime dateofbirth, String email, String phonenumber)
        {
            StudentID = studentID;
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateofbirth;
            Email = email;
            PhoneNumber = phonenumber;
        }

        public override string ToString()
        {
            return $"{StudentID} {FirstName} {LastName} {DateOfBirth} {Email} {PhoneNumber}";
        }
    }
}
