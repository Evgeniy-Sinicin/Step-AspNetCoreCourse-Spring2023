using System.ComponentModel.DataAnnotations;

namespace Shop.BusinessLogic.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Category Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }
    }
}
