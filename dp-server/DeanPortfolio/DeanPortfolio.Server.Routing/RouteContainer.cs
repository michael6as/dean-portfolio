using DeanPortfolio.Server.DAL;
using Newtonsoft.Json;

namespace DeanPortfolio.Server.Routing
{
    public class RouteContainer
    {
        public IMailHandler MailHandler { get; set; }

        public RouteContainer(IMailHandler handler)
        {
            MailHandler = handler;            
        }
    }
}