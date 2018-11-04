using DeanPortfolio.Server.Core;
using DeanPortfolio.Server.Core.Abstract;

namespace DeanPortfolio.Server.Routing.Abstract
{
    public interface IRequestRouter
    {
        IRoute GetRoute(string ctrlName, string httpMethod, out string actionName);
    }
}