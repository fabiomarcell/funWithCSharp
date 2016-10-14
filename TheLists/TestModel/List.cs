using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheLists.TestModel {
    public class List {
        public Int32 listID { get; set; }
        public ListTipo listTipo {get; set;}
	    public String listTitulo {get; set;}
	    public String listDescricao {get; set;}
	    public Int32 listPrioridade {get; set;}
	    public Int32 listStatus {get; set;}
	    public DateTime listLimitePrevisto{get; set;}
    }
}