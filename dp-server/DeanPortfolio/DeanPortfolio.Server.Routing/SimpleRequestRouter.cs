using DeanPortfolio.Server.Core;
using DeanPortfolio.Server.Routing.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeanPortfolio.Server.Routing
{
    public class SimpleRequestRouter : IRequestRouter
    {
        private IList<RouteConfig> _routeConfigs;
        private IDictionary<string, IRoute> _initRoutes;
        public SimpleRequestRouter(IList<RouteConfig> routes, IDictionary<string, IRoute> existRoutes)
        {
            _routeConfigs = routes;
            _initRoutes = new Dictionary<string, IRoute>();
            _initRoutes = existRoutes;
        }

        public IRoute GetRoute(string ctrlName, string httpMethod, out string actionName)
        {
            var conrollerConfig = _routeConfigs.FirstOrDefault(route => route.ControllerName == ctrlName);
            if (conrollerConfig != null)
            {
                actionName = conrollerConfig.MethodActionDict[httpMethod];
                return _initRoutes[actionName];
            }
            throw new ArgumentException();
        }  
    }
}
