using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    class BLL_Main
    {
        public BLL_Main(IUnitOfWork unitOfWorkParam)
        {
            UnitOfWork = unitOfWorkParam ?? throw new ArgumentNullException(nameof(unitOfWorkParam));
        }
        private IUnitOfWork UnitOfWork { get; }

        private void SaveChanges()
        {
            UnitOfWork.SaveChanges();
        }
    }
}
