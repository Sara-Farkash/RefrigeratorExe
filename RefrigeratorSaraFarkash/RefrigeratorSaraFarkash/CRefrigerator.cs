using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RefrigeratorSaraFarkash
{
    internal class CRefrigerator
    {

        private static int countObj = 0;

        private int id;

        public int Id
        {
            get { return id; }
            set { id = countObj++; }
        }

        private int model;

        public int Model
        {
            get { return model; }
            set { model = value; }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        private int numberOfShelves;

        public int NumberOfShelves
        {
            get { return numberOfShelves; }
            set { numberOfShelves = value; }
        }

        private List<CShelf> shelfs;

        public List<CShelf> Shelfs

        {
            get { return shelfs; }
            set
            {
                if (!(value is null))
                {
                    shelfs = value;
                }
                else
                {
                    shelfs = new List<CShelf>();
                }
            }
        }
        public CRefrigerator()
        {
            shelfs = new List<CShelf>();
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
                for (int i = 0; i < numberOfShelves; i++)
                {
                    space += shelfs[i].spaceLeftInShelfs();
                }
            }
            else
            {
                Console.WriteLine("Invalid number of shelves. Cannot calculate space.");
            }

            return space;
        }

        //3
        public void pushToRef(CItem item1)
        {

            if (this.spaceLeftInRefrigerator() < item1.TakeSpace)
                Console.WriteLine("there is no space!!!");///אני צריכה לזרוק שגיאה אין מקום!!!
            else
            {
                for (int i = 0; i < this.numberOfShelves; i++)
                {
                    if (this.shelfs[i].spaceLeftInShelfs() > item1.TakeSpace)
                    {
                        item1.Id = this.shelfs[i].Id;
                        this.shelfs[i].AddItem(item1);
                        Console.WriteLine("the item is added!!!");

                        break;
                    }
                }
            }
        }



        //4
        public CItem removeItem(int idItem)
        {
            CItem removeItem = null;

            for (int i = 0; i < this.numberOfShelves; i++)
            {
                if (shelfs[i].findItemInShelf(idItem))
                {
                    removeItem = shelfs[i].removeItemfromShelf(idItem);
                    return removeItem;
                }
            }
            //זריקת שגיאה לא נמצא הפריט המבוקש
            if (removeItem == null)
                Console.WriteLine("the item not found!!!");
            return removeItem;
        }
        //5
        public void cleanExpired()
        {
            for (int i = 0; i < numberOfShelves; i++)
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
                foreach (CItem itemToRemove in itemsToRemove)
                {
                    CItem removedItem = shelfs[i].removeItemfromShelf(itemToRemove.Id);
                }
            }
        }

        //6
        public List<CItem> wantEat(string kashroot, string typeeat)
        {
            List<CItem> wanttoeat = new List<CItem>();

            for (int i = 0; i < numberOfShelves; i++)
            {
                foreach (CItem item in shelfs[i].Items)
                {
                    if (item.Kashroot == kashroot && item.TypeI == typeeat && item.ExpiryDate > DateTime.Today)
                        wanttoeat.Add(item);
                }
            }
            return wanttoeat;
        }


        //8
        // 
        public List<CShelf> SortShelvesByFreeSpace()
        {
            return this.shelfs.OrderByDescending(shelf => shelf.spaceLeftInShelfs()).ToList();
        }

        public List<CItem> SortItemsByExpirationDate()
        {
            List<CItem> allItems = shelfs.SelectMany(shelf => shelf.Items).ToList();
            return allItems.OrderBy(item => item.ExpiryDate).ToList();
        }
        //1
        //פונקציה שמקבלת תאריך ומחזירה מערך עם כל האוכל המחוק עד התאריך
        public List<CItem> wantToREMOVE(int untilday, string KashrootItem)
        {
            List<CItem> RemoveItem = new List<CItem>();
            DateTime lastDate = DateTime.Today;
            lastDate = lastDate.AddDays(untilday);
            for (int i = 0; i < this.numberOfShelves; i++)
            {
                List<CItem> itemsToRemove = new List<CItem>();
                foreach (CItem item in this.Shelfs[i].Items)
                {
                    if (item.ExpiryDate <= lastDate && KashrootItem == item.Kashroot)
                    {
                        itemsToRemove.Add(item);
                        //   RemoveItem.Add(removeItem(item.Id));
                    }
                }
                foreach (CItem itemToRemove in itemsToRemove)
                {
                    RemoveItem.Add(removeItem(itemToRemove.Id));
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

        public void addListItem(List<CItem> itemsAdd)
        {
            foreach (CItem item in itemsAdd)
            {
                this.pushToRef(item);
            }
        }

        public void beforeShopping()
        {
            List<CItem> ChalviRemove = new List<CItem>();
            List<CItem> BashariRemove = new List<CItem>();
            List<CItem> ParveiRemove = new List<CItem>();
            int flag = 0;
            if (this.spaceLeftInRefrigerator() < 29)
            {
                this.cleanExpired();

                if (!this.ThereIsPlacefor20())
                {
                    ChalviRemove = this.wantToREMOVE(3, "Chalvi");
                    flag = 1;
                    if (!this.ThereIsPlacefor20())
                    {
                        BashariRemove = this.wantToREMOVE(7, "Bashari");
                        flag = 2;
                    }

                    if (!this.ThereIsPlacefor20())
                    {
                        ParveiRemove = this.wantToREMOVE(1, "Parve");
                        flag = 3;
                    }

                }
                if (!this.ThereIsPlacefor20() && flag == 3)
                {
                    //דחפנו בחזרה למערךאת כל המוצרים
                    Console.WriteLine("This is not the time to shop today!!!!");
                    this.addListItem(ChalviRemove);
                    this.addListItem(BashariRemove);
                    this.addListItem(ParveiRemove);
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
