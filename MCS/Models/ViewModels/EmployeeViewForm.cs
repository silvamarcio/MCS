using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Models.ViewModels
{
    public class EmployeeViewForm
    {
        public Employee Employee { get; set; }
        public ICollection<BalanceSheet> BalanceSheets { get; set; }
    }
}
