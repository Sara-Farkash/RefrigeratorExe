using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorSaraFarkash
{
    internal class CItem:IComparable<CItem>
    {

        public Guid Id { get; private set; }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (!value.Equals(""))
                    name = value;
                else
                    throw new ArithmeticException("Illegal name, name must be string");
            }
        }

        private Guid idShelf;

        public Guid IdShelf
        {
            get;
            set;
          //  {
                
                //if (value >= 0)
                //    idShelf = value;
                //else
                //    throw new ArithmeticException("Illegal idShelf, idShelf must be int");
           // }
        }

        private string typeI;

        public string TypeI
        {
            get { return typeI; }
            set
            {
                if (value.Equals("food") || value.Equals("Food") || value.Equals("Drink") || value.Equals("drink"))
                    typeI = value;
                else
                    throw new ArithmeticException("Illegal type, type must be food or Food or Drink or drink");
            }
        }

        private string kashroot;

        public string Kashroot
        {
            get { return kashroot; }
            set
            {
                if (value == "dairy" || value == "parve" || value == "meaty")
                {
                    kashroot = value;
                }
                else
                    throw new ArithmeticException("Invalid value for Kashroot. Kashroot must be meaty or parve or dairy");

            }
        }
        private DateTime expiryDate;

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set
            {
                if
                   (value > DateTime.Now)
                    expiryDate = value;
                else
                    throw new ArithmeticException("Illegal Date, expire date must be after today!");

            }
        }

        private double takeSpace;
        public double TakeSpace
        {
            get { return takeSpace; }
            set
            {
                if (value >= 0)
                    takeSpace = value;
                else
                    throw new ArithmeticException("Illegal space, space must be a postive number!");
            }
        }
        public CItem()
        {
            Id = Guid.NewGuid();
        }
        public override string ToString()
        {
            return $"idItem: {Id}, kashroo: {kashroot},expiryDate: {expiryDate},takeSpace: {takeSpace}, name : {name}, type: {typeI}";
        }

        public int CompareTo(CItem otherItem)
        {
            return (this.ExpiryDate.CompareTo(otherItem.ExpiryDate));

        }
    }
}

