namespace DeanPortfolio.Server.DAL
{
    public interface IMailHandler
    {
        void InitMailSettings();
        void SendMail(string message, string data);
    }
}