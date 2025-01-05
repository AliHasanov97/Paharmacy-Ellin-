using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using Task_1.Helpers;
using Task_1.Models;
using static System.Net.Mime.MediaTypeNames;
using Action = System.Action;
namespace Task_1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Helper.UTF8();
            "Salam zəhmət olmasa gedəcəyiniz aptekin adını yazın".CwWithColor(ConsoleColor.DarkCyan);

            Models.Pharmacy pharmacy = new Models.Pharmacy("");
            string pharmacyName;
            while (true)
            {
                pharmacyName = Console.ReadLine();
                if (Helper.StringEmpty(pharmacyName))
                {
                    "Aptekin adını düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                }
                else
                {
                    pharmacy.Name = pharmacyName;
                    break;
                }
            }

        start:
            Console.Clear();
            "-----------------------------".CwWithColor(ConsoleColor.Green);
            Helper.CwWithMultipleColor("Aptek adı : ", pharmacyName);
            "-----------------------------".CwWithColor(ConsoleColor.Green);
            "Zəhmət olmasa əməliyyat seçin".CwWithColor(ConsoleColor.DarkCyan);
            "1:Satıcı".CwWithColor(ConsoleColor.DarkCyan);
            "2:Alıcı".CwWithColor(ConsoleColor.DarkCyan);
            while (true)
            {
                string action = Console.ReadLine();

                if (action == ((int)S_C.Seller).ToString())
                {
                #region Seller
                seller:
                    while (true)
                    {

                        Console.Clear();
                        "-----------------------------".CwWithColor(ConsoleColor.Green);
                        Helper.CwWithMultipleColor("Aptek adı : ", pharmacyName);
                        "-----------------------------".CwWithColor(ConsoleColor.Green);
                        "      Satıcı menyusu".CwWithColor(ConsoleColor.Green);
                        "-----------------------------".CwWithColor(ConsoleColor.Green);

                        "Zəhmət olmasa əməliyyat seçin".CwWithColor(ConsoleColor.DarkCyan);
                        Helper.CwWithMultipleColor("1:", "Dərman əlavə et");
                        Helper.CwWithMultipleColor("2:", "Bütün dərmanlara bax");
                        Helper.CwWithMultipleColor("3:", "Dərmanı çıxart");
                        Helper.CwWithMultipleColor("4:", "Dərman axtar");
                        Helper.CwWithMultipleColor("5:", "Dərman sayını artır");


                        "-----------------------------".CwWithColor(ConsoleColor.Green);
                        String sellerAction = Console.ReadLine();
                        if (sellerAction == ((int)SellerAction.AddDrug).ToString())
                        {
                            Helper.Title(" => Dərman əlavə et");
                            string DrugName, DrugType, DrugPrice;
                            int Price;
                            int result;
                            while (true)
                            {
                                "Dərmanın adını daxil edin".CwWithColor(ConsoleColor.DarkCyan);
                                DrugName = Console.ReadLine();

                                if (Helper.StringEmpty(DrugName))
                                {
                                    "Dərmanın adını düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                                }
                                else if (DrugName == "0")
                                {
                                    goto seller;
                                }
                                else if (int.TryParse(DrugName, out result))
                                {
                                    "Dərmanın adını düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            while (true)
                            {
                                "Dərmanın tipini daxil edin".CwWithColor(ConsoleColor.DarkCyan);

                                DrugType = Console.ReadLine();
                                if (Helper.StringEmpty(DrugType))
                                {
                                    "Dərmanın tipini düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                                }
                                else if (DrugType == "0")
                                {
                                    goto seller;
                                }
                                else if (int.TryParse(DrugType, out result))
                                {
                                    "Dərmanın tipini düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            while (true)
                            {
                                "Dərmanın qiymətini daxil edin".CwWithColor(ConsoleColor.DarkCyan);
                                DrugPrice = Console.ReadLine();
                                if (Helper.StringEmpty(DrugPrice))
                                {
                                    "Dərmanın qiymətini düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                                }
                                else if (DrugPrice == "0")
                                {
                                    goto seller;
                                }
                                else if (int.TryParse(DrugPrice, out Price))
                                {
                                    break;
                                }
                                else
                                {
                                    "Dərmanın qiymətini düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                                }
                            }
                            Drug drug = new Drug(DrugName, DrugType, Price);
                            pharmacy.AddDrug(drug);
                            continue;
                        }
                        if (sellerAction == ((int)SellerAction.ShowDrugs).ToString())
                        {
                            Helper.Title(" => Dərmanların siyahısı");
                            pharmacy.ShowDrugs();
                            Console.ReadKey();
                            continue;
                        }
                        if (sellerAction == ((int)SellerAction.RemoveDrug).ToString())
                        {
                            Helper.Title(" => Dərmanı sistemdən sil");
                            int ID;
                            while (true)
                            {
                                "Dərmanın ID-sini daxil edin".CwWithColor(ConsoleColor.Red);
                                string RemoveID = Console.ReadLine();

                                if (Helper.StringEmpty(RemoveID))
                                {
                                    "Dərmanın ID-sini düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                                }
                                else if (RemoveID == "0")
                                {
                                    goto seller;
                                }
                                else if (int.TryParse(RemoveID, out ID))
                                {
                                    break;
                                }
                                else
                                {
                                    "Dərmanın ID-sini düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                                }

                            }
                            pharmacy.RemoveDrug(ID);
                            continue;


                        }
                        if (sellerAction == ((int)SellerAction.FindDrug).ToString())
                        {
                            string PharmacyName;
                            Helper.Title(" => Dərman axtarış");
                            while (true)
                            {
                                "Tapmaq istədiyiniz dərmanın adını qeyd edin".CwWithColor(ConsoleColor.DarkCyan);
                                PharmacyName = Console.ReadLine();
                                if (Helper.StringEmpty(PharmacyName))
                                {
                                    "Zəhmət olmasa düzgün qeyd edin".CwWithColor(ConsoleColor.Red);
                                }
                                else if (PharmacyName == "0")
                                {
                                    goto seller;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            pharmacy.FindDrug(PharmacyName);
                            Console.ReadKey();
                            continue;
                        }
                        if (sellerAction == ((int)SellerAction.IncreaseDrugCount).ToString())
                        {

                            Helper.Title(" => Dərman sayı artır");
                            int ID;
                            int Count = 0;
                            while (true)
                            {
                                "Dərmanın ID-sini daxil edin".CwWithColor(ConsoleColor.DarkCyan);
                                string editID = Console.ReadLine();

                                if (Helper.StringEmpty(editID))
                                {
                                    "Dərmanın ID-sini düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                                }
                                else if (editID == "0")
                                {
                                    goto seller;
                                }
                                else if (int.TryParse(editID, out ID))
                                {
                                    break;
                                }
                                else
                                {
                                    "Dərmanın ID-sini düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                                }
                            }
                            if (pharmacy.GetDrugCount(ID))
                            {
                                while (true)
                                {
                                    "Dərman sayı neçə ədəd artırılsın?".CwWithColor(ConsoleColor.DarkCyan);
                                    string count = Console.ReadLine();

                                    if (Helper.StringEmpty(count))
                                    {
                                        "Sayı düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                                    }
                                    else if (int.TryParse(count, out Count))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        "Sayı düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                                    }
                                }
                                pharmacy.IncreaseDrugCount(ID, Count);
                            }
                            continue;
                        }
                        if (sellerAction == "*")
                        {
                            goto start;
                        }

                    }
                    #endregion
                }
                else if (action == ((int)S_C.Customer).ToString())
                {
                Customer:
                   
                    int money;
                    while (true)
                    {
                        Console.Clear();
                        "Balansınızı qeyd edin".CwWithColor(ConsoleColor.DarkCyan);
                        string Count = Console.ReadLine();
                        if (Helper.StringEmpty(Count))
                        {
                            "Məbləği düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                        }
                        else if (int.TryParse(Count, out money))
                        {
                            break;
                        }
                        else
                        {
                            "Sayı düzgün daxil edin".CwWithColor(ConsoleColor.Red);
                        }
                    }
                    Customer.money= money;
                    while (true)
                    {
                        Console.Clear();
                        "-----------------------------".CwWithColor(ConsoleColor.Green);
                        Helper.CwWithMultipleColor("Aptek adı : ", pharmacyName);
                        "-----------------------------".CwWithColor(ConsoleColor.Green);
                        "      Müştəri menyusu".CwWithColor(ConsoleColor.Green);
                        "-----------------------------".CwWithColor(ConsoleColor.Green);
                        "Zəhmət olmasa əməliyyat seçin".CwWithColor(ConsoleColor.DarkCyan);
                        Helper.CwWithMultipleColor("1:", "Dərman soruş");
                        Helper.CwWithMultipleColor("2:", "Dərman tipinə görə baxış");
                        Helper.CwWithMultipleColor("3:", "Dərman alışı");
                        "-----------------------------".CwWithColor(ConsoleColor.Green);
                        String customerAction = Console.ReadLine();
                        if (customerAction == ((int)CustomerAction.AskDrug).ToString())
                        {
                            Helper.Title(" => Dərman soruş");
                            string PharmacyName;
                            while (true)
                            {
                                "Tapmaq istədiyiniz dərmanın adını qeyd edin".CwWithColor(ConsoleColor.DarkCyan);
                                PharmacyName = Console.ReadLine();
                                if (Helper.StringEmpty(PharmacyName))
                                {
                                    "Zəhmət olmasa düzgün qeyd edin".CwWithColor(ConsoleColor.Red);
                                }
                                else if (PharmacyName == "0")
                                {
                                    goto Customer;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            pharmacy.FindDrug(PharmacyName);
                            Console.ReadKey();
                            continue;
                        }
                        if (customerAction == ((int)CustomerAction.AskDrugType).ToString())
                        {
                            Helper.Title(" => Dərman soruş");
                            string TypeName;
                            while (true)
                            {
                                "Tapmaq istədiyiniz dərmanın adını qeyd edin".CwWithColor(ConsoleColor.DarkCyan);
                                TypeName = Console.ReadLine();
                                if (Helper.StringEmpty(TypeName))
                                {
                                    "Zəhmət olmasa düzgün qeyd edin".CwWithColor(ConsoleColor.Red);
                                }
                                else if (TypeName == "0")
                                {
                                    goto Customer;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            pharmacy.FindDrugByType(TypeName);
                            Console.ReadKey();
                            continue;
                        }
                        if (customerAction == ((int)CustomerAction.BuyDrug).ToString())
                        {
                            Helper.Title(" => Dərman almaq");
                            string PharmacyName;
                            while (true)
                            {
                                "Almaq istədiyiniz dərmanın adını qeyd edin".CwWithColor(ConsoleColor.DarkCyan);
                                PharmacyName = Console.ReadLine();
                                if (Helper.StringEmpty(PharmacyName))
                                {
                                    "Zəhmət olmasa düzgün qeyd edin".CwWithColor(ConsoleColor.Red);
                                }
                                else if (PharmacyName == "0")
                                {
                                    goto Customer;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            pharmacy.BuyDrug(PharmacyName);

                            Console.ReadKey();
                            continue;
                        }

                        if (customerAction == "*")
                        {
                            goto start;
                        }
                    }
                }
                else
                {
                    "Zəhmət olmasa düzgün əməliyyat seçin".CwWithColor(ConsoleColor.Red);
                }
            };
        }
    }
}
