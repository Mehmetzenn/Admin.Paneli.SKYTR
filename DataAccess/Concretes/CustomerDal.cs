using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.MongoDB;
using Entities.Concretes;

namespace DataAccess.Concretes
{


    public class CustomerDal : MongoEntityRepositoryBase<Customer>, ICustomerDal
    {
        // CustomerDal yapıcısı, MongoDB'ye özel bağlantı bilgilerini alıyor
        public CustomerDal(string connectionString, string databaseName, string collectionName)
            : base(connectionString, databaseName, collectionName)
        {
        }
    }
}