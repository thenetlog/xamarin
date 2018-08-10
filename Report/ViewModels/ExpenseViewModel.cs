using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Report.Models;
using Report.Views;

namespace Report.ViewModels
{
    public class ExpenseViewModel : BaseViewModel
    {
        public ObservableCollection<Expense> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ExpenseViewModel()
        {
            Title = "Expense";
            Items = new ObservableCollection<Expense>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStores.GetItemsAsync(true);
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