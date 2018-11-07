using DeanPortfolio.Server.Core;
using DeanPortfolio.Server.Core.Abstract;

namespace DeanPortfolio.Server.Routing.Abstract
{
    public interface IRoute
    {
        void InitRoute(RouteContainer container);
        BaseDataToken ValidateRequestQuery(string action, string data, string id);
        ExecutionResult ExecuteRequest(string action, BaseDataToken data);
    }
}