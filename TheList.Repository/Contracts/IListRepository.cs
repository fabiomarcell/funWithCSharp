using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheList.Model;

namespace TheList.Repository.Contracts {
    public interface IListRepository<TEntity> where TEntity : class {
        Boolean cadastrar( ListModel list );
        Boolean alterar( ListModel list);
        Boolean excluir( Int32 ID);
        IEnumerable<ListModel> listarTodos( );
    }
}
