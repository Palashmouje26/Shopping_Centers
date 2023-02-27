using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessModel
{
    public class Products
    {
        [Key]
        public int PId { get; set; }


        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "Product Name")]
        [Column(TypeName = "Nvarchar(100)")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter product details")]
        [Display(Name = "Product Details")]
        [Column(TypeName = "Nvarchar(300)")]
        public string ProductDetails { get; set; }

        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Product Picture")]
        public string ProductImage { get; set; }

        [Required(ErrorMessage = "Please Add Some Value")]
        public double Price { get; set; }

        //public ICollection<User_Products_Mapping> User_Products_Mappings { get; set; }

    }
}
