
using AgroCare1.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AgroCare1.Services.Repository  
{

    public class EngineerRepository  : ServicesRepository<Engineer>
    {
        public EngineerRepository (AppDbContext context) : base(context){}  
    
    
        public override IQueryable<Engineer> GetAll()
        {
            return base.GetAll().Include(e => e.EngineerType);
        }
    
        public  IQueryable<Engineer> GetHeaderEngineers()
        {
            return _context.Set<Engineer>()
            .Where(e =>e.EngineerTypeId==2 && e.HeadEngineerId == null);
        }
        public  IQueryable<Engineer> GetEngineersBytype(int EngineerTypeId)
        {
            return _context.Set<Engineer>()
            .Where(e => e.EngineerTypeId == EngineerTypeId);
        }
        
        public IQueryable<Engineer> GetExcutionEngineer(int headEngineerId)
        {
            return  _context.Set<Engineer>()
                .Where(e => e.HeadEngineerId == headEngineerId);
        }
        public  IQueryable<Order> GetOrdersForExecutiveTeam(int headEngineerId)
        {
            return  _context.Set<Order>()
                .Where(o => o.ExecutiveTeamId == headEngineerId);
        }

        public IQueryable<Order> GetOrdersForAdminEngineers(int AdminId)
        {
            return  _context.Set<Order>().Where(o=>o.AdminEngineerId == AdminId);
        }
        

    }
} 
