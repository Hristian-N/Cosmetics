using System.Collections.Generic;

namespace Cosmetics.Models.Contracts
{
    public interface IShoppingCart
    {
        ICollection<Product> Products { get; }

        void AddProduct(Product product);

        void RemoveProduct(Product product);

        bool ContainsProduct(Product product);

        decimal TotalPrice();
    }
}