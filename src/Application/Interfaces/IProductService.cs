using Application.Models;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product GetById(int id);

        Product Create(ProductCreateRequest productCreateRequest);

        void Update(ProductUpdateRequest productUpdateRequest, int id);

        void Delete(int id);
    }
}
