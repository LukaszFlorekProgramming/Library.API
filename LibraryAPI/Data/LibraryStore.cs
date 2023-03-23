using LibraryAPI.Models.Dto;

namespace LibraryAPI.Data
{
    public static class LibraryStore
    {
        public static List<LibraryDTO> librarylist = new List<LibraryDTO>
        {
            new LibraryDTO{Id=1,Name="Czerwień Rubinu"},
            new LibraryDTO{Id=2,Name="Cień wiatru"}
        };
    }
}
