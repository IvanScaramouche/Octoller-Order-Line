using Octoller.OrderLineHandler.ServiceObjects;
using System;

namespace Octoller.OrderLineTestApp {
    public sealed class ChContext : IChContext {

        private string error;

        public bool Complite {
            get; set;
        }

        public bool IsError {
            get; set;
        }
        public Action Action {
            get; set;
        }

        public string GetError() {
            return error;
        }

        public void SetError(string description, bool isError = true) {
            error = description;
            IsError = isError;
        }
    }
}
