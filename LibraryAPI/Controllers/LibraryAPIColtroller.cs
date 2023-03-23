using LibraryAPI.Models;
using LibraryAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/LibraryAPI")]
    [ApiController]
    public class LibraryAPIColtroller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<LibraryDTO> GetLibraries()
        {
            return new List<LibraryDTO>
            {
                new LibraryDTO{Id=1,Name="Czerwień Rubinu"},
                new LibraryDTO{Id=2,Name="Cień wiatru"}
            };
        }
    }
}
