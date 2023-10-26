﻿using System;
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

        public Guid Id { get; private set; }


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
            item.ShelfId = this.Id;
            items.Add(item);
            Console.WriteLine("the item is added!");
        }
        public CShelf()
        {
            Id = Guid.NewGuid();
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
        public CItem removeItemfromShelf(Guid idItem)
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

        public bool findItemInShelf(Guid idItem)
        {
            foreach (CItem item in items)
            {
                if (item.Id==idItem)
                    return true;

            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder shelfDetails = new StringBuilder();
            shelfDetails.AppendLine($"ID: {Id}");
            shelfDetails.AppendLine($"numberLevel: {numberLevel}");
            shelfDetails.AppendLine($"placeInShelf: {placeInShelf}");
            shelfDetails.AppendLine("Items:");
            foreach (CItem itemm in items)
            {
                shelfDetails.AppendLine(itemm.ToString());
            }
            return shelfDetails.ToString(); ;
        }

        public int CompareTo(CShelf othreShelfs)
        {
            return ((this.spaceLeftInShelfs() > othreShelfs.spaceLeftInShelfs()) ? (-1) : (this.spaceLeftInShelfs() == othreShelfs.spaceLeftInShelfs()) ? 0 : 1);
        }


    }
}
