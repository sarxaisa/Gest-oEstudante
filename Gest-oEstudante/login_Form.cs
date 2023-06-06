using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            pictureBox1.Image = Image.FromFile("../../Imagens/User.png");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Meu_BD bancodeDados = new Meu_BD();

            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            DataTable tabela = new DataTable();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM `usuarios` WHERE `UserName` = @usn AND `Password` = @psd", bancodeDados.getConexao);

            comando.Parameters.Add("@usn", MySqlDbType.VarChar).Value = txtUsuario.Text;
            comando.Parameters.Add("@psd", MySqlDbType.VarChar).Value = txtSenha.Text;
            
            adaptador.SelectCommand = comando;
            adaptador.Fill(tabela);

            if (tabela.Rows.Count > 0 ) 
            {
                //MessageBox.Show("SIM");
                this.DialogResult= DialogResult.OK;
            }
            else 
            {
                MessageBox.Show("Nome do usuario invalido", 
                    "Erro de Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
