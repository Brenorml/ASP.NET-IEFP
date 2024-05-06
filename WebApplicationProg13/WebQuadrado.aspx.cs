using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationProg13
{
    public partial class WebQuadrado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                lblResultado.Text = Math.Round(Math.Pow(float.Parse(txtLado.Text), 2), 2).ToString();                
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