using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Commands
{
    public class CreateCreamCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 5;

        public CreateCreamCommand(IList<string> parameters, IRepository repository)
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

            if (!Enum.TryParse<ScentType>(this.CommandParameters[4], out ScentType scent))
                throw new ArgumentException("Scent are invalid");

            this.Repository.CreateCream(name, brand, price, gender, scent);

            return $"Cream with name {name} was created!";

        }
    }
}
