using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // ControllerBase is without view support
    public class PagesController : ControllerBase
    {
        private readonly SplashShoppingCartContext context;

        public PagesController(SplashShoppingCartContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Page>>> GetPages()
        {
            return await context.Pages.OrderBy(x => x.Sorting).ToListAsync();
        }

        //GET /api/pages/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Page>> GetPage(int id)
        {
            var page = await context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            else
            {
                return page;
            }
        }

        //PUT /api/pages/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Page>> PutPage(int id, [FromBody]Page page)
        {
            if (id != page.Id)
            {
                return BadRequest();
            }
            else
            {
                context.Entry(page).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return NoContent();
            }
        }


        //POST /api/PostPage/id
        [HttpPost]
        public async Task<ActionResult<Page>> PostPage([FromBody] Page page)
        {
            context.Pages.Add(page);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostPage), page);
        }

        //DELETE /api/PostPage/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Page>> DeletePage(int id)
        {
            var page = await context.Pages.FindAsync(id);
            context.Pages.Remove(page);
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}

