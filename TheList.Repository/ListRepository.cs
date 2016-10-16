using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheList.Repository;
using TheList.Model;
using TheList.Repository.Contracts;
using TheList.DataAccess;
using System.Globalization;

namespace TheList.Repository {
    public class ListRepository : IListRepository<ListModel> {
        public Boolean cadastrar( ListModel list) {
            try {
                using( var con = new  checklistEntities()) {
                    var BDlist = new tblList( );
                    BDlist.listTitulo = list.listTitulo;
                    BDlist.listDescricao = list.listDescricao;
                    BDlist.listPrioridade = list.listPrioridade;
                    BDlist.listLimitePrevisto = list.listLimitePrevisto;
                    BDlist.listStatus = 0;
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
            try {
                using( var con = new checklistEntities( ) ) {
                    var BDlist = new tblList( );
                    BDlist.listTitulo = list.listTitulo;
                    BDlist.listDescricao = list.listDescricao;
                    BDlist.listPrioridade = list.listPrioridade;
                    BDlist.listLimitePrevisto = list.listLimitePrevisto;
                    BDlist.listStatus = 0;
                    BDlist.listTipoID = 2;

                    //verifica campos diferentes, e atualiza
                    con.Entry( BDlist ).State = System.Data.Entity.EntityState.Modified;
                    //atualiza no banco(update set...)
                    con.SaveChanges( );
                }
            }
            catch( Exception ) {

                return false;
            }
            return true;
        }

        public Boolean excluir( Int32 ID) {
            try {
                using( var con = new checklistEntities( ) ) {
                    //busca no banco e transforma em obj
                    var BDList = con.tblList.FirstOrDefault( x => x.listID == ID );
                    
                    //remove
                    con.tblList.Remove( BDList );
                    //aplica alteração
                    con.SaveChanges( );
                }
            }
            catch( Exception ) {
                return false;
            }
            return true;
        }

        public IEnumerable<ListModel> listarTodos( ) {
            List<ListModel> list = new List<ListModel>( );
            try {
                using( var con = new checklistEntities( ) ) {
                    var query = from TBL in con.tblList select TBL;
                    foreach( var item in query ) {
                        list.Add( new ListModel( ) { 
                            listID = item.listID,
                            listTitulo = item.listTitulo,
                            listDescricao = item.listDescricao,
                            listPrioridade = Convert.ToInt32( item.listPrioridade ),
                            listStatus = Convert.ToInt32( item.listStatus),
                            listLimitePrevisto = Convert.ToDateTime(item.listLimitePrevisto)

                        } );
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
