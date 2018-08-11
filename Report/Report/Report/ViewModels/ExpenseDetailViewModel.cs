using System;
using System.Collections.Generic;
using System.Text;
using Report.Models;

namespace Report.ViewModels
{
    public class ExpenseDetailViewModel : BaseViewModel
    {
        public Expense Expense { get; set; }
        public ExpenseDetailViewModel(Expense expense = null)
        {
            Title = expense?.Particular;
            Expense = expense;
        }
    }
}
