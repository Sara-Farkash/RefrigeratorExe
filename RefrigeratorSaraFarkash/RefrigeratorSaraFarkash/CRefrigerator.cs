using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RefrigeratorSaraFarkash
{
    class CRefrigerator : IComparable<CRefrigerator>
    {
        private static int countObj = 0;

        private int id;

        public int Id
        {
            get { return id; }
            //set { id = countObj++; }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set
            {
                if (!value.Equals(""))
                    model = value;
                else
                    throw new ArithmeticException("Illegal model, model must be contain string");
            }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set
            {
                if (!value.Equals(""))
                    color = value;
                else
                    throw new ArithmeticException("Illegal color, color must be contain string");
            }
        }
        private int numberOfShelves;

        public int NumberOfShelves
        {
            get { return numberOfShelves; }
            set
            {
                if (value >= 0)
                    numberOfShelves = value;
                else
                    throw new ArithmeticException("Illegal numbershelves, numbershelves must be greater or equal zero");
            }
        }

        public List<CShelf> shelfs;

        public List<CShelf> Shelfs

        {
            get { return shelfs; }
            //set
            //{
            //    if (!(value is null))
            //    {
            //        shelfs = value;
            //    }
            //    else
            //    {
            //        shelfs = new List<CShelf>();
            //    }
            //}
        }

        public CRefrigerator()
        {
            id = countObj++;
            shelfs = new List<CShelf>();
        }

        public void AddShelfs(CShelf shelf)
        {
            if (shelfs.Count >= numberOfShelves)
            {
                Console.WriteLine("we cant add this shelfs, there is no place!!");
            }
            else
            {
                shelfs.Add(shelf);
                Console.WriteLine("the shefs added!!");
            }

        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Department ID: {Id}");
            result.AppendLine($"Model: {Model}");
            result.AppendLine($"Color: {Color}");
            result.AppendLine($"Number of Shelves: {NumberOfShelves}");

            // Print details for each shelf
            result.AppendLine("Shelves:");

            foreach (var shelf in Shelfs)
            {
                result.AppendLine(shelf.ToString());
            }

            return result.ToString();

        }

        //2
        public double spaceLeftInRefrigerator()
        {
            double space = 0.0;
            if (numberOfShelves >= 0)
            {
                for (int i = 0; i < shelfs.Count; i++)
                {
                    space = space + shelfs[i].spaceLeftInShelfs();
                }
            }
            else
            {
                Console.WriteLine("Invalid number of shelves. Cannot calculate space.");
            }

            return space;
        }

        //3
        public void pushToRefItem(CItem item1)
        {

            if (this.spaceLeftInRefrigerator() < item1.TakeSpace)
                Console.WriteLine("there is no space!!!");
            else
            {
                for (int i = 0; i < this.numberOfShelves; i++)
                {
                    if (this.shelfs[i].spaceLeftInShelfs() > item1.TakeSpace)
                    {
                        item1.IdShelf = this.shelfs[i].Id;
                        this.shelfs[i].AddItem(item1);
                        Console.WriteLine("the item is added!!!");
                        break;
                    }
                }
            }
        }

        //4
        public CItem removeItemFromRef(int idItem)
        {
            CItem itemRemove;
            for (int i = 0; i < this.numberOfShelves; i++)
            {
                if (shelfs[i].findItemInShelf(idItem))
                {
                    itemRemove = shelfs[i].removeItemfromShelf(idItem);
                    return itemRemove;
                }
            }

            Console.WriteLine("the item not found!!!");
            return null;
        }
        //5
        public void cleanExpired()
        {
            for (int i = 0; i < shelfs.Count; i++)
            {
                List<CItem> itemsToRemove = new List<CItem>();
                foreach (CItem item in shelfs[i].Items)
                {
                    if (item.ExpiryDate < DateTime.Today)
                    {
                        Console.WriteLine("the product is" + item.ToString()
                        + "Thrown in the trash due to expiration");
                        itemsToRemove.Add(item);
                    }
                }
                if (itemsToRemove.Count >= 0)
                {
                    // Since it is impossible to delete while in a loop, I created a list that stores all the expired products.
                    foreach (CItem item in itemsToRemove)
                    {
                        CItem itemremoving = removeItemFromRef(item.Id);
                    }
                }
            }
        }

        //6
        public List<CItem> wantEat(string kashroot, string typeeat)
        {
            List<CItem> wanttoeat = new List<CItem>();

            for (int i = 0; i < shelfs.Count; i++)
            {
                foreach (CItem item in shelfs[i].Items)
                {
                    if (item.Kashroot == kashroot && item.TypeI == typeeat && item.ExpiryDate > DateTime.Today)
                        wanttoeat.Add(item);
                }
            }
            return wanttoeat;
        }

        // sort

        public int CompareTo(CRefrigerator otherRefrigerator)
        {
            return ((this.spaceLeftInRefrigerator() > otherRefrigerator.spaceLeftInRefrigerator()) ? (-1) : (this.spaceLeftInRefrigerator() == otherRefrigerator.spaceLeftInRefrigerator()) ? 0 : 1);
        }

        public List<CItem> SortItems()
        {
            List<CItem> items = new List<CItem>();
            foreach (CShelf shelf in this.shelfs)
            {
                items.AddRange(shelf.Items);
            }
            items.Sort();
            return items;
        }
        public List<CShelf> SortShelf()
        {
            List<CShelf> shelfs = new List<CShelf>();
            foreach (CShelf shelf in this.shelfs)
            {
                shelfs.Add(shelf);
            }
            shelfs.Sort();

            return shelfs;
        }
        //1
        //
        //A function that receives a date and returns an list with all the food deleted up to the date
        public List<CItem> wantToREMOVE(int untilday, string KashrootItem)
        {
            List<CItem> RemoveItem = new List<CItem>();
            DateTime lastDate = DateTime.Today;
            lastDate = lastDate.AddDays(untilday);
            for (int i = 0; i < this.numberOfShelves; i++)
            {
                foreach (CItem item in this.Shelfs[i].Items)
                {
                    if (item.ExpiryDate <= lastDate && KashrootItem == item.Kashroot)
                    {
                        RemoveItem.Add(item);
                    }
                }
                foreach (CItem itemToRemove in RemoveItem)
                {
                    CItem itemremving = removeItemFromRef(itemToRemove.Id);
                }
            }
            return RemoveItem;
        }
        public Boolean ThereIsPlacefor20()
        {
            if (this.spaceLeftInRefrigerator() >= 20)
                return true;
            return false;
        }

        public void addListItems(List<CItem> itemsAdd)
        {
            foreach (CItem item in itemsAdd)
            {
                this.pushToRefItem(item);
            }
        }

        public void beforeShopping()
        {

            List<CItem> dairyRemove = new List<CItem>();
            List<CItem> meatyRemove = new List<CItem>();
            List<CItem> parveRemove = new List<CItem>();
            int flag = 0;
            if (this.spaceLeftInRefrigerator() < 29)
            {
                this.cleanExpired();

                if (!this.ThereIsPlacefor20())
                {
                    dairyRemove = this.wantToREMOVE(3, "dairy");
                    flag = 1;
                    if (!this.ThereIsPlacefor20())
                    {
                        meatyRemove = this.wantToREMOVE(7, "meaty");
                        flag = 2;
                    }

                    if (!this.ThereIsPlacefor20())
                    {
                        parveRemove = this.wantToREMOVE(1, "parve");
                        flag = 3;
                    }

                }
                if (!this.ThereIsPlacefor20() && flag == 3)
                {
                    //We pushed all the products back into the array
                    Console.WriteLine("This is not the time to shoping today!!!!");
                    this.addListItems(dairyRemove);
                    this.addListItems(meatyRemove);
                    this.addListItems(parveRemove);
                }
            }
            if ((this.ThereIsPlacefor20() && flag == 1 || flag == 2 || flag == 3))
            {
                Console.WriteLine("For your information, we threw away food that had not yet expired in order to have space in the refrigerator");
            }
            if ((this.ThereIsPlacefor20() && flag == 1 || flag == 2 || flag == 3) || flag == 0)
                Console.WriteLine("Let's go shopping!!!");

        }

    }
}
