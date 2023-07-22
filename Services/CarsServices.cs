using System;
using Cars.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cars.Services
{
	public class CarsServices
	{
        private readonly IMongoCollection<Car> _carCollection;


        public CarsServices(IOptions<MongoConnection> mongoConnection)
        {
            var mongoClient = new MongoClient(mongoConnection.Value.Connection);
            var mongoDatabase = mongoClient.GetDatabase(mongoConnection.Value.DatabaseName);
            this._carCollection = mongoDatabase.GetCollection<Car>(mongoConnection.Value.CollectionName);
        }

        public async Task<List<Car>> Get()
        {
            return await this._carCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Car?> GetById(string id)
        {
            return await this._carCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Car carModel)
        {
            await this._carCollection.InsertOneAsync(carModel);
        }

        public async Task Patch(string id, Car updateCarModel)
        {
            await this._carCollection.ReplaceOneAsync(x => x.Id == id, updateCarModel);
        }

        public async Task DeleteById(string id)
        {
            await this._carCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}

