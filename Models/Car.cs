using System;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Cars.Models
{
	public class Car
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Brand")]
        [JsonPropertyName("Brand")]
        public string Brand { get; set; } = null!;

        [BsonElement("Model")]
        [JsonPropertyName("Model")]
        public string Model { get; set; } = null!;

        [BsonElement("Year")]
        [JsonPropertyName("Year")]
        public int Year { get; set; } = 0!;

        [BsonElement("Colour")]
        [JsonPropertyName("Colour")]
        public string Colour { get; set; } = null!;

        [BsonElement("Doors")]
        [JsonPropertyName("Doors")]
        public int Doors { get; set; } = 0!;

    }
}

