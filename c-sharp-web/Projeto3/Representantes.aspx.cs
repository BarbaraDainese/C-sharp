using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Projeto3 {
    public partial class Representantes : System.Web.UI.Page {
        //Publica para todos os métodos da classe
        Model.Representantes representante = new Model.Representantes();

        //Instancia da classe de acesso ao banco de dados
        //DAO = Data Acces Object
        DataServices.DataBase.DAO db = new DataServices.DataBase.DAO();

        protected void Page_Load(object sender, EventArgs e) {
            LoadGrid();
        }

        protected void Inserir_Click(object sender, EventArgs e) {
            //Validar inputs
            if (Nome.Text.Trim() == "") {
                Mensagem.Text = "Digite seu nome";
            }
            else if (Email.Text.Trim() == "") {
                Mensagem.Text = "Digite seu email";
            }
            else if (NomeAcesso.Text.Trim() == "") {
                Mensagem.Text = "Digite seu Login";
            }
            else if (Senha.Text.Trim() == "") {
                Mensagem.Text = "Digite sua senha";
            }
            else if (GravarUsuario(NomeAcesso.Text, RepresentanteId.Text) == false) {
            }
            else {
                if (RepresentanteId.Text == "") {
                    //Inserir novo registro;
                    representante.Nome = Nome.Text;
                    representante.Email = Email.Text;
                    representante.NomeAcesso = NomeAcesso.Text;
                    representante.Senha = Senha.Text;
                    //Definir conexão
                    db.ConnectionString = App_Code.AppSettings.Connection();
                    //Definir o banco de dados
                    db.DataProviderName = DataServices.DataBase.DAO.ProviderName.OleDb;
                    //Inserir no banco de dados
                    db.Insert(representante, "RepresentanteId");
                    LimparControles();
                }
                else {
                    //Editar Registro
                    representante.Nome = Nome.Text;
                    representante.Email = Email.Text;
                    representante.NomeAcesso = NomeAcesso.Text;
                    representante.Senha = Senha.Text;
                    db.Update(representante, "RepresentanteId", RepresentanteId.Text);
                 
                }
                LimparControles();
                LoadGrid();
            }
        }
        /// <summary>
        /// Exclui um representante da tabela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Excluir_Click(object sender, EventArgs e) {
            string comando = "DELETE FROM Representantes WHERE RepresentanteId=" + RepresentanteId.Text;
            db.ConnectionString = App_Code.AppSettings.Connection();
            db.DataProviderName = DataServices.DataBase.DAO.ProviderName.OleDb;
            db.Query(comando);
            LimparControles();
            LoadGrid();
        }

        protected bool GravarUsuario(string nomeAcesso, string id) {
            string comando = "SELECT * FROM Representantes WHERE NomeAcesso='" + nomeAcesso + "';";
            db.ConnectionString = App_Code.AppSettings.Connection();
            db.DataProviderName = DataServices.DataBase.DAO.ProviderName.OleDb;

            DataTable tb = (DataTable)db.Query(comando);
            if (tb.Rows.Count == 0) {
                return true;
            }
            else {
                if (tb.Rows[0]["RepresentanteId"].ToString() == id) {
                    return true;
                }
                return false;
            }
        }
        protected void LoadGrid() {
            string comando = "SELECT RepresentanteId, Nome, NomeAcesso FROM Representantes ORDER BY Nome;";
            db.ConnectionString = App_Code.AppSettings.Connection();
            db.DataProviderName = DataServices.DataBase.DAO.ProviderName.OleDb;
            DataTable tb = (DataTable)db.Query(comando);

            ExibirRepresentantes.DataSource = tb;
            ExibirRepresentantes.DataBind();
            tb.Dispose();
        }

        /// <summary>
        /// Limpar os controles
        /// </summary>

        public void LimparControles() {
            RepresentanteId.Text = "";
            Nome.Text = "";
            NomeAcesso.Text = "";
            Senha.Text = "";
            Email.Text = "";
            Inserir.Text = "Inserir";
            Excluir.Visible = false;
        }

        protected void ExibirRepresentantes_SelectedIndexChanged(object sender, EventArgs e) {
            RepresentanteId.Text = ExibirRepresentantes.SelectedRow.Cells[1].Text;

            string comando = "SELECT * FROM Representantes WHERE RepresentanteId=" + RepresentanteId.Text;

            db.ConnectionString = App_Code.AppSettings.Connection();
            db.DataProviderName = DataServices.DataBase.DAO.ProviderName.OleDb;
            DataTable tb = (DataTable)db.Query(comando);

            Nome.Text = tb.Rows[0]["Nome"].ToString();
            NomeAcesso.Text = tb.Rows[0]["NomeAcesso"].ToString();
            Senha.Text = tb.Rows[0]["Senha"].ToString();
            Email.Text = tb.Rows[0]["Email"].ToString();

            Excluir.Visible = true;
        }
    }
}
