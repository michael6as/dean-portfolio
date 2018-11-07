using DeanPortfolio.Server.Core;

namespace DeanPortfolio.Server.DAL
{
    public interface IMailHandler
    {
        void SendMail(string message, ExecutionResult data, string toMail);
    }
}