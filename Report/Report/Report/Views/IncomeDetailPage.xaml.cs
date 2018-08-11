using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Report.Models;
using Report.ViewModels;

namespace Report.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncomeDetailPage : ContentPage
    {
        IncomeDetailViewModel viewModel;

        public IncomeDetailPage(IncomeDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public IncomeDetailPage()
        {
            InitializeComponent();

            var item = new Income
            {
                IncomeId = string.Empty,
                DonarName = string.Empty,
                Amount = string.Empty
            };

            viewModel = new IncomeDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}