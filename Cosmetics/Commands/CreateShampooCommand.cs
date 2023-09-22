using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Commands
{
    public class CreateShampooCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 6;


        public CreateShampooCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);

            string name = this.CommandParameters[0];
            string brand = this.CommandParameters[1];

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name is null");
            for (int i = 0; i < this.Repository.Products.Count; i++)
            {
                if (this.Repository.Products.ElementAt(i).Name.Equals(name))
                    throw new ArgumentException("Name already exist");
            }  
            if (!decimal.TryParse(this.CommandParameters[2], out decimal price))
                throw new ArgumentException("Price is invalid");
            if (!Enum.TryParse<GenderType>(this.CommandParameters[3], out GenderType gender))
                throw new ArgumentException("Gender is invalid");
            if (!int.TryParse(this.CommandParameters[4], out int millilitres))
                throw new ArgumentException("Millilitres are invalid");
            if (!Enum.TryParse<UsageType>(this.CommandParameters[5], out UsageType usage))
                throw new ArgumentException("Usage are invalid");

            this.Repository.CreateShampoo(name, brand, price, gender, millilitres, usage);

            return $"Shampoo was created!";

        }
    }
}
