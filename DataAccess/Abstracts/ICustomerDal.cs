using Core.DataAccess;
using Core.Entities;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        
    }
}
