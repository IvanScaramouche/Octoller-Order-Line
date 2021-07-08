using Octoller.OrderLineHandler.ServiceObjects;
using Octoller.OrderLineHandler.Processor;
using System.Collections.Generic;
using System.Linq;

namespace Octoller.OrderLineTestApp
{
    public sealed class OrderMore : IOrderHandler
    {
        #region Private Fields

        private bool _isError = false;
        private int[] _numbers = null;

        #endregion Private Fields

        #region Public Methods

        public bool Invoke(ref IChContext context)
        {
            if (_isError)
            {
                context.Complite = false;
                context.SetError("Invalid argument.");
                return false;
            }
            else
            {
                context.Complite = true;
                int max = _numbers.Max();
                System.Console.WriteLine(max);
                return true;
            }
        }

        public void SetArgument(params string[] arg)
        {
            if (arg != null && arg.Length > 0)
            {
                List<int> temp = new List<int>();
                foreach (var a in arg)
                {
                    if (int.TryParse(a, out int i))
                    {
                        temp.Add(i);
                    }
                    else
                    {
                        _isError = true;
                        break;
                    }
                }
                _numbers = temp.ToArray();
            }
            else
            {
                _isError = true;
            }
        }

        #endregion Public Methods
    }
}