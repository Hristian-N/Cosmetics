using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Cosmetics.Models
{
    public class Toothpaste : IToothpaste
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;
        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
        {
            Name = name;
            Brand = brand;
            Price = price;
            Gender = gender;
            Ingredients = ingredients;
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
                    throw new ArgumentException($"Name must be between {NameMaxLength} an {NameMaxLength}");

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
                    throw new ArgumentException($"Name must be between {BrandMinLength} an {BrandMaxLength}");

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
                    throw new ArgumentException("Price cannot be lower or equal to 0");

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
                if (value == GenderType.Men || value == GenderType.Women || value == GenderType.Unisex)
                    throw new ArgumentException("Gender must be Men, Women or Unisex");

                this.gender = value;
            }
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
            set
            {
                this.Ingredients = value;
            }

        }

        public string Print()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"#{Name} {Brand}");
            stringBuilder.AppendLine($"# Price: {Price}");
            stringBuilder.AppendLine($"# Gender: {Gender}");
            stringBuilder.AppendLine($"# # Ingredients: {Ingredients}");
            stringBuilder.AppendLine("===");

            return stringBuilder.ToString();
        }
    }
}
