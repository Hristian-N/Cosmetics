using System;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;

namespace Cosmetics.Models
{
    public class Cream : Product, ICream
    {
        private Scent scent;
        public Cream(string name, string brand, decimal price, GenderType gender, int millilitres, Scent scent)
        {
            this.NameMinLength = 3;
            this.NameMaxLength = 15;
            this.BrandMinLength = 3;
            this.BrandMaxLength = 15;

            Scent = scent;
        }

        public Scent Scent
        {
            get
            {
                return this.scent;
            }
            set
            {
                if (value != Scent.Rose && value != Scent.Lavender && value != Scent.Rose)
                    throw new ArgumentException("Scent must be Rose, Lavender or Rose");

                this.scent = value;
            }
        }

        public override string Print()
        {

            return "str";
            // # Scent: {scentType}
        }
    }
}

