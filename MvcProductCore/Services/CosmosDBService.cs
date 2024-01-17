using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcProductCore.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;

namespace MvcProductCore.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(Feedback feedback)
        {
            await this._container.CreateItemAsync<Feedback>(feedback, new PartitionKey(feedback.id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<Feedback>(id, new PartitionKey(id));
        }

        public async Task<Feedback> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<Feedback> response = await this._container.ReadItemAsync<Feedback>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<IEnumerable<Feedback>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Feedback>(new QueryDefinition(queryString));
            List<Feedback> results = new List<Feedback>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, Feedback feedback)
        {
            await this._container.UpsertItemAsync<Feedback>(feedback, new PartitionKey(id));
        }
    }
}