using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gest_oEstudante
{
    //Banco de dados
    internal class Meu_BD
    {
        // objeto que representa nossa conexao com o banco de dados. 
        private MySqlConnection conexao = new MySqlConnection("datasource=localhost;username=root;password=;database=sga_estudantes_bd_t4");

    }
}
