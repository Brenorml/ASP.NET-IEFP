using System;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Festinha.PT
{
    public partial class Logon : System.Web.UI.Page
    {
        DBconnectAdmin ligacao = new DBconnectAdmin();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserPass.Attributes.Add("value", txtUserPass.Text);
        }

        protected void btnLogon_Click(object sender, EventArgs e)
        {            
            if (ligacao.ValidateUser(txtUserName.Text, txtUserPass.Text))
            {
                Session["username"] = txtUserName.Text;
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
                //Response.Redirect("home.aspx");
                if (ligacao.VerifyAccess(txtUserName.Text) == true)
                {
                    Response.Redirect("home.aspx");
                }
                else
                {
                    Response.Redirect("WebAdmin.aspx");
                }

            }
            else
            {
                lblMsg.Text = "Nome ou Palavra Passe inválidos!";
            }
        }

        protected void CbMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMostrar.Checked)
            {

                txtUserPass.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                txtUserPass.TextMode = TextBoxMode.Password;
            }
        }
    }
}