
using Microsoft.EntityFrameworkCore;
using Models;

namespace AgroCare1.Services.Repository  
{

    public class FarmerRepository  : ServicesRepository<Farmer>
    {
        public FarmerRepository (AppDbContext context) : base(context){}  

        public override async Task<bool> RemoveAsync(Farmer farmer)
        {
            try
            {
                _context.RemoveRange(farmer.Lands);
                _context.Remove(farmer);
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
