using DeanPortfolio.Server.Core;
using DeanPortfolio.Server.Routing.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeanPortfolio.Server.Routing
{
    public class SimpleRequestRouter : IRequestRouter
    {        
        private IDictionary<string, IRoute> _initRoutes;

        public SimpleRequestRouter(IDictionary<string, IRoute> existRoutes)
        {                        
            _initRoutes = existRoutes;
        }

        public IRoute GetRoute(string ctrlName)
        {
            return _initRoutes[ctrlName];            
        }  
    }
}
