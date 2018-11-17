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
        private IDictionary<string, int> _moneyList;

        public FinanceRoute(RouteContainer container, IDictionary<string, int> moneyList)
        {
            _routeContainer = container;
            InitActions();
            _moneyList = moneyList;
        }

        public BaseDataToken ValidateRequestQuery(string id, string data = null)
        {
            if (data == null)
            {
                return new FinanceDataToken(id, "", 0, "");
            }
            var dataToken = JsonConvert.DeserializeObject<FinanceDataToken>(data);

            bool isValid = dataToken.Amount > 0 && !string.IsNullOrWhiteSpace(dataToken.Name) &&
                   _moneyList.ContainsKey(dataToken.Name);
            if (isValid)
            {
                return dataToken;
            }
            throw new NotImplementedException();
        }

        public ExecutionResult ExecuteRequest(BaseDataToken data)
        {
            if (data is FinanceDataToken)
            {
                var execResult = _actionDict[data.ActionName]((FinanceDataToken)data);
                if (execResult.Succeed)
                {
                    Task.Run(() => { _routeContainer.MailHandler.SendMail(_routeContainer.RouteMessage, execResult, data.Name); });
                }

                return execResult;
            }
            else
            {
                throw new ArgumentException("Data is invalid");
            }
        }

        public ExecutionResult GetUserInfo(BaseDataToken data)
        {
            _routeContainer.MailHandler.SendMail(_routeContainer.RouteMessage, new ExecutionResult(true, "Good Good"), data.Name);
            return new ExecutionResult(true, _moneyList[data.Name].ToString());
        }

        private void InitActions()
        {
            //TODO: Inject actions somehow
            _actionDict = new Dictionary<string, Func<FinanceDataToken, ExecutionResult>>
            {
                ["transfer"] = TransferMoneyToAccount,
                ["withdraw"] = TransferMoneyToAccount
            };
        }

        private ExecutionResult TransferMoneyToAccount(FinanceDataToken token)
        {
            _moneyList[token.Name] -= token.Amount;
            if (string.IsNullOrWhiteSpace(token.Recipient))
            {
                return new ExecutionResult(true, $"{token.Amount} was withdrawed from account");
            }
            _moneyList[token.Recipient] += token.Amount;
            return new ExecutionResult(true, CreateResultMessage(true, token));
        }

        private string CreateResultMessage(bool success, FinanceDataToken token)
        {
            if (success)
            {
                return
                    $"The amount of {token.Amount} was tranfferred from {token.Name} to {token.Recipient} On {DateTime.Now}";
            }
            else
            {
                return $"The amount of {token.Amount} failed to be tranfferred from {token.Name}";
            }
        }
    }
}