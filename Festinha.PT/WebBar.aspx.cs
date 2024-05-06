using System;
using System.Web.UI.WebControls;

namespace Festinha.PT
{
    public partial class WebBar : System.Web.UI.Page
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
                ligacao.CarregarItens(ref ddlBebidas, rdbBebidas.Items[0].Text);               
                ligacao.BindBebidas(ref gdvBebida, Session["Username"].ToString());
                gdvBebida.DataBind();
                decimal somatorio = 0;
                SomaValores(gdvBebida, ref somatorio);
                lblTotalGeral.Text = somatorio.ToString();
            }
        }
        
        protected void btnCancelBebida_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void rdbBebidas_SelectedIndexChanged(object sender, EventArgs e)
        {            
            ligacao.CarregarItens(ref ddlBebidas, rdbBebidas.SelectedValue.ToString());
        }

        void CarregarQuantidade()
        {
            for (int i = 0; i <= 500; i++)
            {
                ddlQuantidade.Items.Add(i.ToString());
            }
        }

        protected void ddlBebidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string descricao = "";
            decimal valor = 0;
            string table = rdbBebidas.SelectedValue.ToString();
            id = ddlBebidas.SelectedItem.Text;

            if (id.Length > 0)
            {
                id = id.Substring(0, id.IndexOf('-'));

                if (ligacao.DevolverItens(id, table, ref descricao, ref valor))
                {
                    lblDescBebida.Text = descricao;
                    lblValorUnitario.Text = valor.ToString();
                    ddlQuantidade.Enabled = true;
                    txtQuantidade.Enabled = true;
                }
                else
                {
                    lblDescBebida.Text = "";
                    lblValorUnitario.Text = "";
                    ddlQuantidade.Enabled = false;
                    txtQuantidade.Enabled = false;
                }
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {            
            {
                if(ligacao.InsereItem(Session["Username"].ToString(), rdbBebidas.SelectedValue.ToString(), lblDescBebida.Text, decimal.Parse(lblValorUnitario.Text), int.Parse(txtQuantidade.Text), decimal.Parse(lblTotal.Text)))
                {
                    lblInsere.Text = "Inserido com sucesso!";
                    ligacao.BindBebidas(ref gdvBebida, Session["Username"].ToString());
                    gdvBebida.DataBind();
                    LimparTudo();
                    decimal somatorio = 0;
                    SomaValores(gdvBebida, ref somatorio);
                    lblTotalGeral.Text = somatorio.ToString();
                }
                else
                {
                    lblInsere.Text = "Falha ao inserir!";
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
        
        protected void gdvBebida_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {            
            gdvBebida.PageIndex = e.NewPageIndex;
            ligacao.BindBebidas(ref gdvBebida, Session["Username"].ToString());
            gdvBebida.DataBind();
        }

        void LimparTudo()
        {
            ddlBebidas.ClearSelection();
            lblDescBebida.Text = string.Empty;
            lblValorUnitario.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            ddlQuantidade.ClearSelection();            
            ddlQuantidade.Enabled = false;
            txtQuantidade.Enabled = false;
            btnAdicionar.Enabled = false;
            lblTotal.Text = string.Empty;
        }

        void SomaValores(GridView gdvBebida, ref decimal somatorio)
        {
            foreach (GridViewRow row in gdvBebida.Rows)
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