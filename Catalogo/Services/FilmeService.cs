using System.Linq;
using MongoDB.Driver;
using Catalogo.Models;
using Catalogo.DatabaseSettings;
using System.Collections.Generic;

namespace Catalogo.Services
{
    public class FilmeService : BaseService<Filme>
    {
        public FilmeService(ICatalogoDataBaseSettings settings) : base(settings) { }

        public List<Filme> Get() =>
            this.Model.Find(filme => true).ToList();

        public List<Filme> GetByGenero(string idGenero) =>
            this.Model.Find(filme => filme.IdGenero == idGenero).ToList();

        public Filme Insert(Filme Filme)
        {
            this.Model.InsertOne(Filme);
            return Filme;
        }
    }
}
