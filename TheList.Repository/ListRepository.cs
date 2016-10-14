using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheList.Repository;
using TheList.Model;
using TheList.Repository.Contracts;
using TheList.DataAccess;

namespace TheList.Repository {
    public class ListRepository : IListRepository<ListModel> {
        public Boolean cadastrar( ListModel list) {
            try {
                using( var con = new  checklistEntities()) {
                    var BDlist = new tblList( );
                    BDlist.listTitulo = list.listTitulo;
                    BDlist.listTipoID = 2;

                    //prepara para insert na tabela
                    con.tblList.Add( BDlist );
                    //insere no banco(insert into ...)
                    con.SaveChanges( );

                    return true;
                }
            }
            catch( Exception e) {
                throw e;
                return false;
            }
        }

        public Boolean alterar( ListModel list) {
            return false;
        }

        public Boolean excluir( ListModel list ) {
            return false;
        }

        public IEnumerable<ListModel> listarTodos( ) {
            List<ListModel> list = new List<ListModel>( );
            try {
                using( var con = new checklistEntities( ) ) {
                    var query = from TBL in con.tblList select TBL;
                    foreach( var item in query ) {
                        list.Add( new ListModel( ) { 
                            listTitulo = item.listTitulo, 
                            listDescricao = item.listDescricao
                        }  );
                    }
                }
            }
            catch( Exception e ) {
                throw e;
            }
            return list;
        }
    }
}
