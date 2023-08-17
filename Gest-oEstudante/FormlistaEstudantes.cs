using MySql.Data.MySqlClient;
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
    public partial class FormlistaEstudantes : Form
    {
        public FormlistaEstudantes()
        {
            InitializeComponent();
        }

        Estudante estudante= new Estudante();

        private void FormlistaEstudantes_Load(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM 'estudantes'");
            dataGridView1. ReadOnly = true;
            DataGridViewImageColumn colunaDeFotos = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = estudante.getEstudantes(command); 
        }
    }
}
