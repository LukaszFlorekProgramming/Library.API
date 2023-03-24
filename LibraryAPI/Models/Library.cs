namespace LibraryAPI.Models
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string AuthorName { get; set; }
        public int yearOfPublication { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }



    }
}
