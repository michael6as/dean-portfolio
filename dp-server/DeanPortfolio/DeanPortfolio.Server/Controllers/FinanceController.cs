using DeanPortfolio.Server.Routing.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DeanPortfolio.Server.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace DeanPortfolio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ControllerBase
    {        
        private IRequestRouter _router;
        private string _ctrlName;

        public FinanceController(IRequestRouter router)
        {
            _router = router;
            _ctrlName = "Finance";
        }

        [HttpGet("{name}")]
        public ActionResult<ExecutionResult> Get(string name, [FromBody]string jsonData)
        {
            string actionName;
            var route = _router.GetRoute(_ctrlName, Request.Method, out actionName);
            var dataToken = route.ValidateRequestQuery(actionName, jsonData);
            var execRes = route.ExecuteRequest(actionName, dataToken);            
            // Return current account balance
            return execRes;
        }
        
        [HttpPost("{name}")]
        public ActionResult<ExecutionResult> Post(string name, [FromBody] string jsonData)
        {
            string actionName;
            var route = _router.GetRoute(_ctrlName, Request.Method, out actionName);
            var dataToken = route.ValidateRequestQuery(actionName, jsonData);
            var execRes = route.ExecuteRequest(actionName, dataToken);
            return execRes;
        }
    }
}