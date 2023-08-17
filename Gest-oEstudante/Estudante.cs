using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

        public bool inserirEstudante(string nome, string sobrenome,
            DateTime nacimento, string telefone, string genero, 
            string endereco, MemoryStream foto)
        {
            MySqlCommand comando = new MySqlCommand("\"INSERT INTO `estudantes id`(`nome`, `sobrenome`, `nascimento`, `genero`, `telefone`, `endereco`, `foto`) VALUES ('@nm','@sbn','@nsc','@gen','@tel','@end','@fot')",
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

        public bool atualizarEstudante(string nome, string sobrenome,
           DateTime nacimento, string telefone, string genero,
           string endereco, MemoryStream foto)
        {
            MySqlCommand comando = new MySqlCommand("UPDATE `estudantes` SET `nome`= @nm,`sobrenome`= @sbn,`nascimento`= @nsc,`genero`= @gen,`telefone`= @tel,`endereco`= @end,`foto`= @ft WHERE `id` = @id", bancoDeDados.getConexao);

            comando.Parameters.Add("@nm", MySqlDbType.VarChar).Value = nome;
            comando.Parameters.Add("@sbn", MySqlDbType.VarChar).Value = sobrenome;
            comando.Parameters.Add("@nsc", MySqlDbType.Date).Value = nascimento;
            comando.Parameters.Add("@gen", MySqlDbType.VarChar).Value = genero;
            comando.Parameters.Add("@tel", MySqlDbType.VarChar).Value = telefone;
            comando.Parameters.Add("@end", MySqlDbType.VarChar).Value = endereco;
            comando.Parameters.Add("@fot", MySqlDbType.LongBlob).Value = foto.ToArray();

            bancoDeDados.abrirConexao();
            if (comando.ExecuteNonQuery() == 1)
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
        public DataTable getEstudantes ( MySqlCommand comando)
        {
            comando.Connection = bancoDeDados.getConexao;
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            DataTable tabela = new DataTable();
            adaptador.Fill(tabela);

            return tabela;
        }
    }
}

