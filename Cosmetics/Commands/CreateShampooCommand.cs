using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

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
            decimal price = this.CommandParameters[2];
            GenderType gender = this.CommandParameters[3];
            int millilitres = this.CommandParameters[4];
            UsageType usage = this.CommandParameters[5];

            this.Repository.CreateShampoo(name, brand, price, gender, millilitres, usage);

            return $"Shampoo was created!";

        }
    }
}
