using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationProg13
{
    public partial class WebRectangulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                lblResultado.Text = (Math.Round(float.Parse(txtLargura.Text) * float.Parse(txtComprimento.Text), 2)).ToString();
                if (txtLargura.Text == txtComprimento.Text)
                {
                    lblResultado.Text = "Isto é um quadrado!!! Clique em voltar e selecione o formulário correcto...";
                    
                    // ABAIXO TEM A TENTATIVA FALHA DE REDIRECIONAMENTO PARA O FORMCIRCULO APÓS IDENTIFICAÇÃO DE UM QUADRADO E CLICAR ENTER APÓS LER MENSAGEM

                    //lblResultado.Text = "Isto é um quadrado.Prima enter para ser redirecionado para o formulário correto...";
                    //ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                    //if (consoleKeyInfo.Key == ConsoleKey.Enter)
                    //{                        
                    //Response.Redirect("WebQuadrado.aspx");
                    //}                                       
                }
            }
            catch
            {
                lblResultado.Text = "ERRO!!";
            }
        }

        protected void lbtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormMenu.aspx");
        }
    }
}