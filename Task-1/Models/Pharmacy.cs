using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Helpers;
namespace Task_1.Models
{
    class Pharmacy
    {
        private static int id;
        public int Id;
        public string Name { get; set; }
        public string Address { get; set; }
        private List<Drug> drugs;
        public Pharmacy(string name)
        {
            id++;
            Id = id;
            Name = name;
            drugs = new List<Drug>();

        }
        public void AddDrug(Drug drug)
        {
            drugs.Add(drug);
        }
        public void RemoveDrug(int id)
        {
            Drug drug = drugs.Find(drug => drug.Id == id);
            if (drug == null)
            {
                "Dərman mövcud deyil".CwWithColor(ConsoleColor.Green);
                Console.ReadKey();
                return;
            }
            drugs.Remove(drug);
        }
        public void ShowDrugs()
        {
            drugs.ForEach(drug => Console.WriteLine(drug));
        }
        public void IncreaseDrugCount(int id, int count)
        {
            Drug drug = drugs.Find(drug => drug.Id == id);

            drug.Count += count;
        }
        public void FindDrug(string name)
        {
            "-----------------------------".CwWithColor(ConsoleColor.Green);
            "Aşağıdakı dərmanlar tapılmışdır".CwWithColor(ConsoleColor.Green);
            drugs.FindAll(x => x.Name.Contains(name)).ForEach(drug => Console.WriteLine(drug));
        }
        public void FindDrugByType(string type)
        {
            "-----------------------------".CwWithColor(ConsoleColor.Green);
            "Aşağıdakı dərmanlar tapılmışdır".CwWithColor(ConsoleColor.Green);
            drugs.FindAll(x => x.DrugType.Contains(type)).ForEach(drug => Console.WriteLine(drug));
        }
        public bool GetDrugCount(int id)
        {
            Drug drug = drugs.Find(drug => drug.Id == id);
            if (drug == null)
            {
                "Dərman mövcud deyil".CwWithColor(ConsoleColor.Green);
                Console.ReadKey();
                return false;
            }
            "-----------------------------".CwWithColor(ConsoleColor.Green);
            Helper.CwWithMultipleColor("Dərman adı : ", drug.Name);
            Helper.CwWithMultipleColor("Stok : ", Convert.ToString(drug.Count));
            "-----------------------------".CwWithColor(ConsoleColor.Green);
            return true;
        }
        public void BuyDrug(string name)
        {
            Drug drug = drugs.Find(drug => drug.Name == name);
            if (drug == null)
            {
                "Dərman mövcud deyil".CwWithColor(ConsoleColor.Green);
                Console.ReadKey();
                return;
            }
            Helper.CwWithMultipleColor("Dərman stoku : ", Convert.ToString(drug.Count));
            if (drug.Count == 0)
            {
                "Dərman stoku olmadığından daha sonra müraciət edin".CwWithColor(ConsoleColor.Red);
            }
            else
            {
                int count;
                while (true)
                {
                    "Neçə ədəd almaq istəyirsiniz?".CwWithColor(ConsoleColor.DarkCyan);
                    string Count = Console.ReadLine();
                    if (Helper.StringEmpty(Count))
                    {
                        "Sayı düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                    }
                    else if (int.TryParse(Count, out count))
                    {
                        break;
                    }
                    else
                    {
                        "Sayı düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                    }
                }
                if (count > drug.Count)
                {
                    "Icra olunmadı".CwWithColor(ConsoleColor.Red);
                    Helper.CwWithMultipleColor("Maksimum ala biləcəyiniz dərman sayı : ", Convert.ToString(drug.Count));
                }
                else
                {
                    int Total_price = count * drug.Price;
                    if (Customer.money - Total_price >= 0)
                    {
                        Customer.money -= Total_price;
                        drug.Count -= count;
                        "Dərman alındı".CwWithColor(ConsoleColor.DarkCyan);
                        Helper.CwWithMultipleColor("Sizin balansınız : ", Convert.ToString(Customer.money));
                    }
                    else
                    {
                        "Balansınız kifayət qədər deyil.".CwWithColor(ConsoleColor.Red);
                        Helper.CwWithMultipleColor("Sizin balansınız : ", Convert.ToString(Customer.money));
                    }

                }
            }
        }
    }
}
