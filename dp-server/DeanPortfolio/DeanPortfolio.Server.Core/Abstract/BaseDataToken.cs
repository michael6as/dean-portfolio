namespace DeanPortfolio.Server.Core.Abstract
{
    public abstract class BaseDataToken
    {
        public string Name { get; set; }
        public string ActionName { get; set; }

        public BaseDataToken(string name, string actionName)
        {
            Name = name;
            ActionName = actionName;
        }

    }
}