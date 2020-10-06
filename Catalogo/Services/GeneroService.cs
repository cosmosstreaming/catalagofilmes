using System.Linq;
using MongoDB.Driver;
using Catalogo.Models;
using Catalogo.DatabaseSettings;
using System.Collections.Generic;

namespace Catalogo.Services
{
    public class GeneroService : BaseService<Genero>
    {
        public GeneroService(ICatalogoDataBaseSettings settings) : base(settings) { }

        public List<Genero> Get()
        {
            var Generos = this.Model.Find(genero => true).ToList();
            return Generos;
        }   

        public Genero Insert(Genero Genero)
        {
            this.Model.InsertOne(Genero);
            return Genero;
        }

        public Genero Get(string id) =>
            this.Model.Find<Genero>(Genero => Genero.Id == id).FirstOrDefault();

        public void Remove(string id) =>
            this.Model.DeleteOne(g => g.Id == id);
    }
}
