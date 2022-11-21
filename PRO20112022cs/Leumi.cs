using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO20112022cs
{
    internal class Leumi : Bank
    {
        public Leumi(string bankId, string branchId) : base(bankId, branchId)
        {

        }
        public string GiftForNewCustpres { get; set; }
    }
}
