using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalogo.Models
{
    public class Filme
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string IdGenero { get; set; }
        public string Duracao { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public DateTime DataLancamento { get; set; }
        public string[] Direcao { get; set; }
        public string[] Elenco { get; set; }
        public string Nacionalidade { get; set; }
        public string Capa { get; set; }
        public string UrlStreaming { get; set; }
    }
}
