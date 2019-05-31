using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProjectManagement.DTO
{
    public class EmployeeDTO
    {
        string name, password, fullName, gender, yearOfBirth, phone, email, position, role, department, status;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public string YearOfBirth
        {
            get
            {
                return yearOfBirth;
            }

            set
            {
                yearOfBirth = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }

        public string Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public EmployeeDTO(DataRow row)
        {
            this.name = row["NAME"].ToString().Trim();
            this.password = row["PASSWORD"].ToString().Trim();
            this.fullName = row["FULLNAME"].ToString().Trim();
            this.gender = row["GENDER"].ToString().Trim();
            this.yearOfBirth = row["YEAROFBIRTH"].ToString().Trim();
            this.phone = row["PHONE"].ToString().Trim();
            this.email = row["EMAIL"].ToString().Trim();
            this.position = row["POSITION"].ToString().Trim();
            this.role = row["ROLE"].ToString().Trim();
            this.department = row["DEPARTMENT"].ToString().Trim();
            this.status = row["STATUS"].ToString().Trim();
        }

        public EmployeeDTO()
        {
            this.name = string.Empty;
            this.password = string.Empty;
            this.fullName = string.Empty;
            this.gender = string.Empty;
            this.yearOfBirth = string.Empty;
            this.phone = string.Empty;
            this.email = string.Empty;
            this.position = string.Empty;
            this.role = string.Empty;
            this.department = string.Empty;
            this.status = string.Empty;
        }

        public bool Empty()
        {
            if (this.name == string.Empty)
                return true;

            return false;
        }
           
        public EmployeeDTO(string name, string password, string fullName, string gender, string yearOfBirth, string phone, string email, string position, string role, string department, string status)
        {
            this.name = name;
            this.password = password;
            this.fullName = fullName;
            this.gender = gender;
            this.yearOfBirth = yearOfBirth;
            this.phone = phone;
            this.email = email;
            this.position = position;
            this.role = role;
            this.department = department;
            this.status = status;
        }
    }
}
