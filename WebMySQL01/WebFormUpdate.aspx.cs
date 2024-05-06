using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMySQL01
{
    public partial class WebFormUpdate : System.Web.UI.Page
    {
        DBconnect ligacao = new DBconnect();
        static string id = "";
        

        protected void Page_Load(object sender, EventArgs e)
        {
            tbNome.Enabled = false;
            rbMasculino.Enabled = false;
            rbFeminino.Enabled = false;
            ddlIdade.Enabled = false;

            if (!this.IsPostBack)
            {
                ligacao.CarregarIdades(ref ddlIdade);                
                ddlIdade.SelectedIndex = 17;

                ligacao.CarregarFormandos(ref ddlFormandos);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx?r=Cancelou o procedimento de atualizar!");            
        }

        protected void ddlFormandos_SelectedIndexChanged(object sender, EventArgs e)
        {            
            char genero = ' ';
            int idade = 0;
            string nome_aux = "";
            id = ddlFormandos.SelectedItem.Text;

            if (id.Length > 0)
            {
                id = id.Substring(0, id.IndexOf(' '));
                tbNome.Enabled = true;                

                if (ligacao.DevolverFormando(id, ref nome_aux, ref genero, ref idade))
                {
                    tbID.Text = id;
                    tbNome.Text = nome_aux;
                    if (genero.Equals('F'))
                    {
                        rbFeminino.Checked = true;
                        rbMasculino.Checked = false;
                    }
                    else
                    {
                        rbMasculino.Checked = true;
                        rbFeminino.Checked = false;
                    }
                }                
                ddlIdade.ClearSelection();
                ddlIdade.Items.FindByValue(idade.ToString()).Selected = true;
                lblMsg.Text = "";
                
                rbMasculino.Enabled = true;
                rbFeminino.Enabled = true;
                ddlIdade.Enabled = true;
            }
            else
            {
                tbNome.Text = "";
                rbMasculino.Checked = false;
                rbFeminino.Checked = false;
                ddlIdade.ClearSelection();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {            
            char genero = 'F';
            if (VerificarCampos())
            {

                if (rbMasculino.Checked == true)
                {
                    genero = 'M';
                }
                if (ligacao.Update(id, tbNome.Text, genero, ddlIdade.SelectedItem.Text))
                {
                    Response.Redirect("index.aspx?r=Dado atualizado com sucesso!");
                                    
                }
                else
                {
                    Response.Redirect("index.aspx?r=Erro na edição!");                    
                }
            }
        }


        bool VerificarCampos()
        {
            tbNome.Text = tbNome.Text.Trim();
            tbNome.Text = Regex.Replace(tbNome.Text, @"\s+", " ");
            if (tbNome.Text.Length == 0)
            {
                lblMsg.Text = "Erro no campo Nome!";
                tbNome.Focus();
                return false;
            }

            if (rbMasculino.Checked == false && rbFeminino.Checked == false)
            {
                lblMsg.Text = "Erro no campo Género!";
                return false;
            }
            return true;
        }     

        protected void btnProcurar_Click(object sender, EventArgs e)
        {
            id = tbID.Text;
            BuscarFormando();
        }

        void BuscarFormando()
        {
            char genero = ' ';
            int idade = 0;
            string nome_aux = "";            

            if (id.Length > 0)
            {
                //id = id.Substring(0, id.IndexOf(' '));
                tbNome.Enabled = true;

                if (ligacao.DevolverFormando(id, ref nome_aux, ref genero, ref idade))
                {
                    tbID.Text = id;
                    tbNome.Text = nome_aux;
                    if (genero.Equals('F'))
                    {
                        rbFeminino.Checked = true;
                        rbMasculino.Checked = false;
                    }
                    else
                    {
                        rbMasculino.Checked = true;
                        rbFeminino.Checked = false;
                    }
                    ddlIdade.ClearSelection();
                    if (idade > 0)
                    {
                        ddlIdade.Items.FindByValue(idade.ToString()).Selected = true;
                    }
                    lblMsg.Text = "";

                    rbMasculino.Enabled = true;
                    rbFeminino.Enabled = true;
                    ddlIdade.Enabled = true;
                }
                if(nome_aux.Length == 0)
                {
                    id = "";
                    lblMsg.Text = "ID inválido!";
                    DesativarControlos();
                }               
            }
            else
            {
                DesativarControlos();
            }
        }

        void DesativarControlos()
        {
            tbNome.Text = "";
            tbNome.Enabled = false;
            rbMasculino.Checked = false;
            rbFeminino.Checked = false;
            ddlIdade.ClearSelection();
            ddlIdade.Enabled= false;
        }
    }
}