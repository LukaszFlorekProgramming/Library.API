using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Dto
{
    public class LibraryDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public string AuthorName { get; set; }
        public int yearOfPublication { get; set; }
    }
}
