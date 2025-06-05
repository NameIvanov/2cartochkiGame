using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Timers;

namespace _2cartochkiGame
{
    internal class Player
    {
        static public string Name { get; set; }
        static public int ResultSteps { get; set; }
        static public int ResultTime { get; set; }
        public Player(string name)
        {
            Name = name;
        }
        static public void WritePlayer()
        {
            using (StreamWriter writer = new StreamWriter("UsersResults/usersResults.txt", true))
            {
                writer.WriteLine($"Имя: {Name} Количество шагов: {ResultSteps} Время прохождения: {ResultTime}");
                writer.Close();
            }
        }
        public static void SortResults()
        {
            List<string> users = new List<string>();
            using(StreamReader reader = new StreamReader("UsersResults/usersResults.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var stroka = reader.ReadLine();
                    users.Add(stroka);
                }
            }
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 1; j < users.Count; j++)
                {
                    var a1 = users[j - 1].Split();
                    var a2 = users[j].Split();
                    if (Convert.ToInt32(a1[4]) > Convert.ToInt32(a2[4]) || (Convert.ToInt32(a1[4]) == Convert.ToInt32(a2[4]) && Convert.ToInt32(a1[7]) > Convert.ToInt32(a2[7])))
                    {
                        string smena = users[j - 1];
                        users[j - 1] = users[j];
                        users[j] = smena;
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter("UsersResults/usersResults.txt", false))
            {
                for (int i = 0; i < users.Count; i++)
                {
                    writer.WriteLine(users[i]);
                }
                writer.Close();
            }
        }
    }
}
