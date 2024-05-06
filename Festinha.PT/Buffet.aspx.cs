using Festinha.PT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Festinha.PT
{
    public partial class Buffet : System.Web.UI.Page
    {

        DBconnect ligacao = new DBconnect();        
        static string id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //string username = Session["Username"].ToString();
            if (!IsPostBack)
            {
                CarregarQuantidade();
                LimparTudo();
                ligacao.CarregarItens(ref ddlOpcoes,rblBuffet.Items[0].Text);
                ligacao.BindBuffet(ref dgvBuffet, Session["Username"].ToString());
                dgvBuffet.DataBind();
                decimal somatorio = 0;
                SomaValores(dgvBuffet, ref somatorio);
                lblTotalCatering.Text = somatorio.ToString();
            }

        }

        

        void CarregarQuantidade()
        {
            for (int i = 0; i <= 500; i++)
            {
                ddlQuantidadeBft.Items.Add(i.ToString());
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        void LimparTudo()
        {
            ddlOpcoes.ClearSelection();
            lblDescricao.Text = string.Empty;
            lblPreco.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            ddlQuantidadeBft.ClearSelection();
            ddlQuantidadeBft.Enabled = false;
            txtQuantidade.Enabled = false;
            btnAdicionar.Enabled = false;
            lblTotal.Text = string.Empty;
        }

        void SomaValores(GridView gdvBebida, ref decimal somatorio)
        { 
            foreach (GridViewRow row in dgvBuffet.Rows)
            {
                if (row.Cells.Count > 0)
                {
                    int indiceColuna = 3;

                    if (indiceColuna < row.Cells.Count)
                    {
                        string valorCelula = row.Cells[indiceColuna].Text;

                        decimal valorDecimal;
                        if (decimal.TryParse(valorCelula, out valorDecimal))
                        {
                            somatorio += valorDecimal;
                        }
                    }
                }
            }

        }

       

        protected void rblBuffet_SelectedIndexChanged1(object sender, EventArgs e)
        {
            ligacao.CarregarItens(ref ddlOpcoes, rblBuffet.SelectedValue.ToString());
        }

        

        protected void ddlOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string descricao = "";
            decimal valor = 0;
            string table = rblBuffet.SelectedValue.ToString();
            id = ddlOpcoes.SelectedItem.Text;

            if (id.Length > 0)
            {
                id = id.Substring(0, id.IndexOf('-'));

                if (ligacao.DevolverItens(id, table, ref descricao, ref valor))
                {
                    lblDescricao.Text = descricao;
                    lblPreco.Text = valor.ToString();
                    ddlQuantidadeBft.Enabled = true;
                    txtQuantidade.Enabled = true;
                }
                else
                {
                    lblDescricao.Text = "";
                    lblPreco.Text = "";
                    ddlQuantidadeBft.Enabled = false;
                    txtQuantidade.Enabled = false;
                }
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            {
                if (ligacao.InsereItem(Session["Username"].ToString(), rblBuffet.SelectedValue.ToString(), lblDescricao.Text, decimal.Parse(lblPreco.Text), int.Parse(txtQuantidade.Text), decimal.Parse(lblTotal.Text)))
                {
                    lblStatus.Text = "Inserido com sucesso!";
                    ligacao.BindBuffet(ref dgvBuffet, Session["Username"].ToString());
                    dgvBuffet.DataBind();
                    LimparTudo();
                    decimal somatorio = 0;
                    SomaValores(dgvBuffet, ref somatorio);
                    lblTotalCatering.Text = somatorio.ToString();
                }
                else
                {
                    lblStatus.Text = "Falha ao inserir!";
                }
            }
        }

        protected void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            ddlQuantidadeBft.Text = txtQuantidade.Text;
            lblTotal.Text = (decimal.Parse(lblPreco.Text) * decimal.Parse(ddlQuantidadeBft.SelectedValue)).ToString();
            btnAdicionar.Enabled = true;
        }

        protected void ddlQuantidadeBft_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal valorUnitario = decimal.Parse(lblPreco.Text);
            decimal quantidade = decimal.Parse(ddlQuantidadeBft.SelectedValue);
            txtQuantidade.Text = ddlQuantidadeBft.SelectedValue.ToString();
            lblTotal.Text = (quantidade * valorUnitario).ToString();
            btnAdicionar.Enabled = true;
        }

        protected void dgvBuffet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvBuffet.PageIndex = e.NewPageIndex;
            ligacao.BindBuffet(ref dgvBuffet, Session["Username"].ToString());
            dgvBuffet.DataBind();
        }
    }


}