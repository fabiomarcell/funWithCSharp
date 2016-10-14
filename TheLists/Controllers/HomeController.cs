using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TheLists.TestModel;
using TheList.Repository;
using TheList.Model;

namespace TheLists.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            Session[ "user" ] = "Mr. Anderson";

            ListRepository listRep = new ListRepository( );

            List<List> list = new List<List>( );

            foreach(var item in listRep.listarTodos( )){
                list.Add( new List( ) { listTitulo = item.listTitulo, listDescricao = item.listDescricao} );
            }

            
            return View( list);
        }

        [HttpPost]
        public String Cadastro( ) {

            ListRepository listRep = new ListRepository( );
            listRep.cadastrar( new ListModel( ) { listTitulo = Request[ "tarefa" ], listDescricao = Request[ "descricao" ] } );

            List<List> list = new List<List>( );

            foreach( var item in listRep.listarTodos( ) ) {
                list.Add( new List( ) { listTitulo = item.listTitulo, listDescricao = item.listDescricao } );
            }

            String HTML = "";
            foreach( var item in list ) { 
                HTML += "<div class='col-md-3 col-sm-6 to-do-item'>" +
                    "<div class='to-do-caption' style='border-top:20px solid #000;'>" +
                        "<h4>"+ item.listTitulo +"</h4>" +
                        "<p class='text-muted'>" + ( item.listDescricao == "" ? "Desc." : item.listDescricao ) + "</p>" +
                        "<div class='clearfix'></div>" +
                        "<br />" +
                    
                        "<i class='fa fa-check' aria-hidden='true'></i><!--Completo-->" +
                        "<i class='fa fa-calendar' aria-hidden='true'></i><!--Em Tempo-->" +
                        "<i class='fa fa-calendar' aria-hidden='true' style='color:#F00;'></i><!--Atrasado-->" +
                        "<i class='fa fa-star-o' aria-hidden='true'></i><!--Não Prioridade-->" +
                        "<i class='fa fa-star' aria-hidden='true'></i><!--Prioridade-->" +
                        "<i class='fa fa-times' aria-hidden='true'></i><!-- Excluir-->" +


                        "<p class='text-muted pull-left' style='margin-right:20px;'>11/10/1993</p>" +
                    
                    "</div>" +
                "</div>";
                
            }
            return new JavaScriptSerializer( ).Serialize( new { html = HTML, status = "true" } );
        }

        [HttpPost]
        public String Listar( ) {
            ListRepository listRep = new ListRepository( );

            List<List> list = new List<List>( );

            foreach( var item in listRep.listarTodos( ) ) {
                list.Add( new List( ) { listTitulo = item.listTitulo, listDescricao = item.listDescricao } );
            }

            String HTML = "";
            foreach( var item in list ) {
                HTML += "<div class='col-md-3 col-sm-6 to-do-item'>" +
                    "<div class='to-do-caption' style='border-top:20px solid #000;'>" +
                        "<h4>" + item.listTitulo + "</h4>" +
                        "<p class='text-muted'>" + ( item.listDescricao == "" ? "Desc." : item.listDescricao ) + "</p>" +
                        "<div class='clearfix'></div>" +
                        "<br />" +

                        "<i class='fa fa-check' aria-hidden='true'></i><!--Completo-->" +
                        "<i class='fa fa-calendar' aria-hidden='true'></i><!--Em Tempo-->" +
                        "<i class='fa fa-calendar' aria-hidden='true' style='color:#F00;'></i><!--Atrasado-->" +
                        "<i class='fa fa-star-o' aria-hidden='true'></i><!--Não Prioridade-->" +
                        "<i class='fa fa-star' aria-hidden='true'></i><!--Prioridade-->" +
                        "<i class='fa fa-times' aria-hidden='true'></i><!-- Excluir-->" +


                        "<p class='text-muted pull-left' style='margin-right:20px;'>11/10/1993</p>" +

                    "</div>" +
                "</div>";

            }
            return new JavaScriptSerializer( ).Serialize( new { html = HTML, status = "true" } );
        }
    }
}