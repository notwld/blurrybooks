using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlurryBooks.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [DisplayName("Order ID")]
        //[Range(1,100,ErrorMessage="Örder Id must be in range of 1 to 100!")]
        public int OrderID { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
