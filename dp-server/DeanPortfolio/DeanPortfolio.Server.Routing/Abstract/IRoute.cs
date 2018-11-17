using DeanPortfolio.Server.Core;
using DeanPortfolio.Server.Core.Abstract;

namespace DeanPortfolio.Server.Routing.Abstract
{
    public interface IRoute
    {        
        BaseDataToken ValidateRequestQuery(string id, string data = null);
        ExecutionResult ExecuteRequest(BaseDataToken data);
        ExecutionResult GetUserInfo(BaseDataToken data);
    }
}