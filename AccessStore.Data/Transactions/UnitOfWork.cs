using AccessStore.Data.Contexts;

namespace AccessStore.Data.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDataContext _context;
        public UnitOfWork(AppDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Nada :)
        }
    }
}
