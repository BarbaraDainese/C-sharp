using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Entrar_Click(object sender, EventArgs e)
        {

            string comandoSQL = "SELECT * FROM Representantes WHERE NomeAcesso='" + NomeAcesso.Text + "' AND Senha='" + Senha.Text + "';";
            DataServices.DataBase.DAO db = new DataServices.DataBase.DAO();
            db.ConnectionString = App_Code.AppSettings.Connection();
            db.DataProviderName = DataServices.DataBase.DAO.ProviderName.OleDb;

            System.Data.DataTable tb = (System.Data.DataTable)db.Query(comandoSQL);



            if (tb.Rows.Count==1)
            {
                // Cria a variavel de sessão para identificar que o usuário esta autenticado e
                // permitir a exibição das opções do menu.
                Session["autenticado"] = tb.Rows[0]["Nome"].ToString();
                // 1. Inicializa a classe de autenticação
                System.Web.Security.FormsAuthentication.Initialize();
                // 2. CRIAR O TICKET
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Session["autenticado"].ToString(), DateTime.Now, DateTime.Now.AddMinutes(20), false, FormsAuthentication.FormsCookiePath);

                // 3. CRIPTOGRAFA P TICKET E GRAVAR NO COOKIE DO NAVEGADOR
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)));

                // Redireciona para o form que o usuário tentou acessar
                Response.Redirect(FormsAuthentication.GetRedirectUrl(Session["autenticado"].ToString(), false));
            }
            else
            {
                Erro.Text = "Dados de acesso invalidos";
            }
        }
    }
    }
