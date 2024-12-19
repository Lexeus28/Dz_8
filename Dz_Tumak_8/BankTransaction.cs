using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    public class BankTransaction
    {
        public DateTime date { get; }
        public decimal sum { get; }

      public BankTransaction (decimal sum)
        { this.sum = sum;
          this.date = DateTime.Now;
        }
    }
}
