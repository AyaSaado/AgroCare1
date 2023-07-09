using AgroCare1.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AgroCare1.Services.Repository  
{

    public class BuyerRepository  : ServicesRepository<Buyer> 
    {
        public BuyerRepository (AppDbContext context) : base(context)
        {}  

    }
}
