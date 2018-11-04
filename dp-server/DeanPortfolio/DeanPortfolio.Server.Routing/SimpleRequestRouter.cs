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
        public SimpleRequestRouter(IList<RouteConfig> routes)
        {
            _routeConfigs = routes;
            _initRoutes = new Dictionary<string, IRoute>();
        }

        public IRoute GetRoute(string ctrlName, string httpMethod, out string actionName)
        {
            var conrollerConfig = _routeConfigs.FirstOrDefault(route => route.ControllerName == ctrlName);
            if (conrollerConfig != null)
            {
                actionName = conrollerConfig.MethodActionDict[httpMethod];
                if (!_initRoutes.ContainsKey(actionName))
                {
                    FindRouteInstance(ctrlName, actionName);
                }

                return _initRoutes[actionName];
            }
            throw new ArgumentException();
        }

        private void FindRouteInstance(string ctrlName, string actionName)
        {
            foreach (var type in GetType().Assembly.GetTypes())
            {
                if (type.Name.Contains(ctrlName))
                {
                    var routeInstance = (IRoute)Activator.CreateInstance(type);
                    routeInstance.InitRoute("M");
                    _initRoutes.Add(actionName, routeInstance);
                }
            }
        }
    }
}
