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
        public ObservableCollection<Expense> Expenses { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ExpenseViewModel()
        {
            Title = "Expense";
            Expenses = new ObservableCollection<Expense>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewExpensePage, Expense>(this, "AddExpense", async (obj, expense) =>
            {
                var _etem = expense as Expense;
                Expenses.Add(_etem);
                await DataStores.AddItemAsynce(_etem);
            });

        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Expenses.Clear();
                var etems = await DataStores.GetItemsAsynce(true);
                foreach (var etem in etems)
                {
                    Expenses.Add(etem);
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