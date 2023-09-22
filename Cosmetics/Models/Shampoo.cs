using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Text;

namespace Cosmetics.Models
{
    public class Shampoo : Product, IShampoo
    {
        private int millilitres;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage)
        {
            Name = name;
            Brand = brand;
            Price = price;
            Gender = gender;
            Millilitres = millilitres;
            Usage = usage;
        }

        public int Millilitres
        {
            get
            {
                return this.millilitres;
            }
            set
            {
                ValidationHelper.ValidateNonNegative(value, "millilitres");
                this.millilitres = value;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }
            set
            {
                if (value == UsageType.Medical && value == UsageType.EveryDay)
                    throw new ArgumentException("Usage should be either \"Medical\" or \"Everyday\"");

                this.usage = value;
            }
        }

        public override string Print()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"#{Name} {Brand}");
            stringBuilder.AppendLine($"# Price: {Price}");
            stringBuilder.AppendLine($"# Gender: {Gender}");
            stringBuilder.AppendLine($"# Milliliters: {Millilitres}");
            stringBuilder.AppendLine($"# Usage: {Usage}");
            stringBuilder.AppendLine("===");

            return stringBuilder.ToString();
        }
    }
}
