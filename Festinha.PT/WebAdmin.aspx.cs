using System;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI.WebControls;


namespace Festinha.PT
{
    public partial class WebAdmin : System.Web.UI.Page
    {
        DBconnectAdmin ligacao = new DBconnectAdmin();
        static string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblLogin.Text = Session["username"].ToString();
                ddlTabelas.Enabled = false;
                ddlItens.Enabled = false;
                txtID.Enabled = false;
                if(lblLogin.Text == "funcionario")
                {
                    lblPropostas.Visible = false;
                    lblSubmetidas.Visible = false;
                    lblStatus.Visible = false;
                    ddlPropostas.Visible = false;
                    btnAprovar.Visible = false;
                }
                else
                {
                    btnAprovar.Enabled = false;
                }                
                btnAtualizar.Enabled = false;
                btnDeletar.Enabled = false;
                btnGuardar.Enabled = false;
                ligacao.CarregarTabelas(ref ddlPropostas);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtDescricao.Text = "";
            txtEmbalagem.Text = "";
            txtValor.Text = "";
            ddlItens.ClearSelection();
            ddlTabelas.ClearSelection();
            ddlPropostas.ClearSelection();
            rdbTipos.ClearSelection();
            lblPropostas.Text = "";
            lblMsg.Text = "";
            ddlTabelas.Enabled = false;
            ddlItens.Enabled = false;
        }

        protected void rdbTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarOpcoesTabelas();
            ddlTabelas.Enabled = true;
            if (IsPostBack)
            {
                ddlTabelas.ClearSelection();                
                ddlItens.Items.Clear();
                ddlItens.Enabled = false;
                btnAtualizar.Enabled = false;
                btnDeletar.Enabled = false;
                LimparCampos();
            }
        }

        protected void ddlTabelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string table = ddlTabelas.SelectedValue.ToString();
            ligacao.CarregarTabelas(ref ddlItens, table);
            ddlItens.Enabled = true;
            btnGuardar.Enabled = true;
            if (IsPostBack && ddlTabelas.SelectedItem.Text == "")
            {
                ddlItens.ClearSelection();                
                btnAtualizar.Enabled = false;
                btnDeletar.Enabled = false;
                btnGuardar.Enabled = false;
                LimparCampos();
            }            
        }

        protected void ddlItens_SelectedIndexChanged(object sender, EventArgs e)
        {            
            LimparCampos();
            btnGuardar.Enabled = false;
            string descricao = "";
            decimal quantidade = 0;
            decimal valor = 0;
            string table = ddlTabelas.SelectedValue.ToString();
            id = ddlItens.SelectedItem.Text;

            if (id.Length > 0)
            {
                id = id.Substring(0, id.IndexOf('-'));

                if (ligacao.DevolverItens(id, table, ref descricao, ref valor, ref quantidade))
                {                    
                    txtID.Text = id.ToString();
                    txtDescricao.Text = descricao;
                    txtEmbalagem.Text = quantidade.ToString();
                    txtValor.Text = valor.ToString();
                    btnAtualizar.Enabled = true;
                    btnDeletar.Enabled = true;
                }
                else
                {
                    txtID.Text = string.Empty;
                    txtDescricao.Text = string.Empty;
                    txtEmbalagem.Text = string.Empty;
                    txtValor.Text = string.Empty; ;
                    btnGuardar.Enabled = true;
                }
            }
            else
            {
                ddlItens.ClearSelection();
                LimparCampos();
                btnGuardar.Enabled = true;
                btnAtualizar.Enabled = false;
                btnDeletar.Enabled = false;
            }
        }
        
        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            if (id.Length > 0)
            {               
                if (ligacao.Delete(id, ddlTabelas.SelectedItem.Text))
                {
                    lblMsg.Text = "Dado apagado com sucesso!";
                    ddlTabelas_SelectedIndexChanged(sender, e);
                    btnAtualizar.Enabled = false;
                    btnDeletar.Enabled = false;
                    LimparCampos();
                }
                else
                {
                    lblMsg.Text = "Falha ao apagar!";
                }
            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {            
            if (VerificarCampos())
            {                
                if (ligacao.Update(ddlTabelas.SelectedItem.Text , id, txtDescricao.Text, decimal.Parse(txtEmbalagem.Text), decimal.Parse(txtValor.Text)))
                {                    
                    lblMsg.Text = "Dado atualizado com sucesso!";
                    ddlTabelas_SelectedIndexChanged(sender, e);
                    LimparCampos();
                }
                else
                {
                    lblMsg.Text = "Falha ao atualizar!";
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {                
                if (ligacao.Insert(ddlTabelas.SelectedItem.Text, txtDescricao.Text, decimal.Parse(txtEmbalagem.Text), decimal.Parse(txtValor.Text)))
                {                    
                    lblMsg.Text = "Inseriu com sucesso!";
                    ddlTabelas_SelectedIndexChanged(sender, e);
                    LimparCampos();
                }
                else
                {
                    lblMsg.Text = "Erro na inserção!";
                }
            }
        }

        bool VerificarCampos()
        {
            txtDescricao.Text = txtDescricao.Text.Trim();
            txtDescricao.Text = Regex.Replace(txtDescricao.Text, @"\s+", " ");
            if (txtDescricao.Text.Length == 0)
            {
                lblMsg.Text = "Erro no campo Nome!";
                txtDescricao.Focus();
                return false;
            }
            if (txtEmbalagem.Text.Length == 0)
            {
                lblMsg.Text = "Erro no campo Embalagem!";
                return false;
            }
            if (txtValor.Text.Length == 0)
            {
                lblMsg.Text = "Erro no campo Valor!";
                return false;
            }
            return true;
        }
        void CarregarOpcoesTabelas()
        {
            ddlTabelas.Items.Clear();
            ddlTabelas.Items.Add("");
            if (rdbTipos.SelectedIndex == 0)
            {
                ddlTabelas.Items.Add(new ListItem("Cerveja", "cerveja"));
                ddlTabelas.Items.Add(new ListItem("Champagne", "champagne"));
                ddlTabelas.Items.Add(new ListItem("Vinho", "vinho"));
                ddlTabelas.Items.Add(new ListItem("Whisky", "whisky"));
                ddlTabelas.Items.Add(new ListItem("Refrigerante", "refrigerante"));
            }
            else if (rdbTipos.SelectedIndex == 1)
            {
                ddlTabelas.Items.Add(new ListItem("Salgados/Doces", "salgados"));
                ddlTabelas.Items.Add(new ListItem("Carnes", "carnes"));
                ddlTabelas.Items.Add(new ListItem("Peixe", "peixe"));
                ddlTabelas.Items.Add(new ListItem("Vegetariano", "vegetariano"));
                ddlTabelas.Items.Add(new ListItem("Sobremesas", "sobremesas"));
            }
            else
            {
                ddlTabelas.Items.Add(new ListItem("Casamento", "casamento"));
                ddlTabelas.Items.Add(new ListItem("Festas", "festas"));
            }
        }

        void LimparCampos()
        {
            txtID.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtEmbalagem.Text = string.Empty;
            txtValor.Text = string.Empty; ;
        }

        protected void ddlPropostas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlPropostas.SelectedIndex != 0)
            {
                ligacao.BindProposta(ref gdvProposta, ddlPropostas.SelectedItem.Text);
                gdvProposta.DataBind();
                btnAprovar.Enabled = true;
            }
            else
            {
                gdvProposta.DataSource = null;
                gdvProposta.DataBind();
            }
        }

        protected void btnAprovar_Click(object sender, EventArgs e)
        {
            ligacao.Approval(ddlPropostas.SelectedItem.Text,ref lblStatus, ddlPropostas.SelectedItem.Text);
        }

        protected void gdvProposta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvProposta.PageIndex = e.NewPageIndex;
            ligacao.BindProposta(ref gdvProposta, ddlPropostas.SelectedItem.Text);
            gdvProposta.DataBind();
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}