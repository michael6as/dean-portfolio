using DeanPortfolio.Server.Routing.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DeanPortfolio.Server.Controllers
{
    public abstract class BaseCustomController : ControllerBase
    {
        protected string _ctrlName;
        protected IRequestRouter _router;

        public BaseCustomController(IRequestRouter router, string ctrlName)
        {
            _router = router;
            _ctrlName = ctrlName;
        }

        [HttpGet("{name}")]
        public virtual ActionResult<string> Get(string name, [FromBody]string jsonData)
        {
            var route = _router.GetRoute(_ctrlName, Request.Method, out string actionName);
            var dataToken = route.ValidateRequestQuery(actionName, jsonData, name);
            var execRes = route.ExecuteRequest(actionName, dataToken);
            // Return current account balance
            return "Blat";
        }

        [HttpPost("{name}")]
        public void Post(string name, [FromBody] string jsonData)
        {
            var route = _router.GetRoute(_ctrlName, Request.Method, out string actionName);
            var dataToken = route.ValidateRequestQuery(actionName, jsonData, name);
            var execRes = route.ExecuteRequest(actionName, dataToken);
            // Transfer           
        }
    }
}