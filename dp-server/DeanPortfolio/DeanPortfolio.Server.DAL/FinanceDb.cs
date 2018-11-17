using System.Collections.Generic;

namespace DeanPortfolio.Server.DAL
{
    public class FinanceDb
    {
        public Dictionary<string, int> MoneyList { get; set; }

        public FinanceDb()
        {
            MoneyList = new Dictionary<string, int>()
            {
                {"Dean", 13337},
                {"Kobi", 4200},
                {"Sean", 10},
                {"Michael", 666666},
                {"Sapir", 0 }
            };
        }
    }
}