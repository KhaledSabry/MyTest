using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebSite.Classes;
using System.Linq;
using WebSite.DAL.Models;

namespace WebSite.DAL.Repository
{
    public class ItemsRepository
    {
        private DBContext _context;
        public ItemsRepository( DBContext context)
        {
            _context = context;
        }
        public async Task<List<item>> getItems(string category)
        {
            List<item> result = new List<item>();
            if(string.IsNullOrEmpty(category))
                result= await _context.items.Include(a=>a.cat).ToListAsync(); 
            else
                result = await _context.items.Include(a => a.cat).Where(a=>a.cat.name==category).ToListAsync();
            return result;
        }
        public async Task<item> AddItem(item item)
        {
            try
            {
                _context.items.Add( item);
                _context.Entry(item.cat).State = EntityState.Detached;
                var result = await _context.SaveChangesAsync();
                if (result > 0) 
                    return item;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<item> UpdateItem(item item)
        {
            try
            {
                _context.items.Update(item);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return item;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteItem(int ID)
        {
            try
            {
                var item = await _context.items.FindAsync(ID);
                if (item != null)
                {
                    _context.items.Remove(item);
                    var result = await _context.SaveChangesAsync();
                    return result> 0;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
