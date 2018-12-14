using System;
using System.Data;
using System.Data.SqlClient;

namespace GerenciadorTarefas.Models.DAO
{
    public class LoginDAO
    {
        public Boolean IsLoginValido(String email, String senha)
        {
            IDbCommand comando = DB.GetCommand();
            try
            {
                comando.CommandType = CommandType.Text;
                comando.Parameters.Add(new SqlParameter("@email", email));
                comando.Parameters.Add(new SqlParameter("@senha", senha));
                comando.CommandText = "Select * From UsuarioTB Where email = @email and senha = senha";

                DataTable dt = new DataTable();
                dt.Load(comando.ExecuteReader());

                if ((dt.Rows.Count != 0) && (email.Equals(dt.Rows[0]["email"].ToString())) && (senha.Equals(dt.Rows[0]["senha"].ToString())))
                    return true;

                return false;
            }
            catch
            {
                throw (new Exception("Erro durante validação do login."));
            }
            finally
            {
                comando.Dispose();
            }
        }
    }
}