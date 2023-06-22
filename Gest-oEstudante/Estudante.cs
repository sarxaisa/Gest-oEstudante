using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Gest_oEstudante
{
    internal class Estudante
    {
        Meu_BD bancoDeDados = new Meu_BD();
        private object nascimento;

        public bool inserirEstudante(string nome, string sobrenome,
            DateTime nacimento, string telefone, string genero, 
            string endereco, MemoryStream foto)
        {
            MySqlCommand comando = new MySqlCommand("\"INSERT INTO `estudantes id`(`nome`, `sobrenome`, `nascimento`, `genero`, `telefone`, `endereco`, `foto`) VALUES ('@nm','@sbn','@nsc','@gen','@tel','@end','\\\"fot')\"",
                bancoDeDados.getConexao);

            comando.Parameters.Add("@nm", MySqlDbType.VarChar).Value = nome;
            comando.Parameters.Add("@sbn", MySqlDbType.VarChar).Value = sobrenome;
            comando.Parameters.Add("@nsc", MySqlDbType.Date).Value = nascimento;
            comando.Parameters.Add("@gen", MySqlDbType.VarChar).Value = genero;
            comando.Parameters.Add("@tel", MySqlDbType.VarChar).Value = telefone;
            comando.Parameters.Add("@end", MySqlDbType.VarChar).Value = endereco;
            comando.Parameters.Add("@fot", MySqlDbType.LongBlob).Value = foto.ToArray();

            bancoDeDados.abrirConexao();
            if(comando.ExecuteNonQuery() == 1)
            {
                bancoDeDados.fecharConexao();
                return true;
            }
            else
            {
                bancoDeDados.fecharConexao();
                return false;
            }
        }
    }
}
