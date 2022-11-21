using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO20112022cs
{
    internal class Discount : Bank
    {
        public Discount(string bankId, string branchId) : base(bankId, branchId)
        {

        }
        public bool IsTeacher { get; set; }
    }
    internal class BankDiscount
    {
        public BankDiscount(int branchCount)
        {
            _branchCount = branchCount;
        }
        private readonly int _branchCount;

        public int BranchCount
        {
            get { return _branchCount; }
        }

        public Bank[] BranchList { get; set; }

        public void Import(Bank[] list)
        {
            Bank[] discountArray = new Bank[BranchCount];

            for (int i = 0, j = 0; i < list.Length; i++)
            {
                if (list[i].bankName.Contains("דיסקונט"))
                {
                    discountArray[j] = list[i];
                    j++;
                }
            }
            BranchList = discountArray;
        }

    }
}
