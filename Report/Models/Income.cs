using System;

namespace Report.Models
{
    public class Income
    {
        public string IncomeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string DonarName { get; set; }
        public string Amount { get; set; }
    }
}
