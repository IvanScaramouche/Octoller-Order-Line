using System;

namespace Octoller.OrderLineHandler.ServiceObjects {
    public interface IChContext {

        bool Complite {
            get; set;
        }

        public bool IsError {
            get; set;
        }

        Action Action {
            get; set;
        }

        void SetError(string description, bool isError = true);
        string GetError();
    }
}
