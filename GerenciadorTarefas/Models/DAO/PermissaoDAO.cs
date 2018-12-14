using GerenciadorTarefas.Models.POCO;
using GerenciadorTarefas.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GerenciadorTarefas.Models.DAO
{
    public class PermissaoDAO
    {
        public List<Permissao> GetAll()
        {
            IDbCommand comando = DB.GetCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * From PermissaoTB";

            DataTable dt = new DataTable();
            dt.Load(comando.ExecuteReader());

            List<Permissao> lstPermissao = new List<Permissao>();
            Permissao permissao;

            foreach (DataRow dr in dt.Rows)
            {
                permissao = new Permissao();
                permissao.Id = dr["id"].ToInteger();
                permissao.Tipo = dr["tipo"].ToString();

                lstPermissao.Add(permissao);
            }
            return lstPermissao;
        }

        public Permissao GetById(int id)
        {
            IDbCommand comando = DB.GetCommand();
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add(new SqlParameter("@id", id));
            comando.CommandText = "Select * From PermissaoTB Where id = @id";

            DataTable dt = new DataTable();
            dt.Load(comando.ExecuteReader());

            Permissao permissao = new Permissao
            {
                Id = dt.Rows[0]["id"].ToInteger(),
                Tipo = dt.Rows[0]["tipo"].ToString()
            };

            return permissao;
        }

    }
}
