using DeanPortfolio.Server.Core.Abstract;

namespace DeanPortfolio.Server.Core
{
    public class FinanceDataToken : BaseDataToken
    {
        public int Amount { get; set; }
        public string Recipient { get; set; }

        public FinanceDataToken(string name, string actionName, int amount, string recipient) : base(name, actionName)
        {
            Amount = amount;
            Recipient = recipient;
        }
    }
}