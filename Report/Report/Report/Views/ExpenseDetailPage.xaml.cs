using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Report.Models;
using Report.ViewModels;

namespace Report.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseDetailPage : ContentPage
    {
        ExpenseDetailViewModel viewModel;

        public ExpenseDetailPage(ExpenseDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ExpenseDetailPage()
        {
            InitializeComponent();

            var expense = new Expense
            {
                ExpenseId = string.Empty,
                Particular = string.Empty,
                Amount = string.Empty
            };

            viewModel = new ExpenseDetailViewModel(expense);
            BindingContext = viewModel;
        }
    }
}