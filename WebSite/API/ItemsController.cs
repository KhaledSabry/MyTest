using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebSite.Classes;
using WebSite.DAL;
using WebSite.DAL.Models;
using WebSite.DAL.Repository;

namespace WebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private ItemsRepository repository;
        private Settings _setting;
        private DBContext _context;
        public ItemsController(IOptions<Settings> Setting, DBContext context)
        {
            _setting = Setting.Value;
            _context = context;
        }

        // GET api/items/all/
        /// <summary>
        /// select all Items.
        /// </summary> 
        [HttpGet("all/")]
        public async Task<ActionResult<IEnumerable<item>>> Get()
        {
            repository = new ItemsRepository(_context);
            var result = await repository.getItems(null);
            return Ok(result);
        }

        // GET api/items/category/Clothing
        /// <summary>
        /// select Items of a specific category.
        /// </summary>
        /// <param name="category"></param> 
        [HttpGet("category/{category}")]
        public async Task<ActionResult<IEnumerable<item>>> Get(string category)
        {
            repository = new ItemsRepository(_context);
            var result = await repository.getItems(category);
            return Ok(result);
        }


        // GET api/items/add/ 
        /// <summary>
        /// Add a specific Item.
        /// </summary>
        /// <param name="value"></param> 
        [HttpPost("add/")]
        public async Task<ActionResult<item>> add([FromBody] item value)
        {
            repository = new ItemsRepository(_context);
            var result = await repository.AddItem(value);
            return Ok(result);
        }

        // GET api/items/update/ 
        /// <summary>
        /// Update a specific Item.
        /// </summary>
        /// <param name="value"></param> 
        [HttpPost("update/")]
        public async Task<ActionResult<item>> update([FromBody] item value)
        {
            repository = new ItemsRepository(_context);
            var result = await repository.UpdateItem(value);
            return Ok(result);
        }
        // DELETE api/items/delete/5
        /// <summary>
        /// Deletes a specific Item.
        /// </summary>
        /// <param name="id"></param>  
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            repository = new ItemsRepository(_context);
            var result = await repository.DeleteItem(id);

            return Ok(result);
        }
    }
}