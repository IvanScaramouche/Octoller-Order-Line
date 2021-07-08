using Octoller.OrderLineHandler.ServiceObjects;
using System;

namespace Octoller.OrderLineTestApp
{
    public sealed class ChContext : IChContext
    {
        #region Private Fields

        private string _error;
        private string _message;

        #endregion Private Fields

        #region Public Properties

        public Action Action { get; set; }

        public bool Complite { get; set; }

        public bool IsError { get; set; }

        public bool IsMessage { get; set; }

        #endregion Public Properties

        #region Public Methods

        public string GetError()
        {
            return _error;
        }

        public string GetMessage()
        {
            return _message;
        }

        public void SetError(string description, bool isError = true)
        {
            _error = description;
            IsError = isError;
        }

        public void SetMessage(string description, bool isMessage = true)
        {
            _message = description;
            IsMessage = isMessage;
        }

        #endregion Public Methods
    }
}