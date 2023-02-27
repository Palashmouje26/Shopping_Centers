using BussinessModel;
using Shopping_center.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping_center.Repository
{
    public interface IProductDataRepository
    {
       

        Task<IEnumerable<Products>> GetProductAsync();
        Task<Products> GetProductById(int id);
        Task<Products> AddProducts(Products products);
        Task<Products> UpdateProducts(int id,Products products);
        void DeleteProducts(int id);
         

    }
}
 