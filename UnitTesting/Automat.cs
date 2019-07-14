using System;
using Microsoft.Extensions.Logging;

namespace UnitTesting
{
    public class Automat : IAutomat
    {
        private int _credit = 0;
        private readonly ILogger<Automat> _logger;

        public Automat(ILogger<Automat> logger)
        {
            _logger = logger;
        }

        public Food TakeFood()
        {
            if (_credit <= 0)
            {
                throw new NullReferenceException();
            }

            return new Food();
        }

        public bool GetMoney(int money)
        {
            if (money <= 0)
            {
                return false;
            }

            _logger.IsEnabled(LogLevel.Critical);
            _credit = money;
            return true;
        }
    }
}
