using MongoDB.Driver;
using Catalogo.DatabaseSettings;

namespace Catalogo.Services
{
    public class BaseService<TModel> where TModel : class
    {
        protected readonly IMongoCollection<TModel> Model;

        public BaseService(ICatalogoDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this.Model = database.GetCollection<TModel>(typeof(TModel).Name);
        }
    }
}
