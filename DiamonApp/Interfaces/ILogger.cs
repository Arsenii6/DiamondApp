using System;

namespace DiamondApp.Interfaces
{
    public interface ILogger
    {
        void UserAction(string userLogin, string action);
        void OpenLogFolder();
    }
}