using Octoller.OrderLineHandler.ServiceObjects;
using System;

namespace Octoller.OrderLineTestApp {
    public sealed class ChContext : IChContext {

        private string error;
        private string message;

        public bool Complite {
            get; set;
        }

        public bool IsError {
            get; set;
        }
        public Action Action {
            get; set;
        }
        public bool IsMessage {
            get; set;
        }

        public string GetError() {
            return error;
        }

        public void SetError(string description, bool isError = true) {
            error = description;
            IsError = isError;
        }

        public void Clear() {
            error = default;
            Complite = false;
            IsError = false;
            Action = null;
        }

        public void SetMessage(string description, bool isMessage = true) {
            message = description;
        }

        public string GetMessage() {
            return message;
        }
    }
}
