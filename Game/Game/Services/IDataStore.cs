using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Services
{
    /// <summary>
    /// Interface for data intreactions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataStore<T>
    {
        // Create method
        Task<bool> CreateAsync(T Data);

        // Read method
        Task<T> ReadAsync(string id);

        // Update method
        Task<bool> UpdateAsync(T Data);
        
        // Delete method
        Task<bool> DeleteAsync(string id);
        
        // Index method
        Task<List<T>> IndexAsync();

        // Wipe data list method 
        Task<bool> WipeDataListAsync();
    }
}