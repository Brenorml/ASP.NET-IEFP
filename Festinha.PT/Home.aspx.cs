using System;
using System.IO;
using System.Web.UI.WebControls;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using System.Text;
using PdfSharp.Pdf;
using System.Web.Security;

namespace Festinha.PT
{
    public partial class Home : System.Web.UI.Page
    {
        DBconnect ligacao = new DBconnect();        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblUsername.Text = Session["username"].ToString();                
                lblMsg.Text = Request.QueryString["r"];                
                
                if (ligacao.IniciarAplicacao(lblUsername.Text) && ligacao.IniciarControlo(lblUsername.Text))
                {                    
                    lblProposta.Text = "Criada";
                    ligacao.BindProposta(ref gdvProposta, lblUsername.Text);
                    gdvProposta.DataBind();
                }
                else
                {
                    lblProposta.Text = "Existente";
                    ligacao.BindProposta(ref gdvProposta, lblUsername.Text);
                    gdvProposta.DataBind();
                    decimal somatorio = 0;
                    SomaValores(gdvProposta, ref somatorio);
                    lblValorTotal.Text = somatorio.ToString();
                }
                
            }
        }

        protected void gdvProposta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvProposta.PageIndex = e.NewPageIndex;
            ligacao.BindProposta(ref gdvProposta, lblUsername.Text);
            gdvProposta.DataBind();
        }

        protected void btnBar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebBar.aspx");
        }

        protected void btnAtividade_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormServicos.aspx");
        }

        protected void btnBuffet_Click(object sender, EventArgs e)
        {
            Response.Redirect("Buffet.aspx");
        }

        void SomaValores(GridView gdvProposta,ref decimal somatorio)
        {
            foreach (GridViewRow row in gdvProposta.Rows)
            {
                
                if (row.Cells.Count > 0)
                {                    
                    int indiceColuna = 4;
                    
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

        protected void btnSubmeter_Click(object sender, EventArgs e)
        {
            if (ligacao.SubmissaoProposta(lblUsername.Text))
            {
                lblEnvio.Text = "Orçamento submetido com sucesso!!!";
            }            
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            if (gdvProposta.Rows.Count > 0)
            {
                string tempFileName = null;

                try
                {
                    // Nome do arquivo temporário
                    tempFileName = Path.GetTempFileName();

                    using (FileStream fileStream = new FileStream(tempFileName, FileMode.Create))
                    {
                        GeneratePdf(fileStream, gdvProposta, Encoding.UTF8);
                    }

                    // Configure a resposta para o tipo de conteúdo PDF
                    Response.ContentType = "application/pdf";
                    Response.AddHeader($"content-disposition", $"attachment;filename=Proposta_{lblUsername.Text}.PDF");

                    // Leia o conteúdo do arquivo temporário e escreva no OutputStream da resposta
                    byte[] fileBytes = File.ReadAllBytes(tempFileName);
                    Response.BinaryWrite(fileBytes);
                }
                catch (Exception ex)
                {
                    // Trate a exceção conforme necessário
                    Response.Write("Erro: " + ex.Message);
                }
                finally
                {
                    if (tempFileName != null)
                    {
                        // Exclua o arquivo temporário após o envio
                        File.Delete(tempFileName);
                    }

                    // Finalize a resposta
                    Response.End();
                }
            }
            else
            {
                // Exiba uma mensagem na página ou use outra lógica conforme necessário
                ClientScript.RegisterStartupScript(GetType(), "NoDataAlert", "alert('Não existe registro!');", true);
            }
        }

        private void GeneratePdf(Stream stream, GridView gridView, Encoding encoding)
        {
            using (MemoryStream htmlStream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(htmlStream, encoding))
                {
                    // Crie um HTML simples usando a codificação fornecida
                    writer.Write("<html><head></head><body><table>");

                    // Adicione cabeçalhos da tabela com o texto das colunas da GridView
                    writer.Write("<tr>");
                    foreach (DataControlFieldHeaderCell headerCell in gridView.HeaderRow.Cells)
                    {
                        writer.Write($"<th align=\"center\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{headerCell.Text}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>");
                    }
                    writer.Write("</tr>");
                    

                    // Adicione células com o texto das células da GridView
                    foreach (GridViewRow row in gridView.Rows)
                    {
                        writer.Write("<tr>");
                        foreach (TableCell cell in row.Cells)
                        {
                            writer.Write($"<td align=\"center\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{cell.Text}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>");
                        }
                        writer.Write("</tr>");
                    }

                    writer.Write("</table></body></html>");
                    writer.Flush();
                    htmlStream.Position = 0;

                    // Converta o HTML para PDF usando HtmlRenderer.PdfSharp
                    using (StreamReader reader = new StreamReader(htmlStream, encoding))
                    {
                        string htmlString = reader.ReadToEnd();
                        PdfDocument pdfDocument = PdfGenerator.GeneratePdf(htmlString, PdfSharp.PageSize.A4);
                        pdfDocument.Save(stream);
                    }
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }

}