using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.IO;

namespace _2cartochkiGame
{
    public partial class FormGame : Form
    {

        int[,] mass = new int[4, 4]; // Массив для значенией, чтоб потом по значению присвоить карточку в датагрид
        Random rnd = new Random();
        Image Def;
        int firstIndex1 = -1;
        int secondIndex1 = -1;
        int firstIndex2, secondIndex2, cnt, flag = 0;
        public static int cntSteps = 0;
        int cntEnd = 30;
        Time time = new Time();
        FormUser enterName = new FormUser();
        Card card;


        //private void ShowItem(int[,] znach, int row, int col) //ОТРИСОВКА НА ЭКРАНЕ ВЫБРАННОЙ КАРТОЧКИ
        //{
        //    int num = znach[row, col];
        //    if(num<0)
        //    {
        //        string ph = $"images/photo_{Convert.ToString((num)).Substring(1)}.png";
        //        Image image = Image.FromFile(ph);
        //        dataGridView1.Rows[row].Cells[col].Value = image;
        //    }
        //    else
        //    {
        //        string ph = $"images/photo{Convert.ToString((num))}.jpg";
        //        Image image = Image.FromFile(ph);
        //        dataGridView1.Rows[row].Cells[col].Value = image;
        //    }
        //}
        //private void ShowDefolt() //ВЫВОД НАЧАЛЬНОГО ЭКРАНА КАРТОЧЕК
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        for (int j = 0; j < 4; j++)
        //        {
        //            dataGridView1.Rows[i].Cells[j].Value = Def;
        //        }
        //    }
        //}
        private void completionMass(int[,] mass,List<int> words1)// ПЕРЕМЕШИВАНИЕ "ФОТОГРАФИЙ" ПО МАССИВУ
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int w = rnd.Next(0, words1.Count);
                    mass[i, j] = words1[w];
                    words1.RemoveAt(w);
                }
            }
        }
        public void resetFull()// СБРОС ВСЕГО ИГРОВОГО ПОЛЯ
        {
            cntSteps = 0;
            cnt = 0;
            cntEnd = 30;
            firstIndex1 = -1;
            secondIndex1 = -1;
            textBoxCountSteps.Text = $"Кол-во сделанных шагов:{cntSteps}";
            textBoxPerfect.Text = $"Кол-во допустимых шагов: {cntEnd}";
            //ShowDefolt();
            card.ShowDefoltCards();
            if (flag == 0)
            {
                List<int> level1_words = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, -1, -2, -3, -4, -5, -6, -7, -8 };
                completionMass(mass, level1_words);
                Card.Mass = mass;
            }
            else
            {
                List<int> level2_words = new List<int> { 9, 10, 11, 12, 13, 14, 15, 16, -9, -10, -11, -12, -13, -14, -15, -16 };
                completionMass(mass, level2_words);
                Card.Mass = mass;
            }
        }
        
        private void buttonLevel2_Click(object sender, EventArgs e)// 2 УРОВЕНЬ
        {
            flag = 1;
            resetFull();
        }
        private void buttonLevel1_Click(object sender, EventArgs e)// 1 УРОВЕНЬ
        {
            flag = 0;
            resetFull();
        }
        private void buttonRestart_Click(object sender, EventArgs e) // НАЧАТЬ ЗАНОВО
        {
            resetFull();
            time.Start();
            Player.SortFile();
            WriteResults();
        }
        public FormGame()
        {
            InitializeComponent();
            Def = Bitmap.FromFile("images/standart.png");
            card = new Card(dataGridView1);
        }
        public void WriteResults()
        {
            listBoxRecords.Items.Clear();
            using(StreamReader writer = new StreamReader("UsersResults/usersResults.txt"))
            {
                while (!writer.EndOfStream)
                {
                    listBoxRecords.Items.Add(writer.ReadLine());
                }
            }
        }
        private void FormGame_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(4);

            time.Start(); 

            Player.SortFile();
            WriteResults();

            //ShowDefolt();
            card.ShowDefoltCards();
            resetFull();

            enterName.Show();
        }
        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != card.DefoltImage)
            {
                MessageBox.Show("Выберите другую карту!");
            }
            else
            {
                if (firstIndex1 == -1 && secondIndex1 == -1)
                {
                    firstIndex1 = e.RowIndex;
                    secondIndex1 = e.ColumnIndex;
                    Card.Row = e.RowIndex;
                    Card.Col = e.ColumnIndex;
                    //ShowItem(mass, firstIndex1, secondIndex1);
                    card.ShowSelectedCard();
                }
                else
                {
                    firstIndex2 = e.RowIndex;
                    secondIndex2 = e.ColumnIndex;
                    //ShowItem(mass, firstIndex2, secondIndex2);
                    Card.Row = e.RowIndex;
                    Card.Col = e.ColumnIndex;
                    card.ShowSelectedCard();
                    if (Math.Abs(mass[firstIndex1, secondIndex1]) != Math.Abs(mass[firstIndex2, secondIndex2]))
                    {                      
                        this.Enabled = false;
                        await Task.Delay(700);
                        this.Enabled = true;
                        //dataGridView1.Rows[firstIndex1].Cells[secondIndex1].Value = Def;
                        //dataGridView1.Rows[firstIndex2].Cells[secondIndex2].Value = Def;
                        card.ShowSelectedDefoltCards(firstIndex1, secondIndex1, firstIndex2, secondIndex2);
                    }
                    else
                    {
                        cnt++;
                    }
                    firstIndex1 = -1;
                    secondIndex1 = -1;
                    cntSteps++;
                    cntEnd--;
                    textBoxCountSteps.Text = $"Кол-во сделанных шагов:{cntSteps}";
                    textBoxPerfect.Text = $"Кол-во допустимых шагов: {cntEnd}";
                    if (cnt == 8 || cntEnd == 0)
                    {
                        DialogResult result;
                        if(cnt==8)
                        {
                            result = MessageBox.Show("Поздравляем c победой,хотите сыграть еще?", "ПОБЕДА!", MessageBoxButtons.YesNo);
                            time.Stop();
                            Player.ResultTime = Time.СalculatedTime;
                            Player.ResultSteps = cntSteps;
                            Player.WriteToFile();
                            Player.SortFile();
                            WriteResults();
                        }
                        else
                        {
                            result = MessageBox.Show("К сожалению вы проиграли,хотите попробовать заново?", "Проигрышь!", MessageBoxButtons.YesNo);
                            time.Stop();
                            Player.ResultTime = Time.СalculatedTime;
                            Player.ResultSteps = cntSteps;
                            Player.WriteToFile();
                            Player.SortFile();
                            WriteResults();
                        }
                        if (result == DialogResult.Yes)
                        {
                            resetFull();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}