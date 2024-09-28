using eTicket.Data.Base;
using eTicket.Models;

namespace eTicket.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        private readonly AppDbContext appDbContext;
        public ProducersService(AppDbContext context)
            : base(context)
        {
            appDbContext = context;
        }

    }
}
