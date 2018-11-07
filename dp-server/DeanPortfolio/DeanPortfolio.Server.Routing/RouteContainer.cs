using DeanPortfolio.Server.DAL;
using Newtonsoft.Json;

namespace DeanPortfolio.Server.Routing
{
    public class RouteContainer
    {
        public IMailHandler MailHandler { get; private set; }
        public string RouteMessage { get; private set; }

        public RouteContainer(IMailHandler handler, string routeMsg)
        {
            MailHandler = handler;
            RouteMessage = routeMsg;
        }
    }
}