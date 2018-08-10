using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Report.Models;

namespace Report.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewExpensePage : ContentPage
	{
        public Expense Expense { get; set; }

        public NewExpensePage()
        {
            InitializeComponent();

            Expense = new Expense
            {
                Id = "",
                TransactionDate = DateTime.Now,
                Particular = "",
                Amount = ""
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Expense);
            await Navigation.PopModalAsync();
        }
    }
}