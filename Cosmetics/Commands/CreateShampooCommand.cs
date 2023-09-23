using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

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

            if (this.Repository.ProductExists(name))
                throw new ArgumentException("Name already exist");

            if (!decimal.TryParse(this.CommandParameters[2], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
                throw new ArgumentException("Price is invalid");

            if (!Enum.TryParse<GenderType>(this.CommandParameters[3], out GenderType gender))
                throw new ArgumentException("Gender is invalid");

            if (!int.TryParse(this.CommandParameters[4], out int millilitres))
                throw new ArgumentException("Millilitres are invalid");

            if (!Enum.TryParse<UsageType>(this.CommandParameters[5], out UsageType usage))
                throw new ArgumentException("Usage are invalid");

            this.Repository.CreateShampoo(name, brand, price, gender, millilitres, usage);

            return $"Shampoo with name {name} was created!";

        }

    }
}
