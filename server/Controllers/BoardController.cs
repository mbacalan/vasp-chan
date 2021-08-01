using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VASPChan.Models;
using VASPChan.Services;
using VASPChan.Interfaces;

namespace VASPChan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardsController : ControllerBase
    {
        private readonly IBoardRepository repository;

        public BoardsController(IBoardRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Board>))]
        public IActionResult GetAllBoards()
        {
            return Ok(repository.GetAll());
        }

        [HttpGet("{ID}", Name = nameof(GetBoard))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Board))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBoard(int ID)
        {
            var board = await repository.Get(ID);

            if (board == null)
            {
                return NotFound();
            }

            return Ok(board);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Board))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Board board)
        {
            var boardDTO = await repository.Create(board);
            return CreatedAtAction(nameof(GetBoard), new { ID = board.BoardID }, boardDTO);
        }

        [HttpDelete("{ID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int ID)
        {
            try
            {
                repository.Delete(ID);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
