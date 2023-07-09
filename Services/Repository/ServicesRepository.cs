
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroCare1.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AgroCare1.Services.Repository
{
    public class  ServicesRepository<T>: IServicesRepository<T> where T : class
    {
        protected AppDbContext _context;

        public ServicesRepository(AppDbContext context)
        {
            _context = context ;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
        public virtual async Task<T?> GetOneAsync(int id)
        {
            if (GetAll() is DbSet<T> all)
                return await all.FindAsync(id);
            else
                return await Task.FromResult<T?>(null);

        }
    
        public virtual async Task<bool> Add(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public virtual async Task<bool> DoesExist(int id)
        {
            return  GetOneAsync(id) != null;
        }

        public virtual async Task<bool> Edit(T entity)
        {
            try
            {
                await _context.UpdateAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public virtual async Task<bool> RemoveAsync(T entity)
        {
            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}