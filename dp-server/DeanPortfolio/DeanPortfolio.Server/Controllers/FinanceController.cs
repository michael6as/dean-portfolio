using DeanPortfolio.Server.Core;
using DeanPortfolio.Server.Routing.Abstract;
using Microsoft.AspNetCore.Mvc;

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
            _ctrlName = "finance";
        }

        [HttpGet("{name}")]
        public ActionResult<ExecutionResult> Get(string name)
        {
            var route = _router.GetRoute(_ctrlName);
            var dataToken = route.ValidateRequestQuery(name);
            var execRes = route.GetUserInfo(dataToken);
            // Return current account balance
            return execRes;
        }

        [HttpPost("{name}")]
        public ActionResult<ExecutionResult> Post(string name, [FromBody] string jsonData)
        {
            var route = _router.GetRoute(_ctrlName);
            var dataToken = route.ValidateRequestQuery(name, jsonData);
            var execRes = route.ExecuteRequest(dataToken);
            return execRes;
        }
    }
}