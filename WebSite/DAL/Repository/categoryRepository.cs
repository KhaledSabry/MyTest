using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks; 
using System.Linq;
using WebSite.DAL.Models;


namespace WebSite.DAL.Repository
{
    public class categoryRepository
    {
        private DBContext _context;
        public categoryRepository(DBContext context)
        {
            _context = context;
        }
        public async Task<List<category>> getcategories()
        {
            List<category> result = new List<category>();
            result = await _context.categories.ToListAsync();
            return result;
        }
        public async Task<category> Addcategory(category category)
        {
            try
            {
                _context.categories.Add(category);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return category;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<category> Updatecategory(category category)
        {
            try
            {
                _context.categories.Update(category);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return category;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
