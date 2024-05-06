using System;
using System.Web.UI.WebControls;

namespace Festinha.PT
{
    public partial class WebFormServicos : System.Web.UI.Page
    {
        DBconnect ligacao = new DBconnect();
        static string id = "";

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                CarregarQuantidade();
                LimparTudo();
                ligacao.CarregarItens(ref ddlServico, rdbServicos.Items[0].Text);
                ligacao.BindServico(ref gdvServico, Session["Username"].ToString());
                gdvServico.DataBind();
                decimal somatorio = 0;
                SomaValores(gdvServico, ref somatorio);
                lblTotalGeral.Text = somatorio.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void rdbServicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ligacao.CarregarItens(ref ddlServico, rdbServicos.SelectedValue.ToString());
        }

        void CarregarQuantidade()
        {
            for (int i = 0; i <= 500; i++)
            {
                ddlQuantidade.Items.Add(i.ToString());
            }
        }

        protected void ddlServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            string descricao = "";
            decimal valor = 0;
            string table = rdbServicos.SelectedValue.ToString();
            id = ddlServico.SelectedItem.Text;

            if (id.Length > 0)
            {
                id = id.Substring(0, id.IndexOf('-'));

                if (ligacao.DevolverItens(id, table, ref descricao, ref valor))
                {
                    lblDescServico.Text = descricao;
                    lblValorUnitario.Text = valor.ToString();
                    ddlQuantidade.Enabled = true;
                    txtQuantidade.Enabled = true;
                }
                else
                {
                    lblDescServico.Text = "";
                    lblValorUnitario.Text = "";
                    ddlQuantidade.Enabled = false;
                    txtQuantidade.Enabled = false;
                }
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            {
                if (ligacao.InsereItem(Session["Username"].ToString(), rdbServicos.SelectedValue.ToString(), lblDescServico.Text, decimal.Parse(lblValorUnitario.Text), int.Parse(txtQuantidade.Text), decimal.Parse(lblTotal.Text)))
                {
                    lblStatus.Text = "Inserido com sucesso!";
                    ligacao.BindServico(ref gdvServico, Session["Username"].ToString());
                    gdvServico.DataBind();
                    LimparTudo();
                    decimal somatorio = 0;
                    SomaValores(gdvServico, ref somatorio);
                    lblTotalGeral.Text = somatorio.ToString();
                }
                else
                {
                    lblStatus.Text = "Falha ao inserir!";
                }
            }
        }

        protected void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            ddlQuantidade.Text = txtQuantidade.Text;
            lblTotal.Text = (decimal.Parse(lblValorUnitario.Text) * decimal.Parse(ddlQuantidade.SelectedValue)).ToString();
            btnAdicionar.Enabled = true;
        }

        protected void ddlQuantidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal valorUnitario = decimal.Parse(lblValorUnitario.Text);
            decimal quantidade = decimal.Parse(ddlQuantidade.SelectedValue);
            txtQuantidade.Text = ddlQuantidade.SelectedValue.ToString();
            lblTotal.Text = (quantidade * valorUnitario).ToString();
            btnAdicionar.Enabled = true;
        }

        protected void gdvServico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvServico.PageIndex = e.NewPageIndex;
            ligacao.BindServico(ref gdvServico, Session["Username"].ToString());
            gdvServico.DataBind();
        }

        void LimparTudo()
        {
            ddlServico.ClearSelection();
            lblDescServico.Text = string.Empty;
            lblValorUnitario.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            ddlQuantidade.ClearSelection();
            ddlQuantidade.Enabled = false;
            txtQuantidade.Enabled = false;
            btnAdicionar.Enabled = false;
        }

        void SomaValores(GridView gdvServico, ref decimal somatorio)
        {
            foreach (GridViewRow row in gdvServico.Rows)
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

    }
}