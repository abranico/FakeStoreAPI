using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        { 
            var product = _productRepository.GetById(id);
            if(product == null) throw new NotFoundException(nameof(Product), id);
            return product;
        }

        public Product Create(ProductCreateRequest productCreateRequest)
        {
            Product newProduct = new Product();
            newProduct.Name = productCreateRequest.Name;
            newProduct.Description = productCreateRequest.Description;
            newProduct.Price = productCreateRequest.Price;
            return _productRepository.Create(newProduct);

        }

        public void Update(ProductUpdateRequest productUpdateRequest, int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) throw new NotFoundException(nameof(Product), id);

            if (productUpdateRequest.Name != string.Empty) product.Name = productUpdateRequest.Name;
            if (productUpdateRequest.Description != string.Empty) product.Description = productUpdateRequest.Description;
            if (productUpdateRequest.Price != 0) product.Price = productUpdateRequest.Price;
            _productRepository.Update(product);
        }

        public void Delete(int id)
        {
            var product = _productRepository.GetById(id);
            if(product == null) throw new NotFoundException(nameof(Product), id);
            _productRepository.Delete(product);

        }
    }
}
