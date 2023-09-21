using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOfBasicsCSharp
{
    internal class Client
    {
        private int _money;
        private int _moneyToPay;
        public int DesiredMinutes { get; private set; }
        public Client(int money, Random random)
        {
            _money = money;
            DesiredMinutes = random.Next(10, 30);
        }

        public bool CheckSolvency(Computer computer) // приклад інкапсюуляції - ми не повертаємо і не взаємодіємо з приватним полем ззовні
        {
            _moneyToPay = DesiredMinutes * computer.PricePerMinute;
            return (_money >= _moneyToPay);
        }

        public int Pay()
        {
            _money -= _moneyToPay;
            return _moneyToPay;
        }
    }
}
