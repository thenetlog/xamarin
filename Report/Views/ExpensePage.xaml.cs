using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Report.Models;
using Report.Views;
using Report.ViewModels;

namespace Report.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensePage : ContentPage
    {
        ExpenseViewModel viewModel;

        public ExpensePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ExpenseViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Expense;
            if (item == null)
                return;

            await Navigation.PushAsync(new ExpenseDetailPage(new ExpenseDetailViewModel(item)));

            // Manually deselect item.
            ExpenseListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}