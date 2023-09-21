using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOfBasicsCSharp
{
    internal class Computer
    {
        private Client _client;
        private int _minutesRemaining;
        public bool isTaken
        {
            get
            {
                return _minutesRemaining > 0;
            }
        }
        public int PricePerMinute { get; private set; }
        public Computer(int pricePerMinute)
        {
            PricePerMinute = pricePerMinute;
        }
        public void BecomeEmpty()
        {
            _client = null;
        }
        public void BecomeTaken(Client client) // Змінювати приватні поля публічними методами не правильно 
        {
            _client = client;
            _minutesRemaining = _client.DesiredMinutes;
        }
        public void SpendOneMinute()
        {
            _minutesRemaining--;
        }
        public void ShowState()
        {
            if (isTaken)
                Console.WriteLine($"Computer is busy, {_minutesRemaining} minutes remaining !");
            else
                Console.WriteLine($"Computer if free ! Price per minute : {PricePerMinute}");
        }
    }
}
