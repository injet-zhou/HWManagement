using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW.Services
{
    public interface IGlobalService
    {
        public string GenRandomId(int num);
    }
    public class GlobalService: IGlobalService
    {
        public string GenRandomId(int num)
        {
            if (num <= 0)
            {
                return null;
            }
            var ran = new Random();
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            string number = "0123456789";
            string Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string id = "";

            for (int i = 0; i < num; i++)
            {
                int choice = ran.Next(1, 3);
                switch (choice)
                {
                    case 1: id += alpha[ran.Next(0, alpha.Length - 1)]; break;
                    case 2: id += number[ran.Next(0, number.Length - 1)]; break;
                    case 3: id += Alpha[ran.Next(0, Alpha.Length - 1)]; break;
                }
            }
            return id;
        }
    }
}
