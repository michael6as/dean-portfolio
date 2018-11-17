using System.Collections.Generic;

namespace DeanPortfolio.Server.DAL
{
    public class MailDb
    {
        public Dictionary<string, string> UserMailRecipients { get; set; }

        public MailDb()
        {
            UserMailRecipients = new Dictionary<string, string>()
            {
                {"Dean", "michael95.as@gmail.com" },
                {"Michael", "miki120a@gmail.com" },
                {"Kobi", "Nothing@none.com" }
            };
        }
    }
}