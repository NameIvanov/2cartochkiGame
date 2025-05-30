using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2cartochkiGame
{
    public partial class FormUser : Form
    {
        
        public FormUser()
        {
            InitializeComponent();
        }

        private void buttonEnterName_Click(object sender, EventArgs e)
        {
            Player player = new Player(textBoxEnterName.Text, FormGame.cntSteps, itogTime);
            this.Close();
        }
    }
}
