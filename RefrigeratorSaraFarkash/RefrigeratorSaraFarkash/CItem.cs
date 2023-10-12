using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorSaraFarkash
{
    internal class CItem
    {

        private int idItem;

        public int IdItem
        {
            get { return idItem; }
            set { idItem = value; }
        }

        private string nameItem;

        public string NameItem
        {
            get { return nameItem; }
            set { nameItem = value; }
        }

        private int idShelf;

        public int IdShelf
        {
            get { return idShelf; }
            set { idShelf = value; }
        }

        private string typeI;

        public string TypeI
        {
            get { return typeI; }
            set { typeI = value; }
        }

        private string kashroo;

        public string Kashroo
        {
            get { return kashroo; }
            set { kashroo = value; }
        }
        private DateTime expiryDate;

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

        private double takeSpace;

        public double TakeSpace
        {
            get { return takeSpace; }
            set { takeSpace = value; }
        }

        public override string ToString()
        {
            return $"idItem: {idItem}, kashroo: {kashroo},expiryDate:{expiryDate},takeSpace:{takeSpace}";
        }
    }
}
