using LibraryAPI.Data;
using LibraryAPI.Models;
using LibraryAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/LibraryAPI")]
    [ApiController]
    public class LibraryAPIColtroller : ControllerBase
    {
        private readonly ILogger<LibraryAPIColtroller> _logger;
        public LibraryAPIColtroller(ILogger<LibraryAPIColtroller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<LibraryDTO>> GetLibraries()
        {
            _logger.LogInformation("Getting all libraries");
            return Ok(LibraryStore.librarylist);
        }

        [HttpGet("{id:int}", Name = "GetLibrary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LibraryDTO> GetLibrary(int id)
        {
            if (id == 0)
            {
                _logger.LogInformation("Get Library Error with Id" + id);
                return BadRequest();
            }
            var library = LibraryStore.librarylist.FirstOrDefault(x => x.Id == id);
            if (library == null)
            {
                return NotFound();
            }

            return Ok(library);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LibraryDTO> CreateLibrary([FromBody] LibraryDTO libraryDTO)
        {
            /*if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/
            if (LibraryStore.librarylist.FirstOrDefault(x => x.Name.ToLower() == libraryDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("CustomError", "Library already Exists!");
                return BadRequest(ModelState);
            }
            if (libraryDTO == null)
            {
                return BadRequest(libraryDTO);
            }
            if (libraryDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            libraryDTO.Id = LibraryStore.librarylist.OrderByDescending(x => x.Id).FirstOrDefault().Id+1;
            LibraryStore.librarylist.Add(libraryDTO);

            return CreatedAtRoute("GetLibrary", new { id = libraryDTO.Id }, libraryDTO);
        }
        [HttpDelete("{id:int}", Name = "DeleteLibrary")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteLibrary(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var library = LibraryStore.librarylist.FirstOrDefault(x => x.Id == id);
            if (library == null)
            {
                return NotFound();
            }
            LibraryStore.librarylist.Remove(library);

            return NoContent();
        }
        [HttpPut("{id:int}", Name = "UpdateLibrary")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public IActionResult UpdateLibrary(int id, [FromBody]LibraryDTO libraryDTO)
        {
            if (libraryDTO == null || id != libraryDTO.Id)
            {
                return BadRequest();
            }
            var library = LibraryStore.librarylist.FirstOrDefault(x => x.Id == id);
            library.Name = libraryDTO.Name;
            library.AuthorName = libraryDTO.AuthorName;
            library.yearOfPublication = libraryDTO.yearOfPublication;

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialLibrary")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialLibrary(int id, JsonPatchDocument<LibraryDTO> patchDTO)
        {
            if(patchDTO == null || id ==0)
            {
                return BadRequest();
            }
            var library = LibraryStore.librarylist.FirstOrDefault(x => x.Id == id);
            if (library == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(library,ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
