using Cosmetics.Helpers;
using System;
using System.Xml.Linq;
using Cosmetics.Models.Enums;
using System.Text;

namespace Cosmetics.Models.Contracts
{
    public abstract class Product : IProduct
    {

        protected int NameMinLength = 3;
        protected int NameMaxLength = 10;
        protected int BrandMinLength = 2;
        protected int BrandMaxLength = 10;

        protected string name;
        protected string brand;
        protected decimal price;
        protected GenderType gender;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                ValidationHelper.ValidateIntRange(NameMinLength, NameMaxLength, value.Length, name);
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
                ValidationHelper.ValidateIntRange(BrandMinLength, BrandMaxLength, value.Length, brand);
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
                ValidationHelper.ValidateNonNegative(value, "price");
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
                if (value != GenderType.Men && value != GenderType.Women && value != GenderType.Unisex)
                    throw new ArgumentException("Gender must be Men, Women or Unisex");

                this.gender = value;
            }
        }

        public virtual string Print()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"#{Name} {Brand}");
            stringBuilder.AppendLine($" #Price: {Price}");
            stringBuilder.Append($" #Gender: {Gender}");

            return stringBuilder.ToString();
        }
    }
}
