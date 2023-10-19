// See https://aka.ms/new-console-template for more information

using RefrigeratorSaraFarkash;
using System;
using System.Collections.Generic;
using System.Linq;
namespace exeRefreg
{
    class Program
    {
        public List<CRefrigerator> SortRefrigeratorsByFreeSpace(List<CRefrigerator> refrigerators)
        {
            return refrigerators.OrderByDescending(refrigerator => refrigerator.spaceLeftInRefrigerator()).ToList();
        }
        //פןנקציה שבונה מדף:
        public static CShelf buildShelf()
        {
            CShelf shelf1 = new CShelf();
            Console.WriteLine("now we going build a shelf!");
            Console.WriteLine("enter id for the shelf:");
            shelf1.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("enter numberLevel for the shelf:");
            shelf1.NumberLevel = int.Parse(Console.ReadLine());
            Console.WriteLine("enter placeInShelf for the shelf:");
            shelf1.PlaceInShelf = double.Parse(Console.ReadLine());
            Console.WriteLine("now you dont have items in the shelf if you want to put item so you can AddItem");
            shelf1.Items = new List<CItem>();
            return shelf1;
        }
        //פונקציה שבונה מקרר
        public static CRefrigerator BuildRefrigerator()
        {
            CRefrigerator refrigerator1 = new CRefrigerator();
            Console.WriteLine("Now we are going to build a refrigerator according to your requirements:");
            Console.WriteLine("enter id for the refrigerator ");
            refrigerator1.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("enter Model for the refrigerator ");
            refrigerator1.Model = int.Parse(Console.ReadLine());
            Console.WriteLine("enter Color for the refrigerator ");
            refrigerator1.Color = Console.ReadLine();
            Console.WriteLine("enter NumberOfShelves for the refrigerator ");
            refrigerator1.NumberOfShelves = int.Parse(Console.ReadLine());
            for (int i = 0; i < refrigerator1.NumberOfShelves; i++)
            {
                CShelf shelf = buildShelf();
                refrigerator1.Shelfs.Add(shelf);
            }
            return refrigerator1;
        }

        static void Main(string[] args)
        {
            CItem item1 = new CItem();
            item1.ExpiryDate = DateTime.Now;
            item1.IdShelf = 1;
            item1.Kashroot = "chalvi";
            item1.Name = "coffe";
            item1.TakeSpace = 2.4;
            item1.TypeI = "drink";
            CItem item2 = new CItem();
            DateTime threeMonthsAgo = DateTime.Now.AddMonths(-3);
            item2.ExpiryDate = threeMonthsAgo;
            item2.IdShelf = 1;
            item2.Kashroot = "chalvi";
            item2.Name = "coffe";
            item2.TakeSpace = 2.4;
            item2.TypeI = "drink";

            CRefrigerator refrigerator1 = BuildRefrigerator();

            //פונקציות שעובדות
            refrigerator1.pushToRef(item1);
            refrigerator1.pushToRef(item2);

            List<CRefrigerator> arrRefrigerator = new List<CRefrigerator>();
            //סיכום סו]י נשאר לבדוק פונקציות מיון
            //חלק 3
            Console.WriteLine("Press 1: the program will print all the items on the refrigerator and all its contents.");
            Console.WriteLine("Click 2: the program will print how much space is left in the fridge");
            Console.WriteLine("Press 3: The program will allow the user to put an item in the fridge.");
            Console.WriteLine("Press 4: The program will allow the user to remove an item from the refrigerator.");
            Console.WriteLine("Press 5: the program will clean the refrigerator and print all the checked items to the user.");
            Console.WriteLine("Press 6: the program will ask the user What do I want to eat?; and bring the function to bring a product.");
            Console.WriteLine("Click 7: the program will print all the products sorted by their expiration date.");
            Console.WriteLine("Press 8: the program will print all the shelves arranged according to the free space left on them.");
            Console.WriteLine("Press 9: the program will print all the refrigerators arranged according to the free space left in them.");
            Console.WriteLine("Click 10: The program will prepare the refrigerator for shopping.");
            Console.WriteLine("Press 100: system shutdown.");
            int flag = 1;
            while (flag == 1)
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(refrigerator1.ToString());
                        break;
                    case 2:
                        Console.WriteLine(refrigerator1.spaceLeftInRefrigerator());
                        break;
                    case 3:
                        Console.WriteLine("Enter the item details:");
                        CItem item = new CItem();
                        item.IdShelf = int.Parse(Console.ReadLine());
                        item.Kashroot = Console.ReadLine();
                        item.Name = Console.ReadLine();
                        item.TakeSpace = double.Parse(Console.ReadLine());
                        item.TypeI = Console.ReadLine();
                        refrigerator1.pushToRef(item);
                        break;
                    case 4:
                        Console.WriteLine("Enter the ID of the item to remove:");
                        int idToRemove = int.Parse(Console.ReadLine());
                        CItem itemWantOut = refrigerator1.removeItem(idToRemove);
                        break;
                    case 5:
                        //מה זה אומר את כלל הפריטים שנבדקו?
                        refrigerator1.cleanExpired();
                        break;
                    case 6:
                        Console.WriteLine("What do you want to eat?");
                        string kashroot = Console.ReadLine();
                        string typeEat = Console.ReadLine();
                        List<CItem> listOfFoods = refrigerator1.wantEat(kashroot, typeEat);
                        foreach (CItem food in listOfFoods)
                            Console.WriteLine(food.ToString());
                        break;
                    case 7:
                        List<CItem> ItemsOrder = refrigerator1.SortItemsByExpirationDate();
                        break;
                    case 8:
                        List<CShelf> orderShelfs = refrigerator1.SortShelvesByFreeSpace();
                        foreach (CShelf shelf in orderShelfs)
                            Console.WriteLine(shelf.ToString());
                        break;
                    case 9:
                        List<CRefrigerator> sortedRef = new List<CRefrigerator>();
                        //sortedRef = SortRefrigeratorsByFreeSpace(arrRefrigerator);
                        break;
                    case 10:
                        refrigerator1.beforeShopping();
                        break;
                    case 100:
                        flag = 0;
                        break;
                }

            }

        }
    }
}