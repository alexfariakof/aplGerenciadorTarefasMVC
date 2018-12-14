
using System.Collections.Generic;

namespace GerenciadorTarefas.Models.DAO
{
    public interface IDAO<Ttipo>
    {
        IEnumerable<Ttipo> All { get; }
        Ttipo GetById(int id);
        void Insert(Ttipo T);
        void Update(Ttipo T);
        void Delete(int id);
    }
}
