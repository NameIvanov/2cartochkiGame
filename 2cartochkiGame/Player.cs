using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2cartochkiGame
{
    internal class Player
    {
        public string Name { get; set; }
        public int ItogSteps { get; set; }
        public int ItogTime { get; set; }
        public Player(string name, int itogSteps, int itogTime)
        {
            Name = name;
            ItogSteps = itogSteps;
            ItogTime = itogTime;
        }
        public void AddPlayer()
        {
            StreamWriter sw = new StreamWriter("UsersResults/usersResults.txt");
            sw.WriteLine($"Имя: {Name} Количество шагов: {ItogSteps} Время прохождения: {ItogTime}");
        }
    }
}
