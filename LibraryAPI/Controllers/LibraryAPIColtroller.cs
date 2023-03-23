using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/LibraryAPI")]
    [ApiController]
    public class LibraryAPIColtroller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Library> GetLibraries()
        {
            return new List<Library>
            {
                new Library{Id=1,Name="Czerwień Rubinu"},
                new Library{Id=2,Name="Cień wiatru"}
            };
        }
    }
}
