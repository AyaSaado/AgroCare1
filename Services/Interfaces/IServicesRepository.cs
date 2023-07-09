using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroCare1.Services.Interface 
{
    public interface IServicesRepository<T>
{
    Task<T> GetOneAsync(int id);
    IQueryable<T> GetAll();
    Task<bool> Add(T entity);
    Task<bool> Edit(T entity);
    Task<bool> RemoveAsync(T entity);
    Task<bool> DoesExist(int id);



}
}