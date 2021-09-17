using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VASPChan.Models;
using VASPChan.Interfaces;

namespace VASPChan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadsController : ControllerBase
    {
        private readonly IThreadRepository repository;

        public ThreadsController(IThreadRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{board}", Name = nameof(GetAllThreads))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Thread>))]
        public IActionResult GetAllThreads(string board)
        {
            return Ok(repository.GetAll(board));
        }

        [HttpGet("thread/{ID}", Name = nameof(GetThread))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Thread))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetThread(int ID)
        {
            var thread = repository.Get(ID);

            if (thread == null)
            {
                return NotFound();
            }

            return Ok(thread);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Thread))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Thread thread)
        {
            var threadDTO = await repository.Create(thread);
            return CreatedAtAction(nameof(GetThread), new { ID = thread.ThreadID }, threadDTO);
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
