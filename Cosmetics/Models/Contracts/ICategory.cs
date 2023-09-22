using System.Collections.Generic;

namespace Cosmetics.Models.Contracts
{
    public interface ICategory
    {
        string Name { get; }
        ICollection<Product> Products { get; }

        void AddProduct(Product product);

        void RemoveProduct(Product product);

        string Print();
    }
}
