using AgroCare1.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AgroCare1.Services.Repository  
{

    public class StroeRepository  : ServicesRepository<Store>
    {
        public StroeRepository (AppDbContext context) : base(context){}  

        public override IQueryable<Store> GetAll()
        {
            return base.GetAll().Include(s => s.Type);
        }
    

    }
}
