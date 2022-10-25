using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogExcecoes;

namespace Projeto3 {
    public partial class ExibirExcecoes1 : System.Web.UI.Page {
        string caminhoFisico = HttpContext.Current.Server.MapPath("~/Erros.txt");

        protected void Page_Load(object sender, EventArgs e) {
            var te = new TratamentoExcecoes();
            Excecoes.Text = te.LerExcecoes();
        }

        protected void Limpar_Click(object sender, EventArgs e) {
            var te = new TratamentoExcecoes();
            te.LimparExcecoes();
            Excecoes.Text = "";
        }
    }
}