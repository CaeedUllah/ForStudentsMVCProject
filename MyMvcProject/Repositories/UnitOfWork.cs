namespace MyMvcProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;            
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
