using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalogo.Models
{
    public class Genero
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string Descricao { get; set; }
    }
}
