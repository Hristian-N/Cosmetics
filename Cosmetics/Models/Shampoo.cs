using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Text;

namespace Cosmetics.Models
{
    public class Shampoo : IShampoo
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;
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

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                    throw new ArgumentOutOfRangeException($"Name must be between {NameMaxLength} an {NameMaxLength}");

                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                if (value.Length < BrandMinLength || value.Length > BrandMaxLength)
                    throw new ArgumentOutOfRangeException($"Brand must be between {BrandMinLength} an {BrandMaxLength}");

                this.brand = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Price cannot be lower or equal to 0");

                this.price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (value != GenderType.Men || value != GenderType.Women || value != GenderType.Unisex)
                    throw new ArgumentException("Gender must be Men, Women or Unisex");

                this.gender = value;
            }
        }

        public int Millilitres
        {
            get
            {
                return this.millilitres;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Millilitres cannot be lower or equal to 0");

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
                if (value == UsageType.Medical || value == UsageType.EveryDay)
                    throw new ArgumentException("Usage should be either \"Medical\" or \"Everyday\"");

                this.usage = value;
            }
        }

        public string Print()
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
