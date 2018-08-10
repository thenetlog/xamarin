using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Report.Models;


[assembly: Xamarin.Forms.Dependency(typeof(Report.Services.MockExpense))]
namespace Report.Services
{
    public class MockExpense : IDataStores<Expense>
    {
        List<Expense> items;

        public MockExpense()
        {
            items = new List<Expense>();
            var mockItems = new List<Expense>
            {
                new Expense { Id = "1", TransactionDate = DateTime.Now, Particular ="exp1", Amount = "1000" },

            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Expense item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Expense arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Expense> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Expense>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> UpdateItemAsync(Expense item)
        {
            var _item = items.Where((Expense arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }
    }
}