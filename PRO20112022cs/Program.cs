using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Console.OutputEncoding = System.Text.Encoding.UTF8;

namespace PRO20112022cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding("windows-1255");
            // *** ex03 ***
            //Write_3a();
            //Write_3b();
            //Read_3d();

            // *** ex04 ***
            //Write_4a();
            //Read_4d();

            // *** ex05-ex16 ***
            Bank[] bankArray = new Bank[fileLineCounter()];
            StreamReader sr = new StreamReader(bankFile);
            sr.ReadLine();
            string bankLine;
            string[] bankInfoArray;
            for (int i = 0; i < fileLineCounter(); i++)
            {
                bankLine = sr.ReadLine();
                bankInfoArray= bankLine.Split(',');
                
                if (bankInfoArray[1].Contains("דיסקונט"))
                {
                    bankArray[i] = new Discount(bankInfoArray[0], bankInfoArray[2]);
                }
                else if (bankInfoArray[1].Contains("מזרחי"))
                {
                    bankArray[i] = new Mizrahi(bankInfoArray[0], bankInfoArray[2]);
                }
                else if (bankInfoArray[1].Contains("פועלים"))
                {
                    bankArray[i] = new Hapoalim(bankInfoArray[0], bankInfoArray[2]);
                }
                else if (bankInfoArray[1].Contains("לאומי"))
                {
                    bankArray[i] = new Leumi(bankInfoArray[0], bankInfoArray[2]);
                }
                else
                {
                    bankArray[i] = new AllBanks(bankInfoArray[0], bankInfoArray[2]);
                }
                bankArray[i].bankName = bankInfoArray[1];
                bankArray[i].adress = bankInfoArray[4];
                bankArray[i].city = bankInfoArray[5];
                bankArray[i].phoneNumber = bankInfoArray[8];
            }
            //findJerusalemTelAviv(bankArray);
            //find8(bankArray);
            //BranchCounter(bankArray, "מזרחי");
            //Hapoalim[] HArray = HapoalimArray(bankArray, BranchCounter(bankArray, "הפועלים"));
            //Discount[] DArray = DiscountArray(bankArray, BranchCounter(bankArray, "דיסקונט"));
            //BankDiscount bankDList = new BankDiscount(BranchCounter(bankArray, "דיסקונט"));
            //BankHapoalim bankHList = new BankHapoalim(BranchCounter(bankArray, "הפועלים"));
            //bankDList.Import(bankArray);
            //bankHList.Import(bankArray);
            Console.ReadLine();
        }
        const string fileName = "myFile.txt";
        // ****** ex03 ******
        static void Write_3a()
        {
            StreamWriter sw = new StreamWriter(fileName);
            sw.WriteLine("*****");
            sw.Close();
        }
        static void Write_3b()
        {
            StreamWriter sw = new StreamWriter(fileName);
            for (int i = 0; i < 10; i++)
            {
                string line = Console.ReadLine();
                sw.WriteLine(line);
            }
            sw.Close();
        }
        static void Read_3d()
        {
            StreamReader sr = new StreamReader(fileName);
            int count = 1;
            while (sr.ReadLine() is string line)
            {
                Console.WriteLine("LINE#{0} - " + line, count);
                count++;
            }
        }
        // ****** ex04 ******
        static void Write_4a()
        {
            Random random = new Random();
            int lenght = random.Next(50, 101);
            StreamWriter sw = new StreamWriter(fileName);
            for (int i = 0; i < lenght; i++)
            {
                string line = "";
                int astCount = random.Next(3, 10);
                for (int j = 0; j < astCount; j++)
                {
                    line += "*";
                }
                sw.WriteLine(line);
            }
            sw.Close();
        }
        static void Read_4d()
        {
            StreamReader sr = new StreamReader(fileName);
            string text = sr.ReadToEnd();
            Console.WriteLine(text);
            sr.Close();
        }
        // ****** ex05 ******
        const string bankFile = "snifim.txt";
        static int fileLineCounter()
        {
            StreamReader sr = new StreamReader(bankFile);
            sr.ReadLine();
            int count = 0;
            while (sr.ReadLine() is string line)
            {
                count++;
            }
            return count;
        }
        static void findJerusalemTelAviv(Bank[] bankArray)
        {
            for (int i = 0; i < bankArray.Length; i++)
            {
                if(bankArray[i].city.Contains("ירושלים") || bankArray[i].city.Contains("תל אביב"))
                {
                    Console.WriteLine(bankArray[i].bankName);
                    Console.WriteLine(bankArray[i].bankId);
                    Console.WriteLine(bankArray[i].branchId);
                    Console.WriteLine(bankArray[i].city);
                }
            }
        }
        static void find8(Bank[] bankArray)
        {
            for (int i = 0; i < bankArray.Length; i++)
            {
                if (bankArray[i].phoneNumber.Contains("8"))
                {
                    Console.WriteLine(bankArray[i].bankName);
                    Console.WriteLine(bankArray[i].bankId);
                    Console.WriteLine(bankArray[i].branchId);
                    Console.WriteLine(bankArray[i].city);
                    Console.WriteLine(bankArray[i].phoneNumber);
                }
            }
        }
        static int BranchCounter(Bank[] bankArray, string bankName)
        {
            int count = 0;
            for (int i = 0; i < bankArray.Length; i++)
            {
                if (bankArray[i].bankName.Contains(bankName))
                {
                    count++;
                }
            }
            Console.WriteLine("bank " + bankName + " have {0} branches", count);
            return count;
        }
        static Hapoalim[] HapoalimArray(Bank[] bankArray, int branchCount)
        {
            Hapoalim[] hapoalimArray = new Hapoalim[branchCount];

            for (int i = 0, j = 0; i < bankArray.Length; i++)
            {
                if (bankArray[i].bankName.Contains("הפועלים"))
                {
                    hapoalimArray[j] = (Hapoalim)bankArray[i];
                    j++;
                }
            }
            return hapoalimArray;
        }
        static Discount[] DiscountArray(Bank[] bankArray, int branchCount)
        {
            Discount[] discountArray = new Discount[branchCount];

            for (int i = 0, j = 0; i < bankArray.Length; i++)
            {
                if (bankArray[i].bankName.Contains("דיסקונט"))
                {
                    discountArray[j] = (Discount)bankArray[i];
                    j++;
                }
            }
            return discountArray;
        }
    }
}
