using System;

namespace GerenciadorTarefas.Models.POCO
{
    public class Usuario 
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public Permissao Permissao { get; set; }
    }
}

