using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessModel
{
    public class Users
    {
        [Key]
        public int UId { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string Username { get; set; }
        public string UserName { get; set; }
        [Column(TypeName = "Nvarchar(300)")]
        public string UserAddress { get; set; }

        [Column(TypeName = "Nvarchar(12)")]
        public string PhoneNo { get; set; }

        // public ICollection<User_Products_Mapping> User_Products_Mappings { get; set; }
    }
}
