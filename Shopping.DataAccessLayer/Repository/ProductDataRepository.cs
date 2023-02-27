using BussinessModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_center.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_center.Repository
{
    public class ProductDataRepository : IProductDataRepository
    {
        private readonly ProductDBContext _dbContext;

        public ProductDataRepository(ProductDBContext dbContext)
        {
            _dbContext = dbContext;

        }

        public Task<Products> AddProducts(Products products)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteProducts(int Id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Products>> GetProductAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public Task<IEnumerable<Products>> GetProduct()
        {
            throw new System.NotImplementedException();
        }

        public Task<Products> GetProductById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Products> GetProducts(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Products> UpdateProducts(Products products)
        {
            throw new System.NotImplementedException();
        }

        public Task<Products> UpdateProducts(int id, Products products)
        {
            throw new System.NotImplementedException();
        }

        //public async Task<Products> AddProducts(Products products)
        //{
        //    var result =await _dbContext.Products.AddAsync(products);
        //    await _dbContext.SaveChangesAsync();
        //    return result.Entity;
        //}

        //public async void DeleteProducts(int Id)
        //{
        //    var result = await _dbContext.Products.Where(a => a.PId == Id).FirstOrDefaultAsync();
        //    if ( result != null) 
        //    {
        //        _dbContext.Products.Remove(result);
        //        await _dbContext.SaveChangesAsync();
        //    }


        //}

        //public async Task<IEnumerable<Products>> GetPRoduct()
        //{
        //    return await _dbContext.Products.ToListAsync();
        //}

        //public async Task<Products> GetProducts(int Id)
        //{
        //    return await _dbContext.Products.FirstOrDefaultAsync(a => a.PId == Id);
        //}

        //public async Task<Products> UpdateProducts(Products products)
        //{
        //    var result = await _dbContext.Products.FirstOrDefaultAsync(a => a.PId == products.PId);
        //    if ( result != null) 
        //    {
        //        result.ProductName = products.ProductName;
        //        result.ProductDetails = products.ProductDetails;
        //        result.Price = products.Price;
        //        return result;
        //    }
        //    return null;
        //}
    }
}
