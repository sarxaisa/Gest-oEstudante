using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gest_oEstudante
{
    public partial class login_Form : Form
    {
        public login_Form()
        {
            InitializeComponent();
        }

        private void login_Form_Load(object sender, EventArgs e)
        {
            //define a imagem da picture box
            pictureBox1.Image = Image.FromFile("../../Imagens/user.png");
        }
    }
}
