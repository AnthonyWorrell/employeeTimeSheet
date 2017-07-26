using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpEmployeeTimesheet
{
    class Employee
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public int rank { get; set; }
        public string sig { get; set; }
        public int id { get; set; }
        public bool payrollPermission { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Firstname">Employee first name</param>
        /// <param name="Lastname">Employee last name</param>
        /// <param name="Username">Employee user name</param>
        /// <param name="Rank">Employee rank</param>
        /// <param name="Sig">Employee sig</param>
        public Employee(string Firstname, string Lastname, string Username, int Rank, string Sig, int Id)
        {
            firstName = Firstname;
            lastName = Lastname;
            userName = Username;
            rank = Rank;
            sig = Sig;
            id = Id;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Firstname"></param>
        /// <param name="Lastname"></param>
        /// <param name="Id"></param>
        public Employee(string Firstname, string Lastname, int Id)
        {
            firstName = Firstname;
            lastName = Lastname;
            id = Id;
        }

        public override string ToString()
        {
            return lastName + ", " + firstName;
        }
    }
}
