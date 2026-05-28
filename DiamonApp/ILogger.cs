using System;

namespace DiamonApp.Interfaces
{
    public interface ILogger
    {
        void UserAction(string userLogin, string action);
        void OpenLogFolder();
    }
}