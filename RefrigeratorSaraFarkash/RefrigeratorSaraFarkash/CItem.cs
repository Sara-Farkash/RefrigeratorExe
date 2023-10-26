using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RefrigeratorSaraFarkash
{
    public enum Kashroot {Dairy,
                         Parve,
                         Meaty}
    public enum ItemType
                        { Food,
                        food,
                        drink,
                        Drink}
    internal class CItem:IComparable<CItem>
    {
 
        public Guid Id { get; private set; }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                string Illegal = @"[^0-9\s]";
                bool ContainsInvalidCharacters = Regex.IsMatch(value, Illegal);
                if (ContainsInvalidCharacters)
                    throw new FormatException("Illegal name, name must be string");
                else
                    name = value;
            }
        }

        private Guid shelfId;

        public Guid ShelfId { get;set;}

        private ItemType itemType;

        public ItemType ItemType
        {
            get { return itemType; }
            set
            {
                value = itemType;
            }
        }

        private Kashroot kashroot;

        public Kashroot Kashroot
        {
            get { return kashroot; }
            set
            {
                kashroot = value;
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
            return $"idItem: {Id}, kashroo: {kashroot},expiryDate: {expiryDate},takeSpace: {takeSpace}, name : {name}, type: {itemType} shelfId:{shelfId}";
        }

        public int CompareTo(CItem otherItem)
        {
            return (this.ExpiryDate.CompareTo(otherItem.ExpiryDate));

        }
    }
}

