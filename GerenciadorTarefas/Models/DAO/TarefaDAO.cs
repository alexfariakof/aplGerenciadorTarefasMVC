using GerenciadorTarefas.Models.POCO;
using GerenciadorTarefas.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GerenciadorTarefas.Models.DAO
{
    public class TarefaDAO : IDAO<Tarefa>
    {
        public IEnumerable<Tarefa> All
        {
            get
            {
                IDbCommand comando = DB.GetCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Select * From TarefaTB";

                DataTable dt = new DataTable();
                dt.Load(comando.ExecuteReader());

                List<Tarefa> lstTarefa = new List<Tarefa>();
                Tarefa tarefa;

                foreach (DataRow dr in dt.Rows)
                {
                    tarefa = new Tarefa();
                    tarefa.Id = dr["id"].ToInteger();
                    tarefa.Titulo = dr["titulo"].ToString();
                    lstTarefa.Add(tarefa);
                }

                return lstTarefa;
            }
        }

        public List<Tarefa> GetAll()
        {
            IDbCommand comando = DB.GetCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * From TarefaTB";

            DataTable dt = new DataTable();
            dt.Load(comando.ExecuteReader());

            List<Tarefa> lstTarefa = new List<Tarefa>();
            Tarefa tarefa;

            foreach (DataRow dr in dt.Rows)
            {
                tarefa = new Tarefa();
                tarefa.Id = dr["id"].ToInteger();
                tarefa.Titulo = dr["titulo"].ToString();
                lstTarefa.Add(tarefa);
            }

            return lstTarefa;
        }

        public IEnumerable<Tarefa> FindByTitulo(String titulo)
        {
            IDbCommand comando = DB.GetCommand();
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add(new SqlParameter("@titulo", "%" + titulo + "%"));
            comando.CommandText = "Select * From TarefaTB where titulo like @titulo";

            DataTable dt = new DataTable();
            dt.Load(comando.ExecuteReader());

            List<Tarefa> lstTarefa = new List<Tarefa>();
            Tarefa tarefa;

            foreach (DataRow dr in dt.Rows)
            {
                tarefa = new Tarefa();
                tarefa.Id = dr["id"].ToInteger();
                tarefa.Titulo = dr["titulo"].ToString();
                lstTarefa.Add(tarefa);
            }

            return lstTarefa;
        }

        public Tarefa GetById(int id)
        {
            IDbCommand comando = DB.GetCommand();
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add(new SqlParameter("@id", id));
            comando.CommandText = "Select * From TarefaTB where id = @id";

            DataTable dt = new DataTable();
            dt.Load(comando.ExecuteReader());

            Tarefa tarefa = new Tarefa {
                Id = dt.Rows[0]["id"].ToInteger(),
                Titulo = dt.Rows[0]["titulo"].ToString()
            };            

            return tarefa;
        }

        public void Insert(Tarefa tarefa)
        {
            IDbCommand comando = DB.GetCommand();
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add(new SqlParameter("@titulo", tarefa.Titulo));
            comando.CommandText = "Insert Into TarefaTB (titulo) Values (@titulo)";

            comando.ExecuteNonQuery();
        }


        public void Update(Tarefa tarefa)
        {
            IDbCommand comando = DB.GetCommand();
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add(new SqlParameter("@id", tarefa.Id));
            comando.Parameters.Add(new SqlParameter("@titulo", tarefa.Titulo));
            comando.CommandText = "Update TarefaTB set titulo = @titulo Where id = @id";

            comando.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            IDbCommand comando = DB.GetCommand();
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add(new SqlParameter("@id", id));
            comando.CommandText = "Delete From TarefaTB Where id = @id";

            comando.ExecuteNonQuery();
        }


    }
}
