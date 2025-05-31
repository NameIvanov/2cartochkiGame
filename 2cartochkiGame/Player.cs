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
        static public string Name { get; set; }
        static public int ItogSteps { get; set; }
        static public int ItogTime { get; set; }
        public Player(string name)
        {
            Name = name;
        }
        static public void AddPlayer()
        {
            StreamWriter sw = new StreamWriter("UsersResults/usersResults.txt");
            sw.WriteLine($"Имя: {Name} Количество шагов: {ItogSteps} Время прохождения: {ItogTime}");
            sw.Close();
        }
    }
}
