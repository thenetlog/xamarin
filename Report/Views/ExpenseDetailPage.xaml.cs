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

            var item = new Expense
            {
                Id = "",
                Particular = "",
                Amount = ""
            };

            viewModel = new ExpenseDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}