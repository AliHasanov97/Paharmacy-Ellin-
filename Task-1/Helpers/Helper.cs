using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Helpers
{
    static class Helper
    {
        public static void UTF8()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
        }
        public static bool StringEmpty(string text)
        {
            return string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text);
        }
        public static void CwWithColor(this string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void CwWithMultipleColor(string text1, string text2)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text1);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(text2);
            Console.ResetColor();
        }
        public static void Title(String title)
        {
            Console.Clear();
            "-----------------------------".CwWithColor(ConsoleColor.Green);
            Helper.CwWithColor(title, ConsoleColor.Green);
            "-----------------------------".CwWithColor(ConsoleColor.Green);
            Console.ResetColor();
        }
    }
    enum S_C
    {
        Seller = 1,
        Customer = 2,
    }
    enum SellerAction
    {
        AddDrug = 1,
        ShowDrugs = 2,
        RemoveDrug = 3,
        FindDrug = 4,
        IncreaseDrugCount = 5,
    }
    enum CustomerAction
    {
        AskDrug = 1,
        AskDrugType = 2,
        BuyDrug = 3,
    }
}
