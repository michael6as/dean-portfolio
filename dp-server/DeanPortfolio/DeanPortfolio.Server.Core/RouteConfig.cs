using System.Collections.Generic;

namespace DeanPortfolio.Server.Core
{
    public class RouteConfig
    {
        public string ControllerName { get; private set; }
        public IDictionary<string, string> MethodActionDict { get; private set; }

        public RouteConfig(string controller, IDictionary<string, string> actionDict)
        {
            ControllerName = controller;
            MethodActionDict = actionDict;
        }
    }
}