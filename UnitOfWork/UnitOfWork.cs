
namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private MYdbCodeFirstContext Context { get; }

        private IStudentRepository _studentRepository;
        private IRepository<Group> _groupRepository;
        private IRepository<Dormitory> _dormitoryRepository;

        public UnitOfWork(MYdbCodeFirstContext context)
        {
            Context = context;
        }

        public IStudentRepository StudentRepository
        {
            get
            {

                if (this._studentRepository == null)
                {
                    this._studentRepository = new StudentRepository(Context);
                }
                return _studentRepository;
            }
        }

        public IRepository<Group> GroupRepository
        {
            get
            {

                if (this._groupRepository == null)
                {
                    this._groupRepository = new Repository<Group>(Context);
                }
                return _groupRepository;
            }
        }
        public IRepository<Dormitory> DormitoryRepository
        {
            get
            {

                if (this._dormitoryRepository == null)
                {
                    this._dormitoryRepository = new Repository<Dormitory>(Context);
                }
                return _dormitoryRepository;
            }
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }


        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

