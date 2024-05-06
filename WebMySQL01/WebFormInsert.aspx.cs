using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMySQL01
{
    public partial class WebFormInsert : System.Web.UI.Page
    {

        DBconnect ligacao = new DBconnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                carregarIdades();
                DropDownList1.SelectedIndex = 17;
            }
            
        }

        void carregarIdades()
        {
            for (int i = 1; i <=150; i++)
            {
                DropDownList1.Items.Add(i.ToString());
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            char genero = 'M';
            if (verificarCampos())
            {
                if (RadioButton2.Checked)
                {
                    genero = 'F';
                }
                if (ligacao.Insert(TextBox1.Text, genero, DropDownList1.SelectedItem.Text))
                {
                    Response.Redirect("index.aspx?r=Inseriu com sucesso!");
                    //lblMsg.Text = "Inseriu com sucesso!";
                }
                else
                {
                    lblMsg.Text = "ERRO na inserção!";
                }
            }
        }

        bool verificarCampos()
        {
            TextBox1.Text = TextBox1.Text.Trim();
            TextBox1.Text = Regex.Replace(TextBox1.Text, @"\s+", " ");
            if (TextBox1.Text.Length ==0)
            {
                lblMsg.Text = "Erro no campo Nome!";
                TextBox1.Focus();
                return false;
            }

            if (RadioButton1.Checked == false && RadioButton2.Checked == false)
            {
                lblMsg.Text = "Erro no campo Género!";
                return false;
            }

            return true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}