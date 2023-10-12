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
     

        private int idShelf;

        public int IdShelf
        {
            get { return idShelf; }
            set { idShelf = value; }
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
            get { return items; }
            set {
               
                items = value; 
            
            }
        }
        public void AddItem(CItem item)
        {
            this.placeInShelf -= item.TakeSpace;
            items.Add(item);
        }
        public override string ToString()
        {
            return $"idShelf: {idShelf}, numberLevel: {numberLevel},placeInShelf:{placeInShelf}";
        }
        
    }
}
