using System;
using Cosmetics.Models.Contracts;

namespace Cosmetics.Models
{
    public class Cream : Product, ICream
    {
        public Cream()
        {
            this.NameMinLength = 3;
            this.NameMaxLength = 15;
            this.BrandMinLength = 3;
            this.BrandMaxLength = 15;
        }

        public int Scent
        {
            get
            {

            }
        }

        public override string Print()
        {


# Scent: {scentType}
        }
    }
}

