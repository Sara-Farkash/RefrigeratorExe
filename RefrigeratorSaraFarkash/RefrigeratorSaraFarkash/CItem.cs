using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorSaraFarkash
{
    internal class CItem
    {

        private static int countObj = 0;
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = countObj++;
            }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
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

        private string kashroot;

        public string Kashroot
        {
            get { return kashroot; }
            set
            {
                if (value != "dairy" && value != "fur" && value != "meaty")
                {
                    throw new ArgumentException("Invalid value for Kashroot.");
                }
                kashroot = value;
            }
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
            return $"idItem: {id}, kashroo: {kashroot},expiryDate:{expiryDate},takeSpace:{takeSpace}";
        }
    }
}
