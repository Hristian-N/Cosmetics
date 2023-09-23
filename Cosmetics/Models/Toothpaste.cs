using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Cosmetics.Models
{
    public class Toothpaste : Product, IToothpaste
    {

        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
        {
            Name = name;
            Brand = brand;
            Price = price;
            Gender = gender;
            Ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Ingredients are null");

                this.ingredients = value;
            }

        }

        public override string Print()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.Print());
            stringBuilder.AppendLine($" #Ingredients: {Ingredients}");
            stringBuilder.AppendLine("===");

            return stringBuilder.ToString();
        }
    }
}
