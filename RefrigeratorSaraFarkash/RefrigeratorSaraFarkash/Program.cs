// See https://aka.ms/new-console-template for more information

using RefrigeratorSaraFarkash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace exeRefreg
{
    class Program
    {
        public static List<CRefrigerator> SortRefrigerator(List<CRefrigerator> refrigerators)
        {
            refrigerators.Sort();
            return refrigerators;
        }

        public static void inputName(CItem cItem)
        {
            Console.WriteLine("please enter Name");
            try
            {
                cItem.Name = Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                inputName(cItem);
            }
        }
        public static void inputTakeSpace(CItem cItem)
        {
            Console.WriteLine("please enter TakeSpace");
            try
            {
                cItem.TakeSpace = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                inputTakeSpace(cItem);
            }
        }

        public static void inputTypeI(CItem cItem)
        {
            Console.WriteLine("please enter itemType");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("please chose the type item:");
                Console.WriteLine("the option is:Food,food,Drink,drink");
                string userInputType = Console.ReadLine();
                if (Enum.TryParse<ItemType>(userInputType, out ItemType result))
                {
                    cItem.ItemType = result;
                    flag = false;
                }
                else
                    Console.WriteLine("Invalid select, try agian");
            }
        }

        public static void inputExpiryDate(CItem cItem)
        {
            Console.WriteLine("please enter TypeI");
            try
            {
                cItem.ExpiryDate = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                inputExpiryDate(cItem);
            }
        }
        public static void inputKashroot(CItem item)
        {

            bool flag = true;
            while (flag) { 
            Console.WriteLine("please chose the kashroot:");
            Console.WriteLine("the option is:Dairy,\r\nParve,\r\nMeaty");
            string userInputKashroot = Console.ReadLine();
            if (Enum.TryParse<Kashroot>(userInputKashroot, out Kashroot result))
                {
                    item.Kashroot = result;
                    flag = false;
                }
            else
                Console.WriteLine("Invalid select, try agian");
            }
        }
        public static CItem buildItem()
        {
            CItem item = new CItem();
            inputName(item);
            inputKashroot(item);
            inputTakeSpace(item);
            inputTypeI(item);
            inputExpiryDate(item);
            return item;
        }

        public static void inputnumberLevel(CShelf shelf)
        {
            Console.WriteLine("please enter numberLevel");
            try
            {
                shelf.NumberLevel = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                inputnumberLevel(shelf);
            }

        }
        public static void inputPlaceInShelf(CShelf shelf)
        {
            Console.WriteLine("please enter PlaceInShelf");
            try
            {
                shelf.PlaceInShelf = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                inputPlaceInShelf(shelf);
            }

        }
        public static CShelf buildShelfs()
        {
            CShelf shelf = new CShelf();
            inputnumberLevel(shelf);
            inputPlaceInShelf(shelf);
            Console.WriteLine(shelf.ToString());
            return shelf;
        }

        public static void inputModel(CRefrigerator refrigerator)
        {
            Console.WriteLine("please enter model");
            try
            {
                refrigerator.Model = Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                inputModel(refrigerator);
            }

        }
        public static void inputColor(CRefrigerator refrigerator)
        {
            Console.WriteLine("please enter color");
            try
            {
                refrigerator.Color = Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                inputColor(refrigerator);
            }

        }
        public static void inputNumberOfShelves(CRefrigerator refrigerator)
        {
            Console.WriteLine("please enter NumberOfShelves");
            try
            {
                refrigerator.NumberOfShelves = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                inputNumberOfShelves(refrigerator);
            }

        }

        public static CRefrigerator buildRefrigerator()
        {

            CRefrigerator refrigerator = new CRefrigerator();
            inputModel(refrigerator);
            inputColor(refrigerator);
            inputNumberOfShelves(refrigerator);

            return refrigerator;
        }

        static void Main(string[] args)
        {
            bool flag = true;
            //items

            CItem item1 = new CItem();
            item1 = buildItem();
            CItem item2 = new CItem();
            item2 = buildItem();

            //shelfs
            CShelf shelf1 = new CShelf();
            shelf1 = buildShelfs();
            shelf1.AddItem(item1);
            shelf1.AddItem(item2);

            //refrigerators
            List<CRefrigerator> refrigerators = new List<CRefrigerator>();
            CRefrigerator refrigerator = new CRefrigerator();
            refrigerator = buildRefrigerator();
            refrigerator.Shelfs.Add(shelf1);
            refrigerators.Add(refrigerator);
            Console.WriteLine("The Refrigerator app ❤ ");

            while (flag)
            {
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
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(refrigerator.ToString());
                        break;
                    case 2:
                        Console.WriteLine(refrigerator.spaceLeftInRefrigerator());
                        break;
                    case 3:
                        Console.WriteLine("Enter the item details:");
                        CItem itemtemp = new CItem();
                        itemtemp = buildItem();
                        refrigerator.pushToRefItem(itemtemp);
                        break;
                    case 4:
                        Console.WriteLine("Enter the ID of the item to remove:");
                       // Guid idToRemove = Console.ReadLine();
                       // CItem itemWantOut = refrigerator.removeItemFromRef(idToRemove);
                        break;
                    case 5:
                        refrigerator.cleanExpired();
                        break;
                    case 6:
                        Console.WriteLine("What do you want to eat?  the type is: Food.food.Drink.drink");
                        string userInputType = Console.ReadLine();
                        if (!Enum.TryParse<ItemType>(userInputType, out ItemType resultTypeItem))
                            Console.WriteLine("sorry try again you chose not invlied kashroot!");
                        else
                        {                  
                        Console.WriteLine("please chose the kashroot:");
                        Console.WriteLine("the option is:Dairy,\r\nParve,\r\nMeaty");
                        string userInputKashroot = Console.ReadLine();
                        if (!Enum.TryParse<Kashroot>(userInputKashroot, out Kashroot resultKashroot))
                            Console.WriteLine("sorry try again you chose not invlied kashroot!");
                        else
                        {
                            List<CItem> listOfFoods = refrigerator.wantEat(resultKashroot, resultTypeItem);
                            if (listOfFoods.Count <= 0)
                                Console.WriteLine("Sorry we don't have anything to offer you to eat");
                            else
                            {
                                foreach (CItem food in listOfFoods)
                                    Console.WriteLine(food.ToString());
                            }
                            }
                        }
                        break;
                    case 7:
                        List<CItem> ItemsOrder = refrigerator.SortItems();
                        foreach (CItem item in ItemsOrder)
                            Console.WriteLine(item.ToString());
                        break;
                    case 8:
                        List<CShelf> orderShelfs = refrigerator.SortShelf();
                        foreach (CShelf shelf in orderShelfs)
                            Console.WriteLine(shelf.ToString());
                        break;
                    case 9:
                        List<CRefrigerator> sortedRef = SortRefrigerator(refrigerators);
                        break;
                    case 10:
                        refrigerator.beforeShopping();
                        break;
                    case 100:
                        flag = false;
                        break;
                }
            }
        }
    }
}
