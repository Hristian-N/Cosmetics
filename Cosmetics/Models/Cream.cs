using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;

namespace Cosmetics.Models
{
    public class Cream : Product, ICream
    {
        private ScentType scent;
        public Cream(string name, string brand, decimal price, GenderType gender, ScentType scent)
        {
            this.NameMinLength = 3;
            this.NameMaxLength = 15;
            this.BrandMinLength = 3;
            this.BrandMaxLength = 15;

            Name = name;
            Brand = brand;
            Price = price;
            Gender = gender;
            Scent = scent;
        }

        public ScentType Scent
        {
            get
            {
                return this.scent;
            }
            set
            {
                if (value != ScentType.Rose && value != ScentType.Lavender && value != ScentType.Rose)
                    throw new ArgumentException("Scent must be Rose, Lavender or Rose");

                this.scent = value;
            }
        }

        public override string Print()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.Print());
            stringBuilder.AppendLine($" #Scent: {Scent}");
            stringBuilder.AppendLine("===");

            return stringBuilder.ToString();
        }
    }
}

