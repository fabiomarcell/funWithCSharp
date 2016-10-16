using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TheLists.TestModel;
using TheList.Repository;
using TheList.Model;
using System.Globalization;

namespace TheLists.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            //Session[ "user" ] = "Mr. Anderson";

            //ListRepository listRep = new ListRepository( );

            //List<List> list = new List<List>( );

            //foreach(var item in listRep.listarTodos( )){
            //    list.Add( new List( ) { listTitulo = item.listTitulo, listDescricao = item.listDescricao} );
            //}

            
            return View( );
        }



        [HttpPost]
        public String Cadastro( ) {

            ListRepository listRep = new ListRepository( );
            listRep.cadastrar( new ListModel( ) { 
                listTitulo = Request[ "tarefa" ], 
                listDescricao = Request[ "descricao" ],
                listPrioridade = Int32.Parse(Request[ "prioridade" ]),
                listLimitePrevisto = DateTime.ParseExact( Request[ "dataLimite" ], "dd/MM/yyyy", CultureInfo.InvariantCulture )
            } );


            return Listar( );
        }



        [HttpPost]
        public String Alterar( ) {

            ListRepository listRep = new ListRepository( );
            listRep.alterar( new ListModel( ) { listID = Int32.Parse( Request[ "ID" ] ), listTitulo = Request[ "tarefa" ], listDescricao = Request[ "descricao" ] } );


            return Listar( );
        }


        [HttpPost]
        public String Excluir( ) {

            ListRepository listRep = new ListRepository( );
            listRep.excluir( Int32.Parse( Request[ "ID" ] ) ); ;


            return Listar( );
        }


        [HttpPost]
        public String Listar( ) {
            ListRepository listRep = new ListRepository( );

            List<List> list = new List<List>( );

            foreach( var item in listRep.listarTodos( ) ) {
                list.Add( new List( ) { listTitulo = item.listTitulo, listDescricao = item.listDescricao } );
            }

            String HTML = "";
            Int32 x = 0;
            foreach( var item in listRep.listarTodos( ) ) {
                String showDate = item.listLimitePrevisto.ToString( "dd/MM/yyyy" );
                String priority = "";
                if(item.listLimitePrevisto.ToString( "dd/MM/yyyy" ) == "01/01/0001") {
                    showDate = "-";
                }

                if( item.listPrioridade == 0 ) {
                    priority = "#c10000";
                }
                else if( item.listPrioridade == 1 ) {
                    priority = "#e0ae00";
                }
                else if( item.listPrioridade == 2 ) {
                    priority = "#1e6307";
                }
                HTML += "<div class='col-md-3 col-sm-6 to-do-item'>" +
                    "<div onclick=\"excluirLista('" + item.listID + "');\"><i class='fa fa-times' aria-hidden='true' style='cursor:pointer; float:right; font-size:25px;'></i><!-- Excluir--></div>" +
                    "<div class='clearfix'></div>" +
                    "<div class='to-do-caption' style='border-top:20px solid " + priority + ";'>" +
                        "<h4>" + item.listTitulo + "</h4>" +
                        "<p class='text-muted'>" + ( item.listDescricao == "" ? "Desc." : item.listDescricao ) + "</p>" +
                        "<div class='clearfix'></div>" +
                        "<br />" +
                        "<hr>" +
                        "<p class='text-muted pull-center' style='margin-right:20px;'>" +  showDate + "</p>" +
                        "<div class='clearfix'></div>" +
                        "<hr>"+
                        "<i class='fa fa-check' aria-hidden='true'></i><!--Completo-->" +
                        "<i class='fa fa-calendar' aria-hidden='true'></i><!--Em Tempo-->" +
                        "<i class='fa fa-calendar' aria-hidden='true' style='color:#F00;'></i><!--Atrasado-->" +
                        "<i class='fa fa-star-o' aria-hidden='true'></i><!--Não Prioridade-->" +
                        "<i class='fa fa-star' aria-hidden='true'></i><!--Prioridade-->" +

                        "<div class='clearfix'></div>" +
                        
                    "</div>" +
                "</div>";
                x++;
                if(x == 4){
                    x = 0;
                    HTML += "<div class='clearfix'></div>";
                }
            }
            return new JavaScriptSerializer( ).Serialize( new { html = HTML, status = "true" } );
        }
    }
}