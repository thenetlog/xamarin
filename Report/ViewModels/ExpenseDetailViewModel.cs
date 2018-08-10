using System;
using System.Collections.Generic;
using System.Text;
using Report.Models;

namespace Report.ViewModels
{
    public class ExpenseDetailViewModel : BaseViewModel
    {
        public Expense Item { get; set; }
        public ExpenseDetailViewModel(Expense item = null)
        {
            Title = item?.Id;
            Item = item;
        }
    }
}
