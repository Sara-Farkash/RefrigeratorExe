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
            set {
                if (!value.Equals(""))
                    name = value;
                else
                    Console.WriteLine("Illegal name, name must be string");
                    //throw new ArithmeticException("Illegal name, name must be string");
            }
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
            set {
                if (value.Equals("food") || value.Equals("Food") || value.Equals("Drink") || value.Equals("drink"))
                    typeI = value;
                else
                    Console.WriteLine("Illegal type, type must be food or Food or Drink or drink");
                    //throw new ArithmeticException("Illegal type, type must be food or Food or Drink or drink");
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
                    Console.WriteLine("Invalid value for Kashroot. Kashroot must be meaty or parve or dairy");
               // throw new ArgumentException("Invalid value for Kashroot. Kashroot must be meaty or parve or dairy");

            }
        }
        private DateTime expiryDate;

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set {if
                    (value > DateTime.Now)
                    expiryDate = value;
                else
                    Console.WriteLine("Illegal Date, expire date must be after today!");
                   // throw new ArithmeticException("Illegal Date, expire date must be after today!");

                 }
        }

        private double takeSpace;

        public double TakeSpace
        {
            get { return takeSpace; }
            set {
                if (value >= 0)
                    takeSpace = value;
                else
                    Console.WriteLine("Illegal space, space must be a postive number!");

                    //throw new ArithmeticException("Illegal space, space must be a postive number!");
            }
        }

        //public CItem(string name, string type,string kashroot,DateTime expiryDate,double takeSpace)
        //{
        //    try
        //    {
        //        Name = name;
        //        TypeI = type;
        //        Kashroot = kashroot;
        //        ExpiryDate = expiryDate;
        //        TakeSpace = takeSpace;
        //    }catch(Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}
      
        public override string ToString()
        {
            return $"idItem: {id}, kashroo: {kashroot},expiryDate:{expiryDate},takeSpace:{takeSpace}";
        }
    }
}
