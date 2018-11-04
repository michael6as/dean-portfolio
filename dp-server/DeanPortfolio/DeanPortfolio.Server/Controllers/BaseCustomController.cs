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
            string actionName;
            var route = _router.GetRoute(_ctrlName, Request.Method, out actionName);
            var dataToken = route.ValidateRequestQuery(actionName, jsonData);
            var execRes = route.ExecuteRequest(actionName, dataToken);
            // Return current account balance
            return "Blat";
        }

        [HttpPost("{name}")]
        public void Post(string name, [FromBody] string jsonData)
        {
            string actionName;
            var route = _router.GetRoute(_ctrlName, Request.Method, out actionName);
            var dataToken = route.ValidateRequestQuery(actionName, jsonData);
            var execRes = route.ExecuteRequest(actionName, dataToken);
            // Transfer           
        }
    }
}