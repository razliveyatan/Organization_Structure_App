using DAL.Types;

namespace DAL.Repositories
{
    public class ManagerRepository
    {
        private readonly Org_Structure_DbContext dbContext;
        public ManagerRepository(Org_Structure_DbContext dbContext)
        {
            this.dbContext = dbContext;
        }   

        public void SaveChange()
        {
            dbContext.SaveChanges();
        }
    }
}
