using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO20112022cs
{
    internal class Mizrahi : Bank
    {
        public Mizrahi(string bankId, string branchId) : base(bankId, branchId)
        {

        }
        public int clubMembersCount { get; set; }
    }
}
