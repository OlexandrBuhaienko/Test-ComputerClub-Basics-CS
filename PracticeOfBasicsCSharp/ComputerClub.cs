using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOfBasicsCSharp
{
    internal class ComputerClub
    {
        private List<Computer> _computers = new List<Computer>();
        private Queue<Client> _clients = new Queue<Client>();
        private int _money;
        public ComputerClub(int computersCount)
        {
            Random random = new Random();
            for (int i = 0; i < computersCount; i++)
            {
                _computers.Add(new Computer(random.Next(5, 15)));
            }
            CreateNewClients(25, random);
        }
        public void CreateNewClients(int countOfClients, Random random)
        {
            for (int i = 0; i < countOfClients; i++)
            {
                _clients.Enqueue(new Client(random.Next(100, 250), random));
            }
        }
        public void Work()
        {
            while (_clients.Count > 0)
            {
                Client newClient = _clients.Dequeue();
                Console.WriteLine($"Balance of computer club : {_money} USD. Looking forward to new client!");
                Console.WriteLine($"We have a new client. They want to buy {newClient.DesiredMinutes} minutes");
                ShowAllComputersStates();

                Console.Write("\nThey want to choose computer with number : ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int computerNumber))
                {
                    computerNumber -= 1;
                    if (computerNumber >= 0 && computerNumber < _computers.Count)
                    {
                        if (_computers[computerNumber].isTaken)
                        {
                            Console.WriteLine("This computer is already taken. Client gone !");
                        }
                        else
                        {
                            if (newClient.CheckSolvency(_computers[computerNumber]))
                            {
                                Console.WriteLine($"Client made payment, and sat at the computer {computerNumber + 1}");
                                _money += newClient.Pay();
                                _computers[computerNumber].BecomeTaken(newClient);
                            }
                            else
                            {
                                Console.WriteLine("Client don't have enough money. They gone !");
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input ! Client gone !");
                    }
                }
                else
                {
                    CreateNewClients(1, new Random());
                    Console.WriteLine("Wrong input ! Please again.");
                }
                Console.WriteLine("To move to the next client, press any button !");
                Console.ReadKey();
                Console.Clear();
                SpendOneMinute();
            }
        }
        private void ShowAllComputersStates()
        {
            Console.WriteLine("\nAll computers list : ");
            for (int i = 0; i < _computers.Count; i++)
            {
                Console.Write((i + 1) + " _ ");
                _computers[i].ShowState();
            }
        }
        private void SpendOneMinute()
        {
            foreach (var computer in _computers)
            {
                computer.SpendOneMinute();
            }
        }
    }
}
