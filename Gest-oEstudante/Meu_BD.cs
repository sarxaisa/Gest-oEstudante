using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Gest_oEstudante
{
    //Banco de dados
    internal class Meu_BD
    {
        // objeto que representa nossa conexao com o banco de dados. 
        private MySqlConnection conexao = new MySqlConnection("datasource=localhost;username=root;password=;database=sga_estudantes_bd_t4");

        //controla acesso da variavel "Conexão"
        public MySqlConnection getConexao
        {
            get 
            {
                return conexao;
            }
        }
        //método para abriri conexao "inciar conexao"
        //com o BD "banco de dados"
        public void abrirConexao() 
        {
            //comando abre a conexao se a conexao estiver fechada.
            if (conexao.State == ConnectionState.Closed) 
            {
                conexao.Open();
            }
        }

        public void fecharConexao()
        {
            //comando fecha a conexao se a conexao estiver aberta.
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
