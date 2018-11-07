using DeanPortfolio.Server.Core;
using DeanPortfolio.Server.Core.Abstract;
using DeanPortfolio.Server.Routing.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeanPortfolio.Server.Routing
{
    public class FinanceRoute : IRoute
    {
        private RouteContainer _routeContainer;
        private IDictionary<string, Func<FinanceDataToken, ExecutionResult>> _actionDict;

        public FinanceRoute(RouteContainer container)
        {
            InitRoute(container);
        }
        public void InitRoute(RouteContainer container)
        {
            _routeContainer = container;
        }

        private void InitActions()
        {
            //TODO: Inject actions somehow
            _actionDict = new Dictionary<string, Func<FinanceDataToken, ExecutionResult>>
            {
                ["transfer"] = TransferMoneyToAccount,
                ["balance"] = ShowBalance
            };
        }

        private ExecutionResult TransferMoneyToAccount(FinanceDataToken token)
        {
            return new ExecutionResult();
        }

        private ExecutionResult ShowBalance(FinanceDataToken token)
        {
            return new ExecutionResult();
        }

        public ExecutionResult ExecuteRequest(string action, BaseDataToken data)
        {
            if (data is FinanceDataToken)
            {
                var execResult = _actionDict[action]((FinanceDataToken)data);
                if (execResult.Succeed)
                {
                    Task.Run(() => { _routeContainer.MailHandler.SendMail(_routeContainer.RouteMessage, execResult, data.MailToSend); });
                }

                return execResult;
            }
            else
            {
                throw new ArgumentException("Data is invalid");
            }
        }

        public BaseDataToken ValidateRequestQuery(string action, string data, string id)
        {
            // TODO: Check if identity is valid for this action
            // TODO: Add validations
            var dataToken = JsonConvert.DeserializeObject<FinanceDataToken>(data);
            dataToken.Id = id;
            return dataToken;
        }
    }
}