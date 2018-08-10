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
    public partial class NewIncomePage : ContentPage
    {
        public Income Income { get; set; }

        public NewIncomePage()
        {
            InitializeComponent();

            Income = new Income
            {
                IncomeId = "",
                TransactionDate = DateTime.Now,
                DonarName = "",
                Amount = ""
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Income);
            await Navigation.PopModalAsync();
        }
    }
}