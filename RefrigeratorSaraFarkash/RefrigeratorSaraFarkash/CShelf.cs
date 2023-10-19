using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorSaraFarkash
{
    internal class CShelf
    {


        private static int countObj = 0;

        private int id;

        public int Id
        {
            get { return id; }
            set { id = countObj++; }
        }

        private int numberLevel;

        public int NumberLevel
        {
            get { return numberLevel; }
            set { numberLevel = value; }
        }

        private double placeInShelf;

        public double PlaceInShelf
        {
            get { return placeInShelf; }
            set { placeInShelf = value; }
        }

        private List<CItem> items;

        public List<CItem> Items
        {
            get => items;
            set
            {
                if (!(value is null))
                {
                    items = value;
                }
                else
                {
                    items = new List<CItem>();
                }
            }
        }
        public void AddItem(CItem item)
        {
            items.Add(item);
        }
        public CShelf()
        {
            items = new List<CItem>();
        }

        public double spaceLeftInShelfs()
        {
            double spaceleft = 0.0;
            if (!(this.items is null))
            {
                foreach (CItem item in items)
                {
                    spaceleft += item.TakeSpace;
                }
            }
            spaceleft = this.placeInShelf - spaceleft;
            return spaceleft;
        }
        public CItem removeItemfromShelf(int idItem)
        {
            CItem itemrem = new CItem();
            int i = 0;
            foreach (CItem item in items)
            {
                if (item.Id == idItem)
                {
                    itemrem.Id = item.Id;
                    itemrem.IdShelf = item.IdShelf;
                    itemrem.Kashroot = item.Kashroot;
                    itemrem.Name = item.Name;
                    itemrem.TakeSpace = item.TakeSpace;
                    items.RemoveAt(i);
                    return itemrem;
                }
                i++;
            }
            return itemrem;
        }

        public bool findItemInShelf(int idItem)
        {
            foreach (CItem item in items)
            {
                if (item.Id == idItem)
                    return true;

            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder DetailsShelf = new StringBuilder();
            DetailsShelf.AppendLine($"ID: {Id}");
            DetailsShelf.AppendLine($"numberLevel: {numberLevel}");
            DetailsShelf.AppendLine($"placeInShelf: {placeInShelf}");
            DetailsShelf.AppendLine("Items:");
            foreach (CItem itemm in items)
            {
                DetailsShelf.AppendLine(itemm.ToString());
            }
            return DetailsShelf.ToString(); ;
        }
        public List<CItem> SortProductsByExpirationDate()
        {
            return this.items.OrderBy(items => items.ExpiryDate).ToList();
        }


    }
}
