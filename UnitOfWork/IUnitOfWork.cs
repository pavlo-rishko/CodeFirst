using System;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Dormitory> DormitoryRepository { get; }
        IRepository<Group> GroupRepository { get; }
        IStudentRepository StudentRepository { get; }

        void SaveChanges();
    }
}