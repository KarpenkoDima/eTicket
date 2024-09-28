using eTicket.Data.Base;
using eTicket.Models;

namespace eTicket.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        private readonly AppDbContext appDbContext;
        public CinemasService(AppDbContext context)
            :base(context)
        {
            appDbContext = context;
        }
    }
}
