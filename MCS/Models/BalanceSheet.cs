using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Models
{
    public class BalanceSheet
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public Employee Employee { get; set; }

        public BalanceSheet()
        {
        }

        public BalanceSheet(int id, double balance, Employee employee)
        {
            Id = id;
            Balance = balance;
            Employee = employee;
        }
    }
}
