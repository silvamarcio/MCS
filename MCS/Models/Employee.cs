using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public Occupation Occupation { get; set; }
        public int OccupationId { get; set; }
       
        public ICollection< BalanceSheet> BalanceSheets { get; set; }

        public Employee()
        {
        }

        public Employee(int id, string name, Occupation occupation, int occupationId)
        {
            Id = id;
            Name = name;
            Occupation = occupation;
            OccupationId = occupationId;
          
        }
    }
}
