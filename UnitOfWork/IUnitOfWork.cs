using System;
using DAL.Models;
using DAL.Repositories;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Dormitory> DormitoryRepository { get; }
        IRepository<Group> GroupRepository { get; }
        IStudentRepository StudentRepository { get; }

        void SaveChanges();
    }
}