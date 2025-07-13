using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2cartochkiGame
{
    public partial class FormWordOsetian : Form
    {
        public FormWordOsetian()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] words = textBoxOsetWords.Text.Split(',');
            for (int i = 1; i < words.Length+1; i++)
            {
                string folder = "UserCards";
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string filename = $"photo{i}.png";
                string filepath = Path.Combine(folder, filename);

                Console.WriteLine("Saving to: " + Path.GetFullPath(filepath));

                using (Bitmap bitmap = new Bitmap(400, 200))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.Clear(Color.White);
                        string text = words[i-1];
                        using (Font font = new Font("Arial", 30))
                        using (Brush brush = new SolidBrush(Color.Black))
                        {
                            SizeF size = g.MeasureString(text, font);
                            float x = (bitmap.Width - size.Width) / 2;
                            float y = (bitmap.Height - size.Height) / 2;
                            g.DrawString(text, font, brush, x, y);
                        }
                    }

                    bitmap.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            this.Close();
        }
    }
}
