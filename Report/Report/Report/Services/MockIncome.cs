using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Report.Models;

[assembly: Xamarin.Forms.Dependency(typeof(Report.Services.MockIncome))]
namespace Report.Services
{
    public class MockIncome : IDataStore<Income>
    {
        List<Income> items;

        public MockIncome()
        {
            items = new List<Income>();
            var mockItems = new List<Income>
            {
                new Income { IncomeId = "1", TransactionDate = DateTime.Now, DonarName="inc1", Amount = "1111" },

            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Income item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Income arg) => arg.IncomeId == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Income> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.IncomeId == id));
        }

        public async Task<IEnumerable<Income>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> UpdateItemAsync(Income item)
        {
            var _item = items.Where((Income arg) => arg.IncomeId == item.IncomeId).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }
    }
}

