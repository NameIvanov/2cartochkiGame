using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace _2cartochkiGame
{
    internal class Card
    {
        public Image DefoltImage = Image.FromFile("images/defolt.png");
        private readonly DataGridView DataGrid;
        public Image image { get; set; }
        public static int Row { get; set; }
        public static int Col { get; set; }
        public int[,] Mass { get;}
        public Card(int[,] mass, int row, int col, DataGridView datagrid)
        {
            Row = row;  
            Col = col;  
            Mass = mass;
            DataGrid = datagrid;
        }
        public void ShowSelectedCard() // Показ карточки
        {
            int num = Mass[Row, Col];
            if (num < 0)
            {
                string ph = $"images/photo_{Convert.ToString((num)).Substring(1)}.png";
                Image image = Image.FromFile(ph);
                DataGrid.Rows[Row].Cells[Col].Value = image;
            }
            else
            {
                string ph = $"images/photo{Convert.ToString((num))}.jpg";
                Image image = Image.FromFile(ph);
                DataGrid.Rows[Row].Cells[Col].Value = image;
            }
        }
        public void ShowDefoltCard() //ВЫВОД НАЧАЛЬНОГО ЭКРАНА КАРТОЧЕК
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    DataGrid.Rows[i].Cells[j].Value = DefoltImage;
                }
            }
        }
    }
}
