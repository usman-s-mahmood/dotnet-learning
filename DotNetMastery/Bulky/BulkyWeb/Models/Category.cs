using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        public int Id { get; set; } // Primary Key
        [Required]
        [DisplayName("Category Name")]
        public string? Name { get; set; } // Category Name

        [DisplayName("Display Order")] // for frontend with use of asp-for
        public int DisplayOrder { get; set; } // Display Order for sorting
    }
}
















//using System.ComponentModel.DataAnnotations;

//namespace BulkyWeb.Models
//{
//    public class Category
//    {
//        // [Key] // Data anotation for use if the name of primary key is not Id below
//        public int Id { get; set; }
//        [Required] // Required data anotation for !NULL field below
//        public string? Name { get; set; }
//        public int DisplayOrder { get; set; }
//    }
//}
