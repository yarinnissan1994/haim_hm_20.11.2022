using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO20112022cs
{
    internal class Hapoalim : Bank
    {
        public Hapoalim(string bankId, string branchId) : base(bankId, branchId)
        {

        }
        public int WorkersInSnif { get; set; }
    }

    internal class BankHapoalim
    {
        public BankHapoalim(int branchCount)
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
            Bank[] hapoalimArray = new Bank[BranchCount];

            for (int i = 0, j = 0; i < list.Length; i++)
            {
                if (list[i].bankName.Contains("הפועלים"))
                {
                    hapoalimArray[j] = list[i];
                    j++;
                }
            }
            BranchList = hapoalimArray;
        }

    }
}
