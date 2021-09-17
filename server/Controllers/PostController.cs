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
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository repository;

        public PostsController(IPostRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{ID}", Name = nameof(GetAllPosts))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Post>))]
        public IActionResult GetAllPosts(int ID)
        {
            return Ok(repository.GetAll(ID));
        }

        [HttpGet("post/{ID}", Name = nameof(GetPost))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Post))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPost(int ID)
        {
            var post = repository.Get(ID);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Post post)
        {
            var postDTO = await repository.Create(post);
            return CreatedAtAction(nameof(GetPost), new { ID = post.ThreadID }, postDTO);
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
