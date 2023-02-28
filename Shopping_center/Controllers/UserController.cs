using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_center.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using BussinessModel;
using AutoMapper;

namespace Shopping_center.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly ProductDBContext _dbContext;

        private readonly IMapper _mapper;


        public UserController(ProductDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //Get Method//   
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        // get method with id to get user //
        [HttpGet("{id}")]

        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            var users = await _dbContext.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }
            return users;
        }


        // add the User //

        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users Users)
        {
            _dbContext.Users.Add(Users);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = Users.UId }, Users);
        }

        // add the user in data base//
      

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users Users)
        {
            if (id != Users.UId)
            {
                return BadRequest();
            }

            _dbContext.Entry(Users).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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
        public async Task<ActionResult<Products>> DeleteUsers(int id)
        {
            var Users = await _dbContext.Products.FindAsync(id);
            if (Users == null)
            {
                return NotFound();
            }

            _dbContext.Products.Remove(Users);
            await _dbContext.SaveChangesAsync();

            return Users;
        }

        private bool UsersExists(int id)
        {
            return _dbContext.Users.Any(e => e.UId == id);
        }



        //PurchaseProduct Controller//

        [HttpPost("Purchase")]
        public async Task<ActionResult<PurchaseProduct>> PurchaseProductByUserMapping(int a, int b)  // Adding  User Purchase Product throug mapping //
        {
            var mapped = new PurchaseProduct
            {
                UId = a,
                PId = b
            };


            _dbContext.PurchaseProducts.Add(mapped);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetUsers", mapped); 
        }



        // Getting User Purchase Product throug mapping //
        [HttpGet("Purchase")]

        public async Task<ActionResult<IEnumerable<PurchaseProduct>>> GetUsersProds()
        {
            return await _dbContext.PurchaseProducts.ToListAsync();
        }



        [HttpGet]
        [Route("Purchase/{userId}")]
      

        public async Task<ActionResult<List<PurchaseProduct>>> GetProdctDetails(int userId)
        {
            var PurchaseProduct = await _dbContext.PurchaseProducts.Where(x => x.UId == userId).ToListAsync();
            var User = await _dbContext.Users.FirstOrDefaultAsync(u => u.UId == userId);
            var product = await _dbContext.Products.ToListAsync();
            //var prod = product.Select(x => PurchaseProduct.Select(a => a.PId).Contains(x.PId)).ToList();
           var allobjectives = await _dbContext.PurchaseProducts.Where(a => a.UId == userId).Include(x => x.Users).Include(x => x.Products).AsNoTracking().ToListAsync();
           
            
            return Ok(allobjectives);
           
        }

        // Edit The mapping table //

        [HttpPut("Purchase/{id}")]
        public async Task<IActionResult> PutpurchaseUsers(int id, PurchaseProduct purchaseProduct)
        {
            if (id != purchaseProduct.PurchaseID)
            {
                return BadRequest();
            }

            _dbContext.Entry(purchaseProduct).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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
        [HttpDelete("Purchase/{id}")]
        public async Task<ActionResult<PurchaseProduct>> DeletePurchaseProduct(int id)
        {
            var PurchaseProduct = await _dbContext.PurchaseProducts.FindAsync(id);
            if (PurchaseProduct == null)
            {
                return NotFound();
            }

            _dbContext.PurchaseProducts.Remove(PurchaseProduct);
            await _dbContext.SaveChangesAsync();

            return PurchaseProduct;
        }

        private bool PurchaseExists(int id)
        {
            return _dbContext.PurchaseProducts.Any(e => e.PurchaseID == id);
        }
    }
}
