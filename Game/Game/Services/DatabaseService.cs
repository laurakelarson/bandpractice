using SQLite;
using System;
using System.Linq;
using System.Threading.Tasks;
using Game.Models;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace Game.Services
{
    /// <summary>
    /// Database Services
    /// Will write to the local data store
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DatabaseService<T> : IDataStore<T> where T : new()
    {
        /// <summary>
        /// Set the class to load on demand
        /// Saves app boot time
        /// </summary>
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        // Lazy connection
        static SQLiteAsyncConnection Database => lazyInitializer.Value;

        // Track if db has been initialized
        static bool initialized = false;


        // Track if db needs to be initialized 
        public bool NeedsInitialization = true;

        // Semaphore to track transactions
        private readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(initialCount: 1);


        /// <summary>
        /// Constructor
        /// All the database to start up
        /// </summary>
        public DatabaseService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        /// <summary>
        /// Create the Table if it does not exist
        /// </summary>
        /// <returns></returns>
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(T).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(T)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        /// <summary>
        /// Check NeedsInitialization flag. First time toggled, returns true.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> GetNeedsInitializationAsync()
        {
            if (NeedsInitialization == true)
            {
                // Toggle State
                NeedsInitialization = false;
                return await Task.FromResult(true);
            }

            return await Task.FromResult(NeedsInitialization);
        }

        /// <summary>
        /// Wipe Data List
        /// Drop the tables and create new ones
        /// </summary>
        public async Task<bool> WipeDataListAsync()
        {
            await semaphoreSlim.WaitAsync();
            try
            {
                NeedsInitialization = true;

                await Database.DropTableAsync<T>();
                await Database.CreateTablesAsync(CreateFlags.None, typeof(T));
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error WipeData" + e.Message);
            }
            finally
            {
                semaphoreSlim.Release();
            }

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Create a new record for the data passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(T data)
        {
            try
            {
                var result = await Database.InsertAsync(data);
                return (result == 1);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Create Failed " + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Return the record for the ID passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> ReadAsync(string id)
        {
            T data;

            try
            {
                var dataList = await IndexAsync();

                data = dataList.Where((T arg) => ((BaseModel<T>)(object)arg).Id.Equals(id)).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Read Failed " + e.Message);
                data = default(T);
            }

            return data;
        }

        /// <summary>
        /// Update the record passed in if it exists
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(T data)
        {
            var myRead = await ReadAsync(((BaseModel<T>)(object)data).Id);
            if (myRead == null)
            {
                return false;
            }


            int result = 0;
            try
            {
                result = await Database.UpdateAsync(data);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Create Failed " + e.Message);
                return (result == 0);
            }

            return (result == 1);
        }

        /// <summary>
        /// Delete the record of the ID passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(string id)
        {
            var data = await ReadAsync(id);
            if (data == null)
            {
                return false;
            }

            int result;
            try
            {
                result = await Database.DeleteAsync(data);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Delete Failed " + e.Message);
                return false;
            }

            return (result == 1);
        }

        /// <summary>
        /// Return all records in the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> IndexAsync()
        {
            return await Database.Table<T>().ToListAsync();
        }
    }
}