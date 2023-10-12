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

        private int idRef;

        public int IdRef
        {
            get { return idRef; }
            set { idRef = value; }
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

        public List<CShelf>Shelfs

        {
            get { return shelfs; }
            set { shelfs = value; }
        }
        public override string ToString()
        {
            return $"idRef: {idRef}, color: {color},numberOfShelves:{numberOfShelves}";
        }

        //2
        public double spaceLeft()
        {
            double space = 0.0;

            for (int i = 0; i < numberOfShelves; i++)
            {
                space+=shelfs[i].PlaceInShelf;
            }

            return space; }

        //3
        public void pushToRef(CItem item1)
        {
            if (this.spaceLeft() < item1.TakeSpace)
                Console.WriteLine("there is no space!!!");
            else
            {
                for (int i = 0; i < this.numberOfShelves; i++)
                {
                    if (this.shelfs[i].PlaceInShelf > item1.TakeSpace)
                    {
                        item1.IdShelf = this.shelfs[i].IdShelf;
                        this.shelfs[i].AddItem(item1);
                        Console.WriteLine("the item is added");
                        break;
                    }

                }
            }        }
        
        //4
        ////public CItem removeItem(int idItem)
        ////{
        ////    CItem removeItem;
        ////    for (int i = 0; i < this.numberOfShelves; i++)
        ////    {
        ////        foreach(CItem itemm in this.shelfs[i].Items)
        ////        {
        ////            if (itemm.IdItem == idItem)
        ////            {
        ////                removeItem = itemm;

        ////                return removeItem;
        ////            }
        ////        }
        ////    }
        ////}    


    }
}
