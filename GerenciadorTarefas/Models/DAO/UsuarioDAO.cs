using GerenciadorTarefas.Models.POCO;
using GerenciadorTarefas.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GerenciadorTarefas.Models.DAO
{
    public class UsuarioDAO : IDAO<Usuario>
    {
        public IEnumerable<Usuario> All
        {
            get
            {
                IDbCommand comando = DB.GetCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Select * From UsuarioTB usu INNER JOIN PermissaoTB per on usu.idPermissao = per.id";

                DataTable dt = new DataTable();
                dt.Load(comando.ExecuteReader());

                List<Usuario> lstUsuario = new List<Usuario>();
                Usuario usuario;

                foreach (DataRow dr in dt.Rows)
                {
                    usuario = new Usuario();
                    usuario.Id = dr["id"].ToInteger();
                    usuario.Nome = dr["nome"].ToString();
                    usuario.Email = dr["email"].ToString();
                    usuario.Permissao = new Permissao { Id = dr["idPermissao"].ToInteger(), Tipo = dr["tipo"].ToString() };
                    lstUsuario.Add(usuario);
                }

                return lstUsuario;

            }
        }

        public Usuario GetById(int id)
        {
            IDbCommand comando = DB.GetCommand();
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add(new SqlParameter("@id", id));
            comando.CommandText = "Select id, nome, email, idPermissao, senha From UsuarioTB Where id = @id";

            DataTable dt = new DataTable();
            dt.Load(comando.ExecuteReader());

            Usuario usuario = new Usuario
            {
                Id = dt.Rows[0]["id"].ToInteger(),
                Nome = dt.Rows[0]["nome"].ToString(),
                Email = dt.Rows[0]["email"].ToString(),
                Permissao = new PermissaoDAO().GetById(dt.Rows[0]["idPermissao"].ToInteger())
            };

            return usuario;
        }

        public Usuario GetByEmailSenha(String email, String senha)
        {
            IDbCommand comando = DB.GetCommand();
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add(new SqlParameter("@email", email));
            comando.Parameters.Add(new SqlParameter("@senha", senha));
            comando.CommandText = "Select * From UsuarioTB Where email = @email and senha = senha";

            DataTable dt = new DataTable();
            dt.Load(comando.ExecuteReader());
            Usuario usuario = new Usuario();
            usuario.Id = dt.Rows[0]["id"].ToInteger();
            usuario.Nome = dt.Rows[0]["nome"].ToString();
            usuario.Email = dt.Rows[0]["email"].ToString();
            usuario.Permissao = new PermissaoDAO().GetById(dt.Rows[0]["idPermissao"].ToString().ToInteger());

            return usuario;
        }

        public void Insert(Usuario usuario)
        {
            IDbCommand comando = DB.GetCommand();
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add(new SqlParameter("@nome", usuario.Nome));
            comando.Parameters.Add(new SqlParameter("@email", usuario.Email));
            comando.Parameters.Add(new SqlParameter("@idPermissao", usuario.Permissao.Id));
            comando.CommandText = "Insert Into UsuarioTB (nome, email, senha, idPermissao) Values (@nome, @email, @senha, @idPermissao)";

            comando.ExecuteNonQuery();
        }


        public void Update(Usuario usuario)
        {
            IDbCommand comando = DB.GetCommand();
            try
            {                
                comando.CommandType = CommandType.Text;
                comando.Parameters.Add(new SqlParameter("@id", usuario.Id));
                comando.Parameters.Add(new SqlParameter("@nome", usuario.Nome));
                comando.Parameters.Add(new SqlParameter("@email", usuario.Email));
                comando.Parameters.Add(new SqlParameter("@idPermissao", usuario.Permissao.Id));
                comando.CommandText = "Update UsuarioTB set nome=@nome, email=@email, idPermissao=@idPermissao Where id = @id";

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw (new Exception(""));
            }
            finally
            {
                comando.Dispose();
            }
        }


        public void Delete(int id)
        {
            IDbCommand comando = DB.GetCommand();
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add(new SqlParameter("@id", id));
            comando.CommandText = "Delete From UsuarioTB Where id = @id";

            comando.ExecuteNonQuery();
        }
    }
}

