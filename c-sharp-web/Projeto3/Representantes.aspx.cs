using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto3 {
    public partial class Representantes : System.Web.UI.Page {
        //Publica para todos os métodos da classe
        Model.Representantes representante = new Model.Representantes();

        //Instancia da classe de acesso ao banco de dados
        //DAO = Data Acces Object
        DataServices.DataBase.DAO db = new DataServices.DataBase.DAO();
        
        protected void Page_Load(object sender, EventArgs e) {

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
            else if (GravarUsuario(NomeAcesso.Text, RepresentanteId.Text ) == false) {
            }
            else {
                if(RepresentanteId.Text == "") {
                    //Inserir novo registro;
                    representante.Nome = Nome.Text;
                    representante.Email = Email.Text;
                    representante.NomeAcesso = NomeAcesso.Text;
                    representante.Senha = Senha.Text;

                    db.Insert(representante, "RepresentanteId");
                    //SQL PARA INSERIR ESTE REGISTRO;
                    //string comando = "INSERT INTO Representantes (Nome, Email, NomeAcesso, Senha) VALUES ('" + Nome.Text + "','" + Email.Text + "','" + NomeAcesso.Text + "','" + Senha.Text + "');";
                    //db.Query(comando);
                }
                else {
                    //Editar Registro
                    representante.Nome = Nome.Text;
                    representante.Email = Email.Text;
                    representante.NomeAcesso = NomeAcesso.Text;
                    representante.Senha = Senha.Text;
                    db.Update(representante, "RepresentanteId", RepresentanteId.Text);
                    //SQL PARA EDITAR
                    //string comandoUpdate = "UPDATE Representante SET Nome='" + Nome.Text + "','" + Email.Text + "','" + NomeAcesso.Text + "','" + Senha.Text + "' WHERE RepresentanteId = " + RepresentanteId.Text;
                    //db.Query(comandoUpdate);
                }
            }
            
        }

        protected void Excluir_Click(object sender, EventArgs e) {

        }

        protected bool GravarUsuario(string nomeAcesso, string id) {
            string comando = "SELECT * FROM Representante WHERE NomeAcesso='" + nomeAcesso + "';";
            System.Data.DataTable tb = (System.Data.DataTable)db.Query(comando);
            if(tb.Rows.Count == 0) {
                return true;
            }
            else {
               if(tb.Rows[0]["RepresentanteId"].ToString() == RepresentanteId.Text) {
                    return true;
                }
                return false;
            }
        }
    }
}
