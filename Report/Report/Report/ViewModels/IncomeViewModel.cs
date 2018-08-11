using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Report.Models;
using Report.Views;

namespace Report.ViewModels
{
    public class IncomeViewModel : BaseViewModel
    {
        public ObservableCollection<Income> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public IncomeViewModel()
        {
            Title = "Income";
            Items = new ObservableCollection<Income>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewIncomePage, Income>(this, "AddIncome", async (obj, income) =>
            {
                var _item = income as Income;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}