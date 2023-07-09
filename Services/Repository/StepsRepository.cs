using AgroCare1.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AgroCare1.Services.Repository  
{

    public class StepsRepository  : ServicesRepository<Step>
    {
        public StepsRepository (AppDbContext context) : base(context){}  

        public override IQueryable<Step> GetAll()
        {
            return base.GetAll().Include(s => s.Action)
                                .Include(s=>s.StepDetails)
                                .ThenInclude(s=>s.AgriculturalItem);
        }

        
    }
}
