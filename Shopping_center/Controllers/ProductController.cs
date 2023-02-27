using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis;
using Shopping_center.Repository;
using Shopping_center.Models;
using BussinessModel;

namespace Shopping.DataAccessLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductDBContext _dbContext;

        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly IProductDataRepository _productDataRepository;

        public ProductController(ProductDBContext dbContext, IWebHostEnvironment webHostEnvironment , IProductDataRepository productDataRepository)
        {
            _dbContext = dbContext;
            WebHostEnvironment = webHostEnvironment;
            _productDataRepository = productDataRepository;
        }

        //Get Method//
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            var x=await _productDataRepository.GetProductAsync();
            return Ok(x.ToList());
        }

        // get Method with id //
        [HttpGet("{id}")]

        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return product;
        }


        //Post Method to add product//
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            _dbContext.Products.Add(products);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = products.PId }, products);
        }

         // edit the product with id //
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (id != products.PId)
            {
                return BadRequest();
            }

            _dbContext.Entry(products).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(int id)
        {
            var products = await _dbContext.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _dbContext.Products.Remove(products);
            await _dbContext.SaveChangesAsync();

            return products;
        }

        private bool ProductsExists(int id)
        {
            return _dbContext.Products.Any(e => e.PId == id);
        }


        //Product Image Upload Process //
        [HttpPost("[action]")]
        public async Task<ActionResult<Products>> UploadFiles([FromForm] ProductFileDetail productFileDetail)
        {
            //if (ModelState.IsValid) 

            //{ 
            //    return Ok("Please Check Extension");
            //}
            if (productFileDetail.ProductImage.Length <= 2097152)  // File size checking up to 2 mb  //
            {
                var fileExtenstion = ProductFile(productFileDetail.ProductImage); // file will be checking is extansion formate //
                if (!fileExtenstion)
                {
                    return Ok("The file is too large.");
                }
                var directoryPath = Path.Combine(WebHostEnvironment.ContentRootPath + "\\ProductImages\\");   // receving the image path tho save //
                var productDetail = new Products
                {
                    Price = productFileDetail.Price,
                    ProductDetails = productFileDetail.ProductDetails,
                    ProductImage = productFileDetail.ProductImage.FileName,
                    ProductName = productFileDetail.ProductName,
                };
                _dbContext.Products.Add(productDetail);
                var filePath = Path.Combine(directoryPath, productFileDetail.ProductImage.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    productFileDetail.ProductImage.CopyTo(stream);
                }
                _dbContext.SaveChanges();
                return Ok("Product Save  Successfully");
            }
            return Ok("The file is too large.");
        }

        private bool ProductFile(IFormFile productImage)  // checking the file is jpg ,jpeg and png formate // 
        {
            var supportedtype = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(productImage.FileName);
            if (!supportedtype.Contains(fileExtension))
            {
                return false;
            }
            return true;
        }


        
    }
}