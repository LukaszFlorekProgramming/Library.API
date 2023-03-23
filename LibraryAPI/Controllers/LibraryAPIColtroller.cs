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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<LibraryDTO>> GetLibraries()
        {
            return Ok(LibraryStore.librarylist);
            
        }

        [HttpGet("id:int",Name = "GetLibrary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LibraryDTO> GetLibrary(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var library = LibraryStore.librarylist.FirstOrDefault(x => x.Id == id);
            if(library == null)
            {
                return NotFound();
            }

            return Ok(library);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LibraryDTO> CreateLibrary([FromBody]LibraryDTO libraryDTO)
        { 
            if(libraryDTO == null)
            {
                return BadRequest(libraryDTO);
            }
            if(libraryDTO.Id > 0) 
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            libraryDTO.Id = LibraryStore.librarylist.OrderByDescending(x => x.Id).FirstOrDefault().Id+1;
            LibraryStore.librarylist.Add(libraryDTO);

            return CreatedAtRoute("GetLibrary",new {id = libraryDTO.Id}, libraryDTO);
        }
    }
}
