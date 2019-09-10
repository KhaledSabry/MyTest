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
    public class categoriesController : ControllerBase
    {
        private categoryRepository repository;
        private Settings _setting;
        private DBContext _context;
        public categoriesController(IOptions<Settings> Setting, DBContext context)
        {
            _setting = Setting.Value;
            _context = context;
        }

        // GET api/categories/all/
        /// <summary>
        /// select all categories.
        /// </summary> 
        [HttpGet("all/")]
        public async Task<ActionResult<IEnumerable<category>>> Get()
        {
            repository = new categoryRepository(_context);
            var result = await repository.getcategories ();
            return Ok(result);
        }

        // GET api/categories/add/ 
        /// <summary>
        /// Add a specific category.
        /// </summary>
        /// <param name="value"></param> 
        [HttpPost("add/")]
        public async Task<ActionResult<category>> add([FromBody] category value)
        {
            repository = new categoryRepository(_context);
            var result = await repository.Addcategory(value);
            return Ok(result);
        }

        // GET api/categories/update/ 
        /// <summary>
        /// Update a specific category.
        /// </summary>
        /// <param name="value"></param> 
        [HttpPost("update/")]
        public async Task<ActionResult<category>> update([FromBody] category value)
        {
            repository = new categoryRepository(_context);
            var result = await repository.Updatecategory(value);
            return Ok(result);
        }
    }
}