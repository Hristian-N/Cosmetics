using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cosmetics.Commands
{
    public class CreateToothpasteCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 5;

        public CreateToothpasteCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);

            string name = this.CommandParameters[0];
            string brand = this.CommandParameters[1];

            if (!decimal.TryParse(this.CommandParameters[2], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
                throw new ArgumentException("Price is invalid");

            if (!Enum.TryParse<GenderType>(this.CommandParameters[3], out GenderType gender))
                throw new ArgumentException("Gender is invalid");

            if (this.Repository.ProductExists(name))
                throw new ArgumentException("Name already exist");

            string ingredients = this.CommandParameters[4];

            this.Repository.CreateToothpaste(name, brand, price, gender, ingredients);

            return $"Toothpaste with name {name} was created!";
        }

    }
}
