using System.Collections.Generic;

namespace UnitTestsKata.Services
{
    public interface IKnowHowToSendEmails
    {
        void SendSucceededNotification(IList<string> emails);
        void SendErrorNotification(IList<string> emails);
    }
}