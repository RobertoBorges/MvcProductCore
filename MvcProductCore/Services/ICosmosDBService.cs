using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcProductCore.Models;

namespace MvcProductCore.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Feedback>> GetItemsAsync(string query);
        Task<Feedback> GetItemAsync(string id);
        Task AddItemAsync(Feedback feedback);
        Task UpdateItemAsync(string id, Feedback feedback);
        Task DeleteItemAsync(string id);
    }
}