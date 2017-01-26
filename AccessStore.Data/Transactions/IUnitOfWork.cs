namespace AccessStore.Data.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
