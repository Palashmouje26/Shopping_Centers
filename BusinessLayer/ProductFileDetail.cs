using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BussinessModel
{
    public class ProductFileDetail
    {

        [Required]
        [RegularExpression("^[a-zA-Z]*$")]
        [Display(Name = "Product Name")]
        [Column(TypeName = "Nvarchar(100)")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter profile image")]
        [Display(Name = "Product Details")]
        public string ProductDetails { get; set; }
        [Required]
        //[RegularExpression(" ^(\\d+)?$")]
        public double Price { get; set; }
        [Required]
        public IFormFile ProductImage { get; set; }
    }
}
