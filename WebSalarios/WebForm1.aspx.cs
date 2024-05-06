using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSalarios
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Text = string.Empty;
            Label5.Text = string.Empty;
            Label6.Text = string.Empty;            
            TextBox2.ReadOnly = true;
            TextBox3.ReadOnly = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            float salario = 0F, segSocial = 0F, liquido = 0F;
            if (TextBox1.Text.Trim().Length > 0)
            {
                try
                {
                    salario = float.Parse("0" + TextBox1.Text);
                    segSocial = salario * 0.2F;
                    TextBox2.Text = Math.Round(segSocial, 2).ToString();

                    if(salario < 500)
                    {
                        Label5.Text = "0";
                        Label6.Text = "0";
                        liquido = salario - segSocial;
                    }
                    else if(salario < 1000)
                    {
                        Label5.Text = "12";
                        Label6.Text = Math.Round(salario * 0.12F, 2).ToString();
                        liquido = salario - segSocial - (salario * 0.12f);                        
                    }
                    else if (salario < 1500)
                    {
                        Label5.Text = "15";
                        Label6.Text = Math.Round(salario * 0.15F, 2).ToString();
                        liquido = salario - segSocial - (salario * 0.15f);
                    }
                    else
                    {
                        Label5.Text = "18";
                        Label6.Text = Math.Round(salario * 0.18F, 2).ToString();
                        liquido = salario - segSocial - (salario * 0.18f);
                    }
                    Label3.ForeColor = System.Drawing.Color.Green;
                    Label3.Text = (Math.Round(salario, 2).ToString() + " - " + Math.Round(segSocial, 2).ToString() + " - " + Label6.Text);
                    TextBox3.Text = Math.Round(liquido, 2).ToString();
                }
                catch
                {
                    Limpar();
                    Label3.ForeColor = System.Drawing.Color.Red;
                    Label3.Text = "Erro!!!";
                }
            }
            else
            {
                Limpar();
                Label3.ForeColor = System.Drawing.Color.RoyalBlue;
                Label3.Text = "Indique um valor!!!";
            }
        }

        void Limpar()
        {
            Label5.Text = string.Empty;
            Label6.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
        }
    }
}