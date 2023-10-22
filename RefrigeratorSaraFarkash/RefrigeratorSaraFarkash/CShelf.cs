using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorSaraFarkash
{
    class CShelf : IComparable<CShelf>
    {

        private static int countObj = 0;

        private int id;

        public int Id
        {
            get { return id; }
        }

        private int numberLevel;

        public int NumberLevel
        {
            get { return numberLevel; }
            set
            {
                if (value >= 0)
                    numberLevel = value;
                else
                    throw new ArithmeticException("Illegal floor ,floor must be a positive number");
            }
        }

        private double placeInShelf;

        public double PlaceInShelf
        {
            get { return placeInShelf; }
            set
            {
                if (value >= 0)
                    placeInShelf = value;
                else
                    throw new ArithmeticException("Illegal placeInShelf ,placeInShelf must be a positive number");

            }
        }
        public List<CItem> items;

        public List<CItem> Items
        {
            get => items;
        }

        public void AddItem(CItem item)
        {
            item.IdShelf = this.id;
            items.Add(item);
            Console.WriteLine("the item is added!");
        }
        public CShelf()
        {
            id = countObj++;
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

            foreach (CItem item in items)
            {
                if (item.Id == idItem)
                {
                    items.Remove(item);
                    return item;
                }

            }
            Console.WriteLine("no founf item!!");
            return null;
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

        public int CompareTo(CShelf othreShelfs)
        {
            return ((this.spaceLeftInShelfs() > othreShelfs.spaceLeftInShelfs()) ? (-1) : (this.spaceLeftInShelfs() == othreShelfs.spaceLeftInShelfs()) ? 0 : 1);
        }


    }
}
