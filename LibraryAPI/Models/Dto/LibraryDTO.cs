using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Dto
{
    public class LibraryDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
