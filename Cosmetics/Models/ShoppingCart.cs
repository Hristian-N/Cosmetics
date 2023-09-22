using Cosmetics.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private const string ProductNotFoundErrorMessage = "Shopping cart does not contain product with name {0}!";

        private readonly ICollection<Product> productList;

        public ShoppingCart()
        {
            this.productList = new List<Product>();
        }

        public ICollection<Product> Products
        {
            get { return new List<Product>(this.productList); }
        }

        public void AddProduct(Product product)
        {
            this.productList.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            if (!ContainsProduct(product))
            {
                throw new ArgumentException(string.Format(ProductNotFoundErrorMessage, product.Name));
            }
            this.productList.Remove(product);
        }

        public bool ContainsProduct(Product product)
        {
            return this.productList.Any(x => x.Name == product.Name);
        }

        public decimal TotalPrice()
        {
            return this.productList.Sum(x => x.Price);
        }
    }
}
