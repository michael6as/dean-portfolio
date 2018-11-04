using DeanPortfolio.Server.Core;
using DeanPortfolio.Server.Core.Abstract;
using DeanPortfolio.Server.DAL;
using DeanPortfolio.Server.Routing.Abstract;
using Newtonsoft.Json;

namespace DeanPortfolio.Server.Routing
{
    public class FinanceRoute : IRoute
    {
        private IMailHandler _mailProvider;
        public void InitRoute(RouteContainer container)
        {
            _mailProvider = container.MailHandler;
        }

        public ExecutionResult ExecuteRequest(string action, BaseDataToken data)
        {
            throw new System.NotImplementedException();
        }

        public BaseDataToken ValidateRequestQuery(string action, string data)
        {
            var jsonObj = JsonConvert.DeserializeObject<Fin>(data);
        }
    }
}