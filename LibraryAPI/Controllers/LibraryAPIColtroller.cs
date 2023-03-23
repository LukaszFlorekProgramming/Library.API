using LibraryAPI.Data;
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
            return LibraryStore.librarylist;
            
        }
    }
}
