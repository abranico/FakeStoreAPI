using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        static List<Product> _products = [];
        static int _index = 0;

        public List<Product> GetAll()
        {
            return _products;
        }
        public Product? GetById(int id)
        {
            return _products.FirstOrDefault(product => product.Id == id);

        }
        public Product Create(Product newProduct)
        {
            newProduct.Id = _index++;
            _products.Add(newProduct);
            return newProduct;
        }

        public void Update(Product product)
        {
            var obj = _products.FirstOrDefault(x => x.Id == product.Id) 
                ?? throw new NotFoundException(nameof(Product), product.Id);
            obj = product;
        }
        public void Delete(Product product)
        {
            _products.Remove(product);
        }
    }
}
