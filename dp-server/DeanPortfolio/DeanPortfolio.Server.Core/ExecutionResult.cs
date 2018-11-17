namespace DeanPortfolio.Server.Core
{
    public class ExecutionResult
    {
        public bool Succeed { get; private set; }
        public string ResultMessage { get; set; }

        public ExecutionResult(bool succeed, string resMsg)
        {
            Succeed = succeed;
            ResultMessage = resMsg;
        }
    }
}